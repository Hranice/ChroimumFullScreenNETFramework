using CefSharp;
using CefSharp.WinForms;
using ChroimumFullScreenNETFramework.Dialogs;
using ChroimumFullScreenNETFramework.Models;
using Serilog;
using System;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ChroimumFullScreenNETFramework
{
    public partial class Form1 : Form
    {
        // Import the necessary DLLs for simulating key presses
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        // Virtual-Key codes
        const byte VK_LWIN = 0x5B; // Left Windows key (Natural keyboard)
        const int KEYEVENTF_EXTENDEDKEY = 0x0001; // Key down flag
        const int KEYEVENTF_KEYUP = 0x0002; // Key up flag

        private ChromiumWebBrowser browser;
        private Timer checkUrlTimer;
        private WebsiteUnreachableDialog unreachableDialog;
        private bool unreachableDialogShown;

        private static Ping _ping;
        private Options options;

        private static readonly ILogger _logger = Log.ForContext<Form1>();

        public Form1()
        {
            InitializeComponent();

            _ping = new Ping();

            options = new Options();
            Options.OnError += Options_OnError;
            Options.OnChange += Options_OnChange;
            options = Options.Load();

            InitializeChromium();
            SetupTimer();
            MakeFormFullscreen();
        }

        private void Reload()
        {
            options = Options.Load();

            if (browser == null)
                InitializeChromium();

            else
            {
                browser.LoadUrl(options.Url);
                browser.Refresh();
            }

            SetupTimer();
        }

        private void Options_OnChange(object sender, EventArgs e)
        {
            _logger.Information($"Settings has changed. Url: '{options.Url}', Refresh interval: '{options.RefreshInterval}'");

            Reload();
        }

        private void Options_OnError(object sender, OptionsErrorEventArgs e)
        {
            _logger.Error($"An exception has occurred. {e.Exception}");

            OpenOptionsDialog();
        }

        private void OpenOptionsDialog()
        {
            var optionsDialog = new OptionsDialog(options);
            optionsDialog.Owner = this;

            if (optionsDialog.ShowDialog(this) == DialogResult.OK)
            {
                options = optionsDialog.Options;

                if (options.RefreshInterval == 0)
                {
                    MessageBox.Show("Hodnota intervalu není ve správném formátu.");
                    OpenOptionsDialog();
                    return;
                }

                Options.Save(options);

                Reload();
            }
        }

        private void MakeFormFullscreen()
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void SetupTimer()
        {
            if (checkUrlTimer == null)
            {
                checkUrlTimer = new Timer();
                checkUrlTimer.Tick += CheckUrlAccessibility;
            }

            checkUrlTimer.Interval = options.RefreshInterval;
            checkUrlTimer.Start();
        }

        private async void CheckUrlAccessibility(object sender, EventArgs e)
        {
            checkUrlTimer.Enabled = false;

            try
            {
                string url = PrepareInput(options.Url);

                if (IsValidUrlOrIPAddress(url))
                {
                    // Extract the hostname
                    string hostname = new Uri(url).Host;

                    // Get the IP addresses
                    IPAddress[] ipAddresses = Dns.GetHostAddresses(hostname);

                    PingReply reply = await _ping.SendPingAsync(ipAddresses[0], options.PingTimeout);

                    if (reply.Status != IPStatus.Success)
                    {
                        HandleFailure();
                    }

                    else
                    {
                        HandleSuccess();
                    }
                }

                else
                {
                    _logger.Error("not valid url or ip address." + url);
                    HandleFailure();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                HandleFailure();
            }

            finally
            {
                checkUrlTimer.Enabled = true;
            }
        }

        static bool IsValidUrlOrIPAddress(string input)
        {
            // Regular expression to check if the string is a valid URL (including those with IP addresses)
            string urlPattern = @"^(http|https|ftp)://[a-zA-Z0-9\-\.]+(:[0-9]+)?(/.*)?$";
            // More accurate IP address pattern for IPv4
            string ipPattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            // Check if it is a valid URL or an IP address
            return Regex.IsMatch(input, urlPattern) || Regex.IsMatch(input, ipPattern);
        }


        static string PrepareInput(string input)
        {
            // Regular expression to check for valid IP address
            string ipPattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

            // Strip scheme if present
            string inputWithoutScheme = Regex.Replace(input, @"^(http|https|ftp)://", "");

            // If the stripped input is a valid IP address, return it with 'http://' prefixed (only if needed for subsequent operations)
            if (Regex.IsMatch(inputWithoutScheme, ipPattern))
            {
                return input.StartsWith("http") ? input : "http://" + inputWithoutScheme;
            }

            // Regular expression to check if scheme is missing
            string schemePattern = @"^(http|https|ftp)://";

            // If the original input does not start with a scheme, prepend "http://"
            if (!Regex.IsMatch(input, schemePattern))
            {
                return "http://" + input;
            }

            return input;
        }


        private void HandleSuccess()
        {
            if (unreachableDialogShown)
            {
                _logger.Information($"Connected to '{options.Url}'.");
                Enabled = true;
                if (unreachableDialog == null)
                    unreachableDialog = new WebsiteUnreachableDialog();
                unreachableDialog.Hide();
                unreachableDialogShown = false;
                browser.Reload();
            }
        }

        private void HandleFailure()
        {
            if (!unreachableDialogShown)
            {
                _logger.Warning($"Disconnected from '{options.Url}'. Refreshing interval is set to {options.RefreshInterval}");
                Enabled = false;
                if (unreachableDialog == null)
                    unreachableDialog = new WebsiteUnreachableDialog();
                unreachableDialog.Show();
                unreachableDialogShown = true;
            }
        }


        private void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.IgnoreCertificateErrors = true;
            settings.LogSeverity = LogSeverity.Error;
            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser(options.Url);
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

            browser.JavascriptMessageReceived += OnJavascriptMessageReceived;
            browser.LoadingStateChanged += OnLoadingStateChanged;
        }

        private void OnJavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
            dynamic message = e.Message;

            if (message != null && message.type == "double-click")
            {
                keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0);
            }
        }


        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                // Page has finished loading, inject JavaScript to handle both double-click and double-tap
                browser.ExecuteScriptAsync(@"
        let lastTapTime = 0;
        let lastTapX = 0;
        let lastTapY = 0;
        
        // Function to check if the event is within the specified rectangle
        function isWithinRectangle(x, y, rect) {
            return x >= rect.left && x <= rect.left + rect.width && y >= rect.top && y <= rect.top + rect.height;
        }
        
        // Handle touchend event for double-tap detection
        document.addEventListener('touchend', function(event) {
            const currentTime = new Date().getTime();
            const tapLength = currentTime - lastTapTime;
            const rect = { left: 10, top: 10, width: 50, height: 50 };
            
            // Get touch point
            const touch = event.changedTouches[0];
            const x = touch.clientX;
            const y = touch.clientY;
            
            // Check for double-tap
            if(tapLength < 500 && Math.abs(x - lastTapX) < 50 && Math.abs(y - lastTapY) < 50) {
                if(isWithinRectangle(x, y, rect)) {
                    CefSharp.PostMessage({ type: 'double-tap', x: x, y: y });
                }
            }
            
            // Remember the time and position of this tap
            lastTapTime = currentTime;
            lastTapX = x;
            lastTapY = y;
        });

        // Handle dblclick event for mouse double-click detection
        document.addEventListener('dblclick', function(event) {
            const rect = { left: 10, top: 10, width: 50, height: 50 };
            const x = event.clientX;
            const y = event.clientY;

            if(isWithinRectangle(x, y, rect)) {
                CefSharp.PostMessage({ type: 'double-click', x: x, y: y });
            }
        });
        ");
            }
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cef.Shutdown();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            unreachableDialog = new WebsiteUnreachableDialog();
        }
    }
}