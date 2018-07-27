using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socketUDPClient
{
    public partial class Form1 : Form
    {
        private int startX, startY;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUname.Text)&&!string.IsNullOrWhiteSpace(txtPwd.Text.Trim()))
            {

                this.Hide();
                FrmClient client = new FrmClient(txtUname.Text.Trim());
                client.Show();
                client.Closed += (s, args) => this.Close();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - startX;
                this.Top += e.Y - startY;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startX = e.X;
                startY = e.Y;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - startX;
                this.Top += e.Y - startY;
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startX = e.X;
                startY = e.Y;
            }
        }
    }
}
