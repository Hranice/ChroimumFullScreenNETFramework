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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxIntervalInput = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
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
            this.textBoxUrlInput.Size = new System.Drawing.Size(247, 33);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(16)))));
            this.button1.Location = new System.Drawing.Point(12, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "Uložit";
            this.button1.UseVisualStyleBackColor = false;
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
            this.button2.Location = new System.Drawing.Point(177, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 34);
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
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(272, 195);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxIntervalInput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUrlInput);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox textBoxUrlInput;
        public System.Windows.Forms.TextBox textBoxIntervalInput;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
    }
}