using CefSharp;
using CefSharp.DevTools.Page;
using CefSharp.WinForms;
using ChroimumFullScreenNETFramework.Dialogs;
using ChroimumFullScreenNETFramework.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ChroimumFullScreenNETFramework
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser browser;
        private Timer checkUrlTimer;
        private WebsiteUnreachableDialog unreachableDialog;
        private bool unreachableDialogShown;

        private static Ping _ping;
        private HttpClient httpClient;
        private bool isCheckingUrl = false;
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

            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMilliseconds(1000);

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

                Restart();
            }
        }

        private void Restart()
        {
            string currentAppName = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentAppName);
            Environment.Exit(0);
        }

        private void MakeFormFullscreen()
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void SetupTimer()
        {
            checkUrlTimer = new Timer();
            checkUrlTimer.Interval = options.RefreshInterval;
            checkUrlTimer.Tick += CheckUrlAccessibility;
            checkUrlTimer.Start();
        }

        private async void CheckUrlAccessibility(object sender, EventArgs e)
        {
            try
            {
                PingReply reply = await _ping.SendPingAsync(options.Url.Split(':')[0]);
                if (reply.Status != IPStatus.Success)
                {
                    HandleFailure();
                }

                else
                {
                    HandleSuccess();
                }
            }
            catch
            {
                HandleFailure();
            }
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
            settings.LogSeverity = LogSeverity.Error;
            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser(options.Url);
            browser.LoadingStateChanged += Browser_LoadingStateChanged;
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            Login();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cef.Shutdown();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            unreachableDialog = new WebsiteUnreachableDialog();
            //unreachableDialog.TopMost = true;
        }

        private async void Login()
        {
            try
            {
                await browser.EvaluateScriptAsync($"document.getElementById('{options.UsernameElementId}').value = '{options.Username}';");
                await browser.EvaluateScriptAsync($"document.getElementById('{options.PasswordElementId}').value = '{options.Password}';");


                string script = $@"
(function() {{
    var buttons = document.getElementsByTagName('button');
    var targetText = '{options.LoginButtonContent}';
    for (var i = 0; i < buttons.length; i++) {{
        if (buttons[i].textContent == targetText) {{
            buttons[i].click();
            break; // Remove this if you want to click all buttons with the specified text
        }}
    }}
}})();";

                await browser.EvaluateScriptAsync(script);

            }
            catch (Exception ex)
            {
                _logger.Error($"An exception has occurred. {ex}");
            }
        }
    }
}
