namespace socketUDPClient
{
    partial class TestFrmUersList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.plUserList = new System.Windows.Forms.Panel();
            this.btnOnLineUserList = new System.Windows.Forms.Button();
            this.btnOffLineUserList = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Location = new System.Drawing.Point(0, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 51);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Location = new System.Drawing.Point(0, 664);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 51);
            this.panel2.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(157, 52);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(85, 24);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "用户名";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::socketUDPClient.Properties.Resources.close3;
            this.btnClose.Location = new System.Drawing.Point(302, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 49);
            this.btnClose.TabIndex = 5;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // plUserList
            // 
            this.plUserList.Location = new System.Drawing.Point(-2, 237);
            this.plUserList.Name = "plUserList";
            this.plUserList.Size = new System.Drawing.Size(351, 421);
            this.plUserList.TabIndex = 6;
            // 
            // btnOnLineUserList
            // 
            this.btnOnLineUserList.FlatAppearance.BorderSize = 0;
            this.btnOnLineUserList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnLineUserList.Location = new System.Drawing.Point(0, 190);
            this.btnOnLineUserList.Name = "btnOnLineUserList";
            this.btnOnLineUserList.Size = new System.Drawing.Size(175, 40);
            this.btnOnLineUserList.TabIndex = 7;
            this.btnOnLineUserList.Text = "在线用户";
            this.btnOnLineUserList.UseVisualStyleBackColor = true;
            this.btnOnLineUserList.Click += new System.EventHandler(this.btnOnLineUserList_Click);
            // 
            // btnOffLineUserList
            // 
            this.btnOffLineUserList.FlatAppearance.BorderSize = 0;
            this.btnOffLineUserList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOffLineUserList.Location = new System.Drawing.Point(177, 190);
            this.btnOffLineUserList.Name = "btnOffLineUserList";
            this.btnOffLineUserList.Size = new System.Drawing.Size(175, 40);
            this.btnOffLineUserList.TabIndex = 8;
            this.btnOffLineUserList.Text = "离线用户";
            this.btnOffLineUserList.UseVisualStyleBackColor = true;
            this.btnOffLineUserList.Click += new System.EventHandler(this.btnOffLineUserList_Click);
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Image = global::socketUDPClient.Properties.Resources.min2;
            this.btnMin.Location = new System.Drawing.Point(235, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(47, 49);
            this.btnMin.TabIndex = 4;
            this.btnMin.UseVisualStyleBackColor = false;
            // 
            // picUser
            // 
            this.picUser.BackColor = System.Drawing.Color.Transparent;
            this.picUser.BackgroundImage = global::socketUDPClient.Properties.Resources.hz;
            this.picUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picUser.Location = new System.Drawing.Point(31, 24);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(81, 78);
            this.picUser.TabIndex = 2;
            this.picUser.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::socketUDPClient.Properties.Resources.search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(14, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(29, 25);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(65, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "搜索";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel3.Location = new System.Drawing.Point(176, 191);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 40);
            this.panel3.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TestFrmUersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::socketUDPClient.Properties.Resources.微信图片_20170517223918;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(351, 716);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnOffLineUserList);
            this.Controls.Add(this.btnOnLineUserList);
            this.Controls.Add(this.plUserList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestFrmUersList";
            this.Text = "TestFrmUersList";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel plUserList;
        private System.Windows.Forms.Button btnOnLineUserList;
        private System.Windows.Forms.Button btnOffLineUserList;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ImageList imageList1;
    }
}