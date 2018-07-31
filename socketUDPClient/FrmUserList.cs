using model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
        private Dictionary<string, Form> dicChatFrm = new Dictionary<string, Form>();//用来记录打开窗体对象
        Socket clientSocket = null;
        static Boolean isListen = true;
        Thread thDataFromServer;
        
        public IPAddress serverIP
        {
            get
            {
                return IPAddress.Parse(ConfigurationManager.AppSettings["serverIP"]);
            }
        }

        public int port
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["port"]);
            }
        }

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
                //listOnLine = new ListViewEx();
                listOnLine = new ListView();
                UserListDisplay(onLineUserList, listOnLine);
            }
            if (offLineUserList != null && offLineUserList.Count > 0)
            {
                listOffLine = new ListView();
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
                    lvi.Text = u.userName + "-" + u.userAccount;
                    list.Items.Add(lvi);
                }
                //var u = userList[0];
                //for (int i=0;i<15;i++)
                //{
                //    ListViewItem lvi = new ListViewItem();
                //    lvi.ImageIndex = 1;
                //    lvi.Text = u.userName + "-" + u.userAccount;
                //    list.Items.Add(lvi);
                //}

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
                    if (!dicChatFrm.Keys.Contains(accout))
                    {
                        FrmClientTcp chatClient = new FrmClientTcp(cName, accout);
                        chatClient.Show();
                        chatClient.Closed += (s, args) => this.RemoveFrm(accout);
                        dicChatFrm.Add(accout, chatClient);
                    }
                    else
                    {
                        var frm = dicChatFrm[accout];
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
        public void RemoveFrm(string key)
        {
            dicChatFrm.Remove(key);
        }
        public void LinkServer()
        {
            if (clientSocket == null || !clientSocket.Connected)
            {
                try
                {
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //参考网址： https://msdn.microsoft.com/zh-cn/library/6aeby4wt.aspx
                    // Socket.BeginConnect 方法 (String, Int32, AsyncCallback, Object)
                    //开始一个对远程主机连接的异步请求
                    /* string host,     远程主机名
                     * int port,        远程主机的端口
                     * AsyncCallback requestCallback,   一个 AsyncCallback 委托，它引用连接操作完成时要调用的方法，也是一个异步的操作
                     * object state     一个用户定义对象，其中包含连接操作的相关信息。 当操作完成时，此对象会被传递给 requestCallback 委托
                     */
                    //如果txtIP里面有值，就选择填入的IP作为服务器IP，不填的话就默认是本机的
                  
                    //IPAddress ipadr = IPAddress.Parse("192.168.1.100");
                    clientSocket.BeginConnect(serverIP, port, (args) =>
                    {
                        if (args.IsCompleted)   //判断该异步操作是否执行完毕
                        {
                            Byte[] bytesSend = new Byte[4096];
                            bytesSend = Encoding.UTF8.GetBytes("");  //用户名，这里是刚刚连接上时需要传过去
                            if (clientSocket != null && clientSocket.Connected)
                            {
                                clientSocket.Send(bytesSend);
                                //txtName.Enabled = false;    //设置为不能再改名字了
                                //txtSendMsg.Focus();         //将焦点放在
                                thDataFromServer = new Thread(DataFromServer);
                                thDataFromServer.IsBackground = true;
                                thDataFromServer.Start();
                            }
                            //txtName.BeginInvoke(new Action(() =>
                            //{

                            //    else
                            //    {
                            //        MessageBox.Show("服务器已关闭");
                            //    }

                            //}));
                            //txtIP.BeginInvoke(new Action(() =>
                            //{
                            //    if (clientSocket != null && clientSocket.Connected)
                            //    {
                            //        txtIP.Enabled = false;
                            //    }
                            //}));
                        }
                    }, null);
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
               // MessageBox.Show("你已经连接上服务器了");
            }
        }
    }
}
