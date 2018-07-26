using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socketUDPClient
{
    public partial class FrmUserList : Form
    {
        private int startX, startY;
        public FrmUserList()
        {
            InitializeComponent();
            
            ListView list = new ListViewEx();
            list.View =View.Tile;

            this.Controls.Add(list);
            list.BeginUpdate();
            //imageList1.ImageSize = new Size(1,20);
            list.LargeImageList = imageList1;

            list.SmallImageList = imageList1;
            //list.Size = new Size(100, 100);
            //list.Location = new Point(300, 100);
            for (int i = 0; i < 15; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.ImageIndex = i;
                lvi.Text = "item" + i;
                
                list.Items.Add(lvi);
            }
            list.BorderStyle = BorderStyle.None;
            list.FullRowSelect = true;
            list.Dock = DockStyle.Fill;
            list.Parent = panel2;
            list.EndUpdate();
        }

        private void FrmUserList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startX = e.X;
                startY = e.Y;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmUserList_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - startX;
                this.Top += e.Y - startY;
            }
        }
    }
}
