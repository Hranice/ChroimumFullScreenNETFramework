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


        public OptionsDialog()
        {
            InitializeComponent();
        }

        private void textBoxUrlInput_Click(object sender, EventArgs e)
        {
            ReopenWindowsKeyboard();
        }

        private void textBoxIntervalInput_Click(object sender, EventArgs e)
        {
            ReopenWindowsKeyboard();
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
    }
}
