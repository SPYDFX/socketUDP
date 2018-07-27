namespace socketUDPClient
{
    partial class FrmUserList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserList));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "headimg.jpg");
            this.imageList1.Images.SetKeyName(1, "headimg.jpg");
            this.imageList1.Images.SetKeyName(2, "headimg.jpg");
            this.imageList1.Images.SetKeyName(3, "headimg.jpg");
            this.imageList1.Images.SetKeyName(4, "headimg.jpg");
            this.imageList1.Images.SetKeyName(5, "headimg.jpg");
            this.imageList1.Images.SetKeyName(6, "headimg.jpg");
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(37, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 14);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "搜索";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(0, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 35);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::socketUDPClient.Properties.Resources.search;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(11, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 17);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
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
            this.btnMin.Location = new System.Drawing.Point(179, -1);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(32, 33);
            this.btnMin.TabIndex = 3;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
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
            this.btnClose.Location = new System.Drawing.Point(217, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 33);
            this.btnClose.TabIndex = 4;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(0, 200);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(255, 332);
            this.panel2.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 33);
            this.button2.TabIndex = 7;
            this.button2.Text = "在线用户";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Silver;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(127, 167);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 33);
            this.button3.TabIndex = 8;
            this.button3.Text = "离线用户";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(25, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 52);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUserName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(118, 44);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(93, 16);
            this.lblUserName.TabIndex = 10;
            this.lblUserName.Text = "三片叶的风";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel3.Location = new System.Drawing.Point(0, 529);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 39);
            this.panel3.TabIndex = 11;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // FrmUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BackgroundImage = global::socketUDPClient.Properties.Resources.Jellyfish;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(255, 568);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUserList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUserList";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmUserList_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmUserList_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel panel3;
    }
}