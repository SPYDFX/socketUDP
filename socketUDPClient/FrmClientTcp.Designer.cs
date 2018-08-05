namespace socketUDPClient
{
    partial class FrmClientTcp
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
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.plHeader = new System.Windows.Forms.Panel();
            this.lblFriendName = new System.Windows.Forms.Label();
            this.lblChatName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lstMsg = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnShake = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSelectImg = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picSelectedImg = new System.Windows.Forms.PictureBox();
            this.btnHandImg = new System.Windows.Forms.Button();
            this.plHandImg = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.plHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedImg)).BeginInit();
            this.plHandImg.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.BackColor = System.Drawing.Color.White;
            this.txtSendMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSendMsg.Location = new System.Drawing.Point(14, 460);
            this.txtSendMsg.Margin = new System.Windows.Forms.Padding(4);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(602, 70);
            this.txtSendMsg.TabIndex = 14;
            this.txtSendMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSend_KeyDown);
            // 
            // plHeader
            // 
            this.plHeader.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.plHeader.Controls.Add(this.lblFriendName);
            this.plHeader.Controls.Add(this.lblChatName);
            this.plHeader.Controls.Add(this.btnClose);
            this.plHeader.Controls.Add(this.btnMin);
            this.plHeader.Location = new System.Drawing.Point(0, 0);
            this.plHeader.Name = "plHeader";
            this.plHeader.Size = new System.Drawing.Size(800, 50);
            this.plHeader.TabIndex = 18;
            this.plHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plHeader_MouseDown);
            this.plHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.plHeader_MouseMove);
            // 
            // lblFriendName
            // 
            this.lblFriendName.AutoSize = true;
            this.lblFriendName.Location = new System.Drawing.Point(320, 15);
            this.lblFriendName.Name = "lblFriendName";
            this.lblFriendName.Size = new System.Drawing.Size(0, 18);
            this.lblFriendName.TabIndex = 10;
            // 
            // lblChatName
            // 
            this.lblChatName.AutoSize = true;
            this.lblChatName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChatName.ForeColor = System.Drawing.Color.White;
            this.lblChatName.Location = new System.Drawing.Point(303, 10);
            this.lblChatName.Name = "lblChatName";
            this.lblChatName.Size = new System.Drawing.Size(0, 24);
            this.lblChatName.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::socketUDPClient.Properties.Resources.close3;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(746, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 50);
            this.btnClose.TabIndex = 8;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.BackgroundImage = global::socketUDPClient.Properties.Resources.min2;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Location = new System.Drawing.Point(684, 0);
            this.btnMin.Margin = new System.Windows.Forms.Padding(4);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(48, 50);
            this.btnMin.TabIndex = 7;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel5.Location = new System.Drawing.Point(0, 398);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(626, 2);
            this.panel5.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(372, 538);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "关闭(C)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstMsg
            // 
            this.lstMsg.BackColor = System.Drawing.Color.White;
            this.lstMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMsg.FormattingEnabled = true;
            this.lstMsg.ItemHeight = 18;
            this.lstMsg.Location = new System.Drawing.Point(3, 58);
            this.lstMsg.Margin = new System.Windows.Forms.Padding(4);
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.Size = new System.Drawing.Size(612, 306);
            this.lstMsg.TabIndex = 15;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(506, 538);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(112, 40);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "发送(S)";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            this.btnSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSend_KeyDown);
            this.btnSend.MouseHover += new System.EventHandler(this.btnSend_MouseHover);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnShake);
            this.panel3.Controls.Add(this.btnSelectFile);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.btnSelectImg);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(0, 405);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(622, 42);
            this.panel3.TabIndex = 20;
            // 
            // btnShake
            // 
            this.btnShake.BackgroundImage = global::socketUDPClient.Properties.Resources.shake;
            this.btnShake.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShake.FlatAppearance.BorderSize = 0;
            this.btnShake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShake.Location = new System.Drawing.Point(268, 3);
            this.btnShake.Name = "btnShake";
            this.btnShake.Size = new System.Drawing.Size(34, 34);
            this.btnShake.TabIndex = 4;
            this.btnShake.UseVisualStyleBackColor = true;
            this.btnShake.Click += new System.EventHandler(this.btnShake_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.BackgroundImage = global::socketUDPClient.Properties.Resources.wenjian;
            this.btnSelectFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelectFile.FlatAppearance.BorderSize = 0;
            this.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFile.Location = new System.Drawing.Point(142, 3);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(34, 34);
            this.btnSelectFile.TabIndex = 3;
            this.btnSelectFile.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::socketUDPClient.Properties.Resources.jianqie;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(82, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 34);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnSelectImg
            // 
            this.btnSelectImg.BackgroundImage = global::socketUDPClient.Properties.Resources.pic;
            this.btnSelectImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelectImg.FlatAppearance.BorderSize = 0;
            this.btnSelectImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectImg.Location = new System.Drawing.Point(208, 3);
            this.btnSelectImg.Name = "btnSelectImg";
            this.btnSelectImg.Size = new System.Drawing.Size(34, 34);
            this.btnSelectImg.TabIndex = 1;
            this.btnSelectImg.UseVisualStyleBackColor = true;
            this.btnSelectImg.Click += new System.EventHandler(this.btnSelectImg_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::socketUDPClient.Properties.Resources.bq;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(27, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 34);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Location = new System.Drawing.Point(626, 51);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 536);
            this.panel2.TabIndex = 19;
            // 
            // picSelectedImg
            // 
            this.picSelectedImg.Location = new System.Drawing.Point(6, 57);
            this.picSelectedImg.Margin = new System.Windows.Forms.Padding(4);
            this.picSelectedImg.Name = "picSelectedImg";
            this.picSelectedImg.Size = new System.Drawing.Size(116, 87);
            this.picSelectedImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectedImg.TabIndex = 21;
            this.picSelectedImg.TabStop = false;
            // 
            // btnHandImg
            // 
            this.btnHandImg.FlatAppearance.BorderSize = 0;
            this.btnHandImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHandImg.Location = new System.Drawing.Point(6, 152);
            this.btnHandImg.Margin = new System.Windows.Forms.Padding(4);
            this.btnHandImg.Name = "btnHandImg";
            this.btnHandImg.Size = new System.Drawing.Size(114, 34);
            this.btnHandImg.TabIndex = 22;
            this.btnHandImg.Text = "删除";
            this.btnHandImg.UseVisualStyleBackColor = true;
            this.btnHandImg.Click += new System.EventHandler(this.btnHandImg_Click);
            // 
            // plHandImg
            // 
            this.plHandImg.Controls.Add(this.lblFileName);
            this.plHandImg.Controls.Add(this.btnSave);
            this.plHandImg.Controls.Add(this.lblTitle);
            this.plHandImg.Controls.Add(this.picSelectedImg);
            this.plHandImg.Controls.Add(this.btnHandImg);
            this.plHandImg.Location = new System.Drawing.Point(636, 51);
            this.plHandImg.Margin = new System.Windows.Forms.Padding(4);
            this.plHandImg.Name = "plHandImg";
            this.plHandImg.Size = new System.Drawing.Size(164, 236);
            this.plHandImg.TabIndex = 23;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(4, 7);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(98, 18);
            this.lblTitle.TabIndex = 23;
            this.lblTitle.Text = "已选图片：";
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(4, 191);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 34);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "另存为";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(4, 35);
            this.lblFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(62, 18);
            this.lblFileName.TabIndex = 25;
            this.lblFileName.Text = "文件名";
            // 
            // FrmClientTcp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 585);
            this.Controls.Add(this.plHandImg);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.plHeader);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstMsg);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmClientTcp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmClientTcp";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmClientTcp_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmClientTcp_MouseMove);
            this.plHeader.ResumeLayout(false);
            this.plHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedImg)).EndInit();
            this.plHandImg.ResumeLayout(false);
            this.plHandImg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.Panel plHeader;
        private System.Windows.Forms.Label lblChatName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnSelectImg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFriendName;
        private System.Windows.Forms.Button btnShake;
        private System.Windows.Forms.PictureBox picSelectedImg;
        private System.Windows.Forms.Button btnHandImg;
        private System.Windows.Forms.Panel plHandImg;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFileName;
    }
}