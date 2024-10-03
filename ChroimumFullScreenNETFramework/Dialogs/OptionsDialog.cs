using ChroimumFullScreenNETFramework.Models;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ChroimumFullScreenNETFramework.Dialogs
{
    public partial class OptionsDialog : Form
    {
        // Import the necessary DLLs for simulating key presses
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        // Virtual-Key codes
        const byte VK_LWIN = 0x5B; // Left Windows key (Natural keyboard)
        const int KEYEVENTF_EXTENDEDKEY = 0x0001; // Key down flag
        const int KEYEVENTF_KEYUP = 0x0002; // Key up flag

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
                return;
            }

            Options.RefreshInterval = interval;
            Options.PingTimeout = pingTimeout;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0);
        }
    }
}
