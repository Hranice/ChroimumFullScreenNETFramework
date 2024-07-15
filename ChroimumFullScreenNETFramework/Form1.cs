using CefSharp;
using CefSharp.WinForms;
using ChroimumFullScreenNETFramework.Dialogs;
using ChroimumFullScreenNETFramework.Helpers;
using ChroimumFullScreenNETFramework.Models;
using Serilog;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        private static readonly Ping _ping = new Ping();
        private Options options = new Options();
        private static readonly ILogger _logger = Log.ForContext<Form1>();

        [DllImport("user32.dll")]
        public static extern bool RegisterTouchWindow(IntPtr hWnd, uint ulFlags);

        public Form1()
        {
            InitializeComponent();
            Options.OnError += Options_OnError;
            Options.OnChange += Options_OnChange;
            options = Options.Load();

            InitializeChromium();
            SetupTimer();
            MakeFormFullscreen();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (browser != null && !browser.IsDisposed)
            {
                RegisterTouchWindow(browser.Handle, 0);
            }
        }

        private void Reload()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(ReloadBrowser));
            }
            else
            {
                ReloadBrowser();
            }
        }

        private void ReloadBrowser()
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
            _logger.Information("Settings have changed.");
            Reload();
        }

        private void Options_OnError(object sender, OptionsErrorEventArgs e)
        {
            _logger.Error($"An exception has occurred. {e.Exception}");
            OpenOptionsDialog();
        }

        private void OpenOptionsDialog()
        {
            var optionsDialog = new OptionsDialog(options) { Owner = this };

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
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
        }

        private void SetupTimer()
        {
            checkUrlTimer = checkUrlTimer ?? new Timer { Interval = options.RefreshInterval };
            checkUrlTimer.Tick += async (sender, e) => await CheckUrlAccessibility();
            checkUrlTimer.Start();
        }

        private async Task CheckUrlAccessibility()
        {
            if (isCheckingUrl) return;

            isCheckingUrl = true;
            try
            {
                string url = PrepareInput(options.Url);

                if (IsValidUrlOrIPAddress(url))
                {
                    string hostname = new Uri(url).Host;
                    IPAddress[] ipAddresses = await Dns.GetHostAddressesAsync(hostname);
                    PingReply reply = await _ping.SendPingAsync(ipAddresses[0], options.PingTimeout);

                    if (reply.Status != IPStatus.Success)
                    {
                        HandleFailure();
                    }
                    else
                    {
                        await HandleSuccess();
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
            const string urlPattern = @"^(http|https|ftp)://[a-zA-Z0-9\-\.]+(:[0-9]+)?(/.*)?$";
            const string ipPattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            return Regex.IsMatch(input, urlPattern) || Regex.IsMatch(input, ipPattern);
        }

        static string PrepareInput(string input)
        {
            const string ipPattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(2 5[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            string inputWithoutScheme = Regex.Replace(input, @"^(http|https|ftp)://", "");

            if (Regex.IsMatch(inputWithoutScheme, ipPattern))
            {
                return input.StartsWith("http") ? input : "http://" + inputWithoutScheme;
            }

            if (!Regex.IsMatch(input, @"^(http|https|ftp)://"))
            {
                return "http://" + input;
            }

            return input;
        }

        private async Task HandleSuccess()
        {
            if (pingRetryCount > options.RetryCount) pingRetryCount = 0;

            if (unreachableDialogShown)
            {
                _logger.Information($"Connected to '{options.Url}'.");
                Enabled = true;
                unreachableDialog?.Hide();
                unreachableDialogShown = false;

                var response = await browser.EvaluateScriptAsync("document.body.innerHTML");
                if (response.Success && response.Result != null)
                {
                    var bodyContent = response.Result.ToString();
                    if (string.IsNullOrWhiteSpace(bodyContent) || bodyContent.Contains("404"))
                    {
                        BeginInvoke(new Action(() =>
                        {
                            browser.Reload();
                            pingRetryCount++;
                        }));
                    }
                    else
                    {
                        BeginInvoke(new Action(() => pingRetryCount = 0));
                    }
                }
            }
        }

        private void HandleFailure()
        {
            if (!unreachableDialogShown)
            {
                _logger.Warning($"Disconnected from '{options.Url}'. Refreshing interval is set to {options.RefreshInterval}");
                Enabled = false;
                unreachableDialog = unreachableDialog ?? new WebsiteUnreachableDialog();
                unreachableDialog.Show();
                unreachableDialogShown = true;
            }

            checkUrlTimer.Enabled = true;
        }

        private void InitializeChromium()
        {
            var settings = new CefSettings
            {
                IgnoreCertificateErrors = true,
                LogSeverity = LogSeverity.Error
            };
            settings.CefCommandLineArgs.Add("touch-events", "enabled");
            settings.CefCommandLineArgs.Add("disable-usb-keyboard-detect", "1");
            Cef.Initialize(settings);

            browser = new ChromiumWebBrowser(options.Url)
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(browser);

            browser.MenuHandler = new CustomContextMenuHandler();
            browser.JavascriptMessageReceived += OnJavascriptMessageReceived;
            browser.LoadingStateChanged += OnLoadingStateChanged;
        }

        private void StartTabTipIfNotRunning()
        {
            Process.Start("osk.exe");
        }

        private void OnJavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
            dynamic message = e.Message;

            if (message.type == "single-click-or-tap")
            {
                var unreachdia = new WebsiteUnreachableDialog("Dialog nastavení")
                {
                    TopMost = true
                };
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
                const string clickScript = @"
                    document.addEventListener('click', function(event) {
                        const rect = { left: 10, top: 10, width: 50, height: 50 };
                        const x = event.clientX;
                        const y = event.clientY;

                        if(x >= rect.left && x <= rect.left + rect.width && y >= rect.top && y <= rect.top + rect.height) {
                            CefSharp.PostMessage({ type: 'single-click-or-tap', x: x, y: y });
                        }
                    });
                ";
                browser.ExecuteScriptAsync(clickScript);

                const string formElementScript = @"
                    Array.from(document.querySelectorAll('input, textarea')).forEach(function(element) {
                        element.addEventListener('click', function() {
                            var elementType = element.tagName.toLowerCase();
                            if (element.type) {
                                elementType += ':' + element.type.toLowerCase();
                            }
                            CefSharp.PostMessage({ 
                                type: 'element-click', 
                                elementType: elementType, 
                                value: element.value || '' 
                            });
                        });
                    });
                ";
                browser.ExecuteScriptAsync(formElementScript);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(Cef.Shutdown));
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _logger.Information("The form has been closed. Reason: {closeReason}", e.CloseReason);
        }
    }

   
}
