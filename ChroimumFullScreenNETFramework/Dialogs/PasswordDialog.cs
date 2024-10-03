using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ChroimumFullScreenNETFramework.Dialogs
{
    public partial class PasswordDialog : Form
    {
        public PasswordDialog(string title)
        {
            InitializeComponent();
            label1.Text = title ?? "Heslo";
        }

        private void ReopenWindowsKeyboard()
        {
            //bool isOskRunning = false;
            //Process[] processes = Process.GetProcessesByName("osk");
            //if (processes.Length > 0)
            //{
            //    isOskRunning = true;
            //}

            //// If OSK is not running, start it
            //if (!isOskRunning)
            //{
            //    Process.Start("osk.exe");
            //}

            // Zkontrolujte, zda TabTip.exe běží
            var tabTipProcesses = Process.GetProcessesByName("TabTip");

            // Pokud je spuštěný, ukončete ho
            foreach (var process in tabTipProcesses)
            {
                process.Kill();
                process.WaitForExit(); // Počkejte, dokud se proces úplně neukončí
            }

            // Cesta k TabTip.exe
            string tabTipPath = @"C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe";

            // Spuštění procesu TabTip.exe
            Process.Start(tabTipPath);
        }

        private void textBoxUrlInput_Click(object sender, EventArgs e)
        {
            ReopenWindowsKeyboard();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(textBoxPasswordInput.Text == "1622")
            {
                DialogResult = DialogResult.Yes;
                Close();
            }

            else
            {
                MessageBox.Show("Zadané heslo není správné.", "Nesprávné heslo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
