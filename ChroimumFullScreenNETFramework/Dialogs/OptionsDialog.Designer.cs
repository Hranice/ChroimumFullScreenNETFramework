namespace ChroimumFullScreenNETFramework.Dialogs
{
    partial class OptionsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxUrlInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxIntervalInput = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUsernameInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPasswordInput = new System.Windows.Forms.TextBox();
            this.buttonToggleLogin = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxLoginButtonContentInput = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPasswordElementId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxUsernameElementId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxLoginClickDelay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxUrlInput
            // 
            this.textBoxUrlInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxUrlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUrlInput.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxUrlInput.ForeColor = System.Drawing.Color.White;
            this.textBoxUrlInput.Location = new System.Drawing.Point(13, 36);
            this.textBoxUrlInput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUrlInput.Name = "textBoxUrlInput";
            this.textBoxUrlInput.Size = new System.Drawing.Size(251, 33);
            this.textBoxUrlInput.TabIndex = 0;
            this.textBoxUrlInput.Click += new System.EventHandler(this.textBoxUrlInput_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(9, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Interval kontroly připojení:";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(16)))));
            this.buttonSave.Location = new System.Drawing.Point(12, 223);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(159, 34);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Uložit";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxIntervalInput
            // 
            this.textBoxIntervalInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxIntervalInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxIntervalInput.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.textBoxIntervalInput.ForeColor = System.Drawing.Color.White;
            this.textBoxIntervalInput.Location = new System.Drawing.Point(13, 109);
            this.textBoxIntervalInput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIntervalInput.Name = "textBoxIntervalInput";
            this.textBoxIntervalInput.Size = new System.Drawing.Size(158, 33);
            this.textBoxIntervalInput.TabIndex = 8;
            this.textBoxIntervalInput.Text = "1000";
            this.textBoxIntervalInput.Click += new System.EventHandler(this.textBoxIntervalInput_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.Location = new System.Drawing.Point(177, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 34);
            this.button2.TabIndex = 9;
            this.button2.Text = "Zrušit";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(178, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "ms";
            // 
            // textBoxUsernameInput
            // 
            this.textBoxUsernameInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxUsernameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUsernameInput.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.textBoxUsernameInput.ForeColor = System.Drawing.Color.White;
            this.textBoxUsernameInput.Location = new System.Drawing.Point(305, 36);
            this.textBoxUsernameInput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUsernameInput.Name = "textBoxUsernameInput";
            this.textBoxUsernameInput.Size = new System.Drawing.Size(158, 33);
            this.textBoxUsernameInput.TabIndex = 11;
            this.textBoxUsernameInput.Click += new System.EventHandler(this.textBoxUsernameInput_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(301, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Přihlašovací jméno:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(299, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Heslo:";
            // 
            // textBoxPasswordInput
            // 
            this.textBoxPasswordInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxPasswordInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPasswordInput.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.textBoxPasswordInput.ForeColor = System.Drawing.Color.White;
            this.textBoxPasswordInput.Location = new System.Drawing.Point(303, 109);
            this.textBoxPasswordInput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPasswordInput.Name = "textBoxPasswordInput";
            this.textBoxPasswordInput.Size = new System.Drawing.Size(158, 33);
            this.textBoxPasswordInput.TabIndex = 13;
            this.textBoxPasswordInput.Click += new System.EventHandler(this.textBoxPasswordInput_Click);
            // 
            // buttonToggleLogin
            // 
            this.buttonToggleLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToggleLogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonToggleLogin.Location = new System.Drawing.Point(12, 166);
            this.buttonToggleLogin.Name = "buttonToggleLogin";
            this.buttonToggleLogin.Size = new System.Drawing.Size(252, 51);
            this.buttonToggleLogin.TabIndex = 15;
            this.buttonToggleLogin.Text = "Automatické přihlášení: aktivní";
            this.buttonToggleLogin.UseVisualStyleBackColor = true;
            this.buttonToggleLogin.Click += new System.EventHandler(this.buttonToggleLogin_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(299, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "Text login tlačítka:";
            // 
            // textBoxLoginButtonContentInput
            // 
            this.textBoxLoginButtonContentInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxLoginButtonContentInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLoginButtonContentInput.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.textBoxLoginButtonContentInput.ForeColor = System.Drawing.Color.White;
            this.textBoxLoginButtonContentInput.Location = new System.Drawing.Point(303, 184);
            this.textBoxLoginButtonContentInput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLoginButtonContentInput.Name = "textBoxLoginButtonContentInput";
            this.textBoxLoginButtonContentInput.Size = new System.Drawing.Size(158, 33);
            this.textBoxLoginButtonContentInput.TabIndex = 16;
            this.textBoxLoginButtonContentInput.Click += new System.EventHandler(this.textBoxLoginButtonContentInput_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(282, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 230);
            this.panel1.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(485, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 23);
            this.label8.TabIndex = 22;
            this.label8.Text = "ElementId:";
            // 
            // textBoxPasswordElementId
            // 
            this.textBoxPasswordElementId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxPasswordElementId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPasswordElementId.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.textBoxPasswordElementId.ForeColor = System.Drawing.Color.White;
            this.textBoxPasswordElementId.Location = new System.Drawing.Point(489, 109);
            this.textBoxPasswordElementId.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPasswordElementId.Name = "textBoxPasswordElementId";
            this.textBoxPasswordElementId.Size = new System.Drawing.Size(158, 33);
            this.textBoxPasswordElementId.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(487, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 23);
            this.label9.TabIndex = 20;
            this.label9.Text = "ElementId:";
            // 
            // textBoxUsernameElementId
            // 
            this.textBoxUsernameElementId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxUsernameElementId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUsernameElementId.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.textBoxUsernameElementId.ForeColor = System.Drawing.Color.White;
            this.textBoxUsernameElementId.Location = new System.Drawing.Point(491, 36);
            this.textBoxUsernameElementId.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUsernameElementId.Name = "textBoxUsernameElementId";
            this.textBoxUsernameElementId.Size = new System.Drawing.Size(158, 33);
            this.textBoxUsernameElementId.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(485, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "Delay na stisk:";
            // 
            // textBoxLoginClickDelay
            // 
            this.textBoxLoginClickDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxLoginClickDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLoginClickDelay.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.textBoxLoginClickDelay.ForeColor = System.Drawing.Color.White;
            this.textBoxLoginClickDelay.Location = new System.Drawing.Point(489, 184);
            this.textBoxLoginClickDelay.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLoginClickDelay.Name = "textBoxLoginClickDelay";
            this.textBoxLoginClickDelay.Size = new System.Drawing.Size(158, 33);
            this.textBoxLoginClickDelay.TabIndex = 23;
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(667, 270);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxLoginClickDelay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxPasswordElementId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxUsernameElementId);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxLoginButtonContentInput);
            this.Controls.Add(this.buttonToggleLogin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPasswordInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxUsernameInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxIntervalInput);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUrlInput);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSave;
        public System.Windows.Forms.TextBox textBoxUrlInput;
        public System.Windows.Forms.TextBox textBoxIntervalInput;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxUsernameInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxPasswordInput;
        private System.Windows.Forms.Button buttonToggleLogin;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBoxLoginButtonContentInput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox textBoxPasswordElementId;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBoxUsernameElementId;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textBoxLoginClickDelay;
    }
}