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
        private ListView listOnLine;
        private ListView listOffLine;
        private Dictionary<string, Form> dicChatFrm = new Dictionary<string, Form>();

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
            offLineUserList = ulist.Where(u => u.onLine == 0).ToList();

            if (onLineUserList != null && onLineUserList.Count > 0)
            {
                listOnLine = new ListViewEx();
                UserListDisplay(onLineUserList, listOnLine);
            }
            if (offLineUserList != null && offLineUserList.Count > 0)
            {
                listOffLine = new ListViewEx();
                UserListDisplay(offLineUserList, listOffLine);
            }
            listOnLine.Visible = true;
            listOffLine.Visible = false;
        }

        private void btnOnLineUserList_Click(object sender, EventArgs e)
        {
            listOnLine.Visible = true;
            listOffLine.Visible = false;
        }

        private void btnOffLineUserList_Click(object sender, EventArgs e)
        {
            listOnLine.Visible = false;
            listOffLine.Visible = true;
        }

        public void UserListDisplay(List<UserInfo> userList, ListView list)
        {
            if (userList != null && userList.Count > 0)
            {
                list.View = View.Tile;
                list.BeginUpdate();
                list.LargeImageList = imageList1;
                list.BackColor = Color.White;
                list.SmallImageList = imageList1;
                foreach (var u in userList)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = 1;
                    lvi.Text = u.userName+"-"+u.userAccount;
                   
                    list.Items.Add(lvi);

                }
                list.BorderStyle = BorderStyle.None;
                list.FullRowSelect = true;
                list.Parent = panel2;
                list.Dock = DockStyle.Fill;
                list.EndUpdate();
                list.MouseUp += new MouseEventHandler(MouseEvent);
            }
        }

        private void MouseEvent(object sender, MouseEventArgs e)
        {
            if(listOnLine.Visible)
            {
                if (listOnLine.SelectedItems.Count > 0)
                {
                    var txt = listOnLine.SelectedItems[0].Text;
                    // MessageBox.Show(txt);
                    var cName = txt.Split('-').ToList()[0];
                    var accout = txt.Split('-').ToList()[1];
                    if(!dicChatFrm.Keys.Contains(accout))
                    {
                        FrmClient chatClient = new FrmClient(cName, accout);
                        chatClient.Show();
                        dicChatFrm.Add(accout, chatClient);
                    }
                    else
                    {
                        var frm =dicChatFrm[accout];
                        frm.Show();
                    }
                   
                }
            }
            else
            {
                if (listOffLine.SelectedItems.Count > 0)
                {
                    var txt = listOffLine.SelectedItems[0].Text;
                   // MessageBox.Show(txt);
                }
            }
           
        }
    }
}
