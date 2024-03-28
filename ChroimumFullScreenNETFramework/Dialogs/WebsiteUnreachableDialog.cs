using ChroimumFullScreenNETFramework.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChroimumFullScreenNETFramework.Dialogs
{
    public partial class WebsiteUnreachableDialog : Form
    {
        // Import the necessary DLLs for simulating key presses
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        // Virtual-Key codes
        const byte VK_LWIN = 0x5B; // Left Windows key (Natural keyboard)
        const int KEYEVENTF_EXTENDEDKEY = 0x0001; // Key down flag
        const int KEYEVENTF_KEYUP = 0x0002; // Key up flag


        private Options options;

        public WebsiteUnreachableDialog(string defaultMessage = null)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(defaultMessage))
            {
                label1.Text = defaultMessage;
                label4.Text = "Zpět";
            }

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
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Enabled = false;
            TopMost = false;
            OpenOptionsDialog();
            TopMost = true;
            Enabled = true;
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
                ReloadOptions();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (label4.Text == "Zpět")
            {
                Close();
            }
            else
            {
                keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
