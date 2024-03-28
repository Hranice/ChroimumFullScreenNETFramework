using ChroimumFullScreenNETFramework.Models;
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
    public partial class OptionsDialog : Form
    {
        public Options Options { get; set; }


        public OptionsDialog(Options options)
        {
            Options = options;
            InitializeComponent();
        }

        private void VisualiseOptions()
        {
            textBoxUrlInput.Text = Options.Url;
            textBoxIntervalInput.Text = Options.RefreshInterval.ToString();
            textBoxPingTimeoutInput.Text = Options.PingTimeout.ToString();
            textBoxRetryCountInput.Text = Options.RetryCount.ToString();
        }

        private void ReopenWindowsKeyboard()
        {
            bool isOskRunning = false;
            Process[] processes = Process.GetProcessesByName("osk");
            if (processes.Length > 0)
            {
                isOskRunning = true;
            }

            // If OSK is not running, start it
            if (!isOskRunning)
            {
                Process.Start("osk.exe");
            }
        }

        private void textBoxUrlInput_Click(object sender, EventArgs e)
        {
            ReopenWindowsKeyboard();
        }

        private void textBoxIntervalInput_Click(object sender, EventArgs e)
        {
            ReopenWindowsKeyboard();
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            VisualiseOptions();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Options.Url = textBoxUrlInput.Text.Trim();

            // Attempt to parse the refresh interval from the textBox
            if (!int.TryParse(textBoxIntervalInput.Text, out int interval))
            {
                MessageBox.Show("The Refresh Interval must be a numeric value!", "Input Error");
                return;
            }

            // Attempt to parse the ping timeout from the textBox
            if (!int.TryParse(textBoxPingTimeoutInput.Text, out int pingTimeout))
            {
                MessageBox.Show("The Ping Timeout must be a numeric value!", "Input Error");
                return;            }

            // Attempt to parse the retry count from the textBox
            if (!int.TryParse(textBoxRetryCountInput.Text, out int retryCount))
            {
                MessageBox.Show("The Retry Count must be a numeric value!", "Input Error");
                return;
            }

            Options.RefreshInterval = interval;
            Options.PingTimeout = pingTimeout;
            Options.RetryCount = retryCount;
        }
    }
}
