using CefSharp;
using CefSharp.WinForms;
using ChroimumFullScreenNETFramework.Dialogs;
using ChroimumFullScreenNETFramework.Models;
using Serilog;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ChroimumFullScreenNETFramework
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser browser;
        private Timer checkUrlTimer;
        private WebsiteUnreachableDialog unreachableDialog;
        private bool unreachableDialogShown;
        private int pingRetryCount = 0;
        private bool isCheckingUrl;

        private static Ping _ping;
        private Options options;

        private static readonly ILogger _logger = Log.ForContext<Form1>();

        [DllImport("user32.dll")]
        public static extern bool RegisterTouchWindow(IntPtr hWnd, uint ulFlags);

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (browser != null && !browser.IsDisposed)
            {
                // Register the browser window as a touch window
                RegisterTouchWindow(browser.Handle, 0);
            }
        }

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
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
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
                }));
            }

            else
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


        }

        private void Options_OnChange(object sender, EventArgs e)
        {
            _logger.Information($"Settings has changed.");

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
            // Return if the previous call hasn't completed
            if (isCheckingUrl) return;

            // Indicate that the check is in progress
            isCheckingUrl = true;

            try
            {
                string url = PrepareInput(options.Url);

                if (IsValidUrlOrIPAddress(url))
                {
                    // Extract the hostname
                    string hostname = new Uri(url).Host;

                    // Get the IP addresses
                    IPAddress[] ipAddresses = await Dns.GetHostAddressesAsync(hostname);

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
                    _logger.Error("Not valid URL or IP address: " + url);
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
                isCheckingUrl = false;
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
            string ipPattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(2 5[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

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
            if (pingRetryCount > options.RetryCount)
            {
                pingRetryCount = 0;
            }

            if (unreachableDialogShown)
            {
                _logger.Information($"Connected to '{options.Url}'.");
                Enabled = true;
                if (unreachableDialog == null)
                    unreachableDialog = new WebsiteUnreachableDialog();
                unreachableDialog.Hide();
                unreachableDialogShown = false;


                //using (var httpClient = new HttpClient())
                //{
                //    try
                //    {
                //        HttpResponseMessage response = await httpClient.GetAsync(PrepareInput(options.Url));
                //        if (response.IsSuccessStatusCode)
                //        {
                //            checkUrlTimer.Enabled = false;
                //            pingRetryCount = 0;
                //            browser.Reload();
                //        }

                //        else
                //        {
                //            checkUrlTimer.Enabled = true;
                //            pingRetryCount++;
                //        }
                //    }
                //    catch (HttpRequestException ex)
                //    {
                //        _logger.Error(ex.Message);
                //    }
                //}

                // Evaluate the body's content of the webpage
                browser.EvaluateScriptAsync("document.body.innerHTML").ContinueWith(task =>
                {
                    if (!task.IsFaulted)
                    {
                        var response = task.Result;
                        if (response.Success && response.Result != null)
                        {
                            var bodyContent = response.Result.ToString();
                            if (string.IsNullOrWhiteSpace(bodyContent))
                            {
                                BeginInvoke(new Action(() =>
                                {
                                    browser.Reload();
                                    //checkUrlTimer.Enabled = true;
                                    pingRetryCount++;
                                }));
                            }

                            else
                            {
                                BeginInvoke(new Action(() =>
                                {
                                    //browser.Reload();
                                    //checkUrlTimer.Enabled = false;
                                    pingRetryCount = 0;
                                }));
                            }
                        }
                    }
                });
            }
        }

        private void SetCustomMessage(string message)
        {
            string script = $"document.body.innerHTML = '<div style=\"color: red; font-size: 24px; text-align: center; margin-top: 20px;\">{message}</div>';";
            browser.ExecuteScriptAsync(script);
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

            checkUrlTimer.Enabled = true;
        }


        private void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.IgnoreCertificateErrors = true;
            settings.LogSeverity = LogSeverity.Error;
            settings.CefCommandLineArgs.Add("touch-events", "enabled");
            settings.CefCommandLineArgs.Add("disable-usb-keyboard-detect", "1");
            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser(options.Url);
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

            browser.JavascriptMessageReceived += OnJavascriptMessageReceived;
            browser.LoadingStateChanged += OnLoadingStateChanged;
        }

        private void StartTabTipIfNotRunning()
        {
            string touchKeyboardPath = @"osk.exe";

            // Start the Touch Keyboard
            Process.Start(touchKeyboardPath);


        }


        private void OnJavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
            // Cast the received message to a dynamic object
            dynamic message = e.Message;

            // Check if the message type is 'input-click'
            //if (message.type == "element-click")
            //{
            //    StartTabTipIfNotRunning();
            //}

            //else if (message.type == "single-click-or-tap")
            //{


            if (message.type == "single-click-or-tap")
            {

                // Perform the actions you need for an 'input-click' type message
                var unreachdia = new WebsiteUnreachableDialog("Dialog nastavení");
                unreachdia.TopMost = true;
                unreachdia.FormClosed += Unreachdia_FormClosed;

                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() => Enabled = false));
                }
                unreachdia.ShowDialog();
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() => Enabled = true));
                }
            }
        }


        private void Unreachdia_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Enabled = true));
            }
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                // Page has finished loading, inject JavaScript for single click or tap
                browser.ExecuteScriptAsync(@"
        document.addEventListener('click', function(event) {
            const rect = { left: 10, top: 10, width: 50, height: 50 };
            const x = event.clientX;
            const y = event.clientY;

            if(x >= rect.left && x <= rect.left + rect.width && y >= rect.top && y <= rect.top + rect.height) {
                CefSharp.PostMessage({ type: 'single-click-or-tap', x: x, y: y });
            }
        });
        ");

                // Page has finished loading, inject JavaScript to attach event listeners to all relevant form elements
                browser.ExecuteScriptAsync(@"
        Array.from(document.querySelectorAll('input, textarea')).forEach(function(element) {
            element.addEventListener('click', function() {
                // Determine the element's type or tag for a more generic handling approach
                var elementType = element.tagName.toLowerCase();
                if (element.type) {
                    elementType += ':' + element.type.toLowerCase(); // Append the type for inputs if available
                }
                // Send a message back to CefSharp with details about the clicked element
                CefSharp.PostMessage({ 
                    type: 'element-click', 
                    elementType: elementType, 
                    value: element.value || '' // Use the element's value if applicable
                });
            });
        });
        ");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Cef.Shutdown()));
            }

            else
            {
                Cef.Shutdown();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            unreachableDialog = new WebsiteUnreachableDialog();
        }
    }
}