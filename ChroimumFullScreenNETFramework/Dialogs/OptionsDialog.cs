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
        const string processName = "osk";
        Process oskProcess = Process.GetProcessesByName(processName).FirstOrDefault();

        private bool _useCredentials;
        public Options Options { get; set; }


        public OptionsDialog(Options options)
        {
            Options = options;
            _useCredentials = options.UseCredentials;
            InitializeComponent();
        }

        private void VisualiseOptions()
        {
            textBoxUrlInput.Text = Options.Url;
            textBoxIntervalInput.Text = Options.RefreshInterval.ToString();
            textBoxUsernameInput.Text = Options.Username;
            textBoxPasswordInput.Text = Options.Password;
            textBoxUsernameElementId.Text = Options.UsernameElementId;
            textBoxPasswordElementId.Text = Options.PasswordElementId;
            textBoxLoginButtonContentInput.Text = Options.LoginButtonContent;
            ToggleLoginCredentials(Options.UseCredentials);
        }

        private void ToggleLoginCredentials(bool on)
        {
            if (on)
            {
                Width = 667;
                buttonToggleLogin.Text = "Automatické přihlášení: aktivní";
                buttonToggleLogin.ForeColor = Color.Lime;
            }

            else
            {
                Width = 282;
                buttonToggleLogin.Text = "Automatické přihlášení: neaktivní";
                buttonToggleLogin.ForeColor = Color.Tomato;
            }
        }

        private void ReopenWindowsKeyboard()
        {
            if (oskProcess != null)
            {
                try
                {
                    oskProcess.Kill();
                    Process.Start(processName);
                }
                catch { }
            }
            else
            {
                Process.Start(processName);
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

        private void textBoxUsernameInput_Click(object sender, EventArgs e)
        {
            ReopenWindowsKeyboard();
        }

        private void textBoxPasswordInput_Click(object sender, EventArgs e)
        {
            ReopenWindowsKeyboard();
        }

        private void textBoxLoginButtonContentInput_Click(object sender, EventArgs e)
        {
            ReopenWindowsKeyboard();
        }

        private void buttonToggleLogin_Click(object sender, EventArgs e)
        {
            _useCredentials = !_useCredentials;
            ToggleLoginCredentials(_useCredentials);
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            VisualiseOptions();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Options.Url = textBoxUrlInput.Text;

            try
            {
                Options.RefreshInterval = Convert.ToInt32(textBoxIntervalInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Interval obnovy musí být číselná hodnota!", ex.Message);
            }

            Options.UseCredentials = _useCredentials;
            Options.Username = textBoxUsernameInput.Text;
            Options.Password = textBoxPasswordInput.Text;
            Options.LoginButtonContent = textBoxLoginButtonContentInput.Text;
            Options.UsernameElementId = textBoxUsernameElementId.Text;
            Options.PasswordElementId = textBoxPasswordElementId.Text;
        }
    }
}
