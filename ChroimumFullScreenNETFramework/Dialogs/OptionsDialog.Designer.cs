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
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPingTimeoutInput = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxRetryCountInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.textBoxUrlInput.Size = new System.Drawing.Size(404, 33);
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
            this.label2.Size = new System.Drawing.Size(139, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Interval obnovy:";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(16)))));
            this.buttonSave.Location = new System.Drawing.Point(12, 157);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(312, 34);
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
            this.textBoxIntervalInput.Size = new System.Drawing.Size(69, 33);
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
            this.button2.Location = new System.Drawing.Point(330, 157);
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
            this.label3.Location = new System.Drawing.Point(89, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "ms";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(231, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 23);
            this.label10.TabIndex = 27;
            this.label10.Text = "ms";
            // 
            // textBoxPingTimeoutInput
            // 
            this.textBoxPingTimeoutInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxPingTimeoutInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPingTimeoutInput.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.textBoxPingTimeoutInput.ForeColor = System.Drawing.Color.White;
            this.textBoxPingTimeoutInput.Location = new System.Drawing.Point(155, 109);
            this.textBoxPingTimeoutInput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPingTimeoutInput.Name = "textBoxPingTimeoutInput";
            this.textBoxPingTimeoutInput.Size = new System.Drawing.Size(69, 33);
            this.textBoxPingTimeoutInput.TabIndex = 26;
            this.textBoxPingTimeoutInput.Text = "1000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(151, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 23);
            this.label11.TabIndex = 25;
            this.label11.Text = "Ping timeout:";
            // 
            // textBoxRetryCountInput
            // 
            this.textBoxRetryCountInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxRetryCountInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRetryCountInput.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.textBoxRetryCountInput.ForeColor = System.Drawing.Color.White;
            this.textBoxRetryCountInput.Location = new System.Drawing.Point(300, 109);
            this.textBoxRetryCountInput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRetryCountInput.Name = "textBoxRetryCountInput";
            this.textBoxRetryCountInput.Size = new System.Drawing.Size(69, 33);
            this.textBoxRetryCountInput.TabIndex = 29;
            this.textBoxRetryCountInput.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(296, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Počet pokusů:";
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(431, 204);
            this.Controls.Add(this.textBoxRetryCountInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxPingTimeoutInput);
            this.Controls.Add(this.label11);
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
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox textBoxPingTimeoutInput;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox textBoxRetryCountInput;
        private System.Windows.Forms.Label label5;
    }
}