using model;
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
        UserBLL bll = new UserBLL();
        private int startX, startY;
        private string account;
        private List<UserInfo> onLineUserList;
        private List<UserInfo> offLineUserList;
        public FrmUserList(string account)
        {
            InitializeComponent();
            this.account = account;
            InitializeBaseInfo();
            InitializeUserList();
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmUserList_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - startX;
                this.Top += e.Y - startY;
            }
        }
        private void InitializeBaseInfo()
        {
            var userInfo = bll.GetUserInfo(this.account);
            lblUserName.Text = userInfo.userName;
        }
        private void InitializeUserList()
        {
            var ulist = bll.GetUserList();
            onLineUserList = ulist.Where(u => u.onLine == 1).ToList();
            offLineUserList= ulist.Where(u => u.onLine == 0).ToList();
            if(onLineUserList!=null&& onLineUserList.Count>0)
            {
                ListView list = new ListViewEx();
                list.View = View.Tile;
                list.BeginUpdate();
                list.LargeImageList = imageList1;
                list.BackColor = Color.White;
                list.SmallImageList = imageList1;
                foreach (var u in onLineUserList)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = 1;
                    lvi.Text = u.userName;
                    list.Items.Add(lvi);
                }
                list.BorderStyle = BorderStyle.None;
                list.FullRowSelect = true;
                list.Dock = DockStyle.Fill;
                list.Parent = panel2;
                list.EndUpdate();

            }
        }
    }
}
