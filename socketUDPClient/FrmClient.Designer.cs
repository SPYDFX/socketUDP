namespace socketUDPClient
{
    partial class FrmClient
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.lstMsg = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(566, 440);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(112, 34);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(132, 339);
            this.txtSendMsg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(544, 90);
            this.txtSendMsg.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstUser);
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 449);
            this.panel1.TabIndex = 2;
            // 
            // lstUser
            // 
            this.lstUser.FormattingEnabled = true;
            this.lstUser.ItemHeight = 18;
            this.lstUser.Location = new System.Drawing.Point(4, 4);
            this.lstUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(109, 436);
            this.lstUser.TabIndex = 0;
            // 
            // lstMsg
            // 
            this.lstMsg.FormattingEnabled = true;
            this.lstMsg.ItemHeight = 18;
            this.lstMsg.Location = new System.Drawing.Point(132, 18);
            this.lstMsg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.Size = new System.Drawing.Size(544, 310);
            this.lstMsg.TabIndex = 3;
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 492);
            this.Controls.Add(this.lstMsg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.btnSend);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmClient";
            this.Text = "FrmClient";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstMsg;
        private System.Windows.Forms.ListBox lstUser;
    }
}