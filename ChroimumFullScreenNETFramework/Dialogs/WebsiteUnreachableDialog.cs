using ChroimumFullScreenNETFramework.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChroimumFullScreenNETFramework.Dialogs
{
    public partial class WebsiteUnreachableDialog : Form
    {
        private Options options;

        public WebsiteUnreachableDialog()
        {
            InitializeComponent();

            Options.OnChange += Options_OnChange;
            options = Options.Load();
        }

        private void Options_OnChange(object sender, EventArgs e)
        {
            ReloadOptions();
        }

        private void ReloadOptions()
        {
            options = Options.Load();
        }

        private void WebsiteUnreachableDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            OpenOptionsDialog();
        }

        private void OpenOptionsDialog()
        {
            var optionsDialog = new OptionsDialog();
            optionsDialog.textBoxUrlInput.Text = options.Url;
            optionsDialog.textBoxIntervalInput.Text = options.RefreshInterval.ToString();

            if (optionsDialog.ShowDialog() == DialogResult.OK)
            {
                options = new Options()
                {
                    Url = optionsDialog.textBoxUrlInput.Text,
                };

                Int32.TryParse(optionsDialog.textBoxIntervalInput.Text, out int interval);
                options = new Options()
                {
                    Url = optionsDialog.textBoxUrlInput.Text,
                    RefreshInterval = interval
                };

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

        private void label4_Click(object sender, EventArgs e)
        {
            Restart();
        }
    }
}
