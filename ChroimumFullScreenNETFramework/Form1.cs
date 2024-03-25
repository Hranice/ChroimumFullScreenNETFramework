using CefSharp;
using CefSharp.WinForms;
using ChroimumFullScreenNETFramework.Dialogs;
using ChroimumFullScreenNETFramework.Models;
using Serilog;
using System;
using System.Net;
using System.Net.NetworkInformation;
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

            if (optionsDialog.ShowDialog() == DialogResult.OK)
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