using Common;
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
        private string uname;
        private List<UserInfo> onLineUserList;
        private List<UserInfo> offLineUserList;
        private ListView listOnLine;
        private ListView listOffLine;

        private Dictionary<string,FrmClientTcp> dicChatFrm = new Dictionary<string, FrmClientTcp>();//用来记录打开窗体对象

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
            LinkServer();//连接服务器
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
            this.uname = userInfo.userName;
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
                    var cAccount = txt.Split('-').ToList()[1];
                    if (!dicChatFrm.Keys.Contains(cAccount))
                    {
                        FrmClientTcp chatClient = new FrmClientTcp(cAccount, cName, this.account, clientSocket);
                        chatClient.Show();
                        chatClient.Closed += (s, args) => this.RemoveFrm(cAccount);
                        dicChatFrm.Add(cAccount, chatClient);
                    }
                    else
                    {
                        var frm = dicChatFrm[cAccount];
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
        /// <summary>
        /// 连接服务器
        /// </summary>
        public void LinkServer()
        {
            if (clientSocket == null || !clientSocket.Connected)
            {
                try
                {
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
                            if (clientSocket != null && clientSocket.Connected)
                            {
                                Packet sendData = new Packet();
                                sendData.ChatName = this.uname;
                                sendData.ChatAcount = this.account;
                                sendData.come = this.account;
                                sendData.DataID = MessageType.Login;
                                byte[] data = ByteHelper.Serialize(sendData);
                                clientSocket.Send(data);
                                thDataFromServer = new Thread(DataFromServer);
                                thDataFromServer.IsBackground = true;
                                thDataFromServer.Start();
                            }
                            else
                            {
                                //MessageBox.Show("服务器已关闭");
                            }
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

        private void DataFromServer()
        {
            isListen = true;
            try
            {
                while (isListen)
                {
                    Byte[] bytesFrom = new Byte[4096];
                    Int32 len = clientSocket.Receive(bytesFrom);

                    Packet receivedData = (Packet)ByteHelper.Deserialize(bytesFrom);
                    if (receivedData!=null)
                    {
                        //如果收到服务器已经关闭的消息，那么就把客户端接口关了，免得出错，并在客户端界面上显示出来
                        if (receivedData.DataID==MessageType.ServerClose)
                        {
                            clientSocket.Close();
                            clientSocket = null;
                            this.BeginInvoke(new Action(() =>
                            {
                                MessageBox.Show("服务器已关闭");

                            }));
                            thDataFromServer.Abort();   //这一句必须放在最后，不然这个进程都关了后面的就不会执行了
                            return;
                        }
                        if(receivedData.DataID==MessageType.Message)
                        {
                            ShowMsg(receivedData.ChatMessage,receivedData.come);
                        }
                        
                    }
                }
            }
            catch (SocketException ex)
            {
                isListen = false;
                if (clientSocket != null && clientSocket.Connected)
                {
                    //Byte[] bytesSend = new Byte[4096];
                    Packet sendData = new Packet();
                    sendData.ChatName = this.uname;
                    sendData.ChatAcount = this.account;
                    sendData.DataID = MessageType.Logout;
                    byte[] data = ByteHelper.Serialize(sendData);
                    clientSocket.Send(data);
                    //没有在客户端关闭连接，而是给服务器发送一个消息，在服务器端关闭连接
                    //这样可以将异常的处理放到服务器。客户端关闭会让客户端和服务器都抛异常
                  
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ShowMsg(String msg,string frendAcount)
        {
            if(dicChatFrm.Keys.Contains(frendAcount))
            {
                dicChatFrm[frendAcount].DisplayMessage(msg);
                dicChatFrm[frendAcount].Show();
            }
            else
            {
                var friend = onLineUserList.Where(s => s.userAccount == frendAcount).FirstOrDefault();
                if(friend == null)
                {
                    friend = offLineUserList.Where(s => s.userAccount == frendAcount).FirstOrDefault();
                }
                if(friend != null)
                {
                    FrmClientTcp frmtcp = new FrmClientTcp(frendAcount, friend.userName, account, clientSocket);
                    frmtcp.DisplayMessage(msg);
                    frmtcp.Show();
                    dicChatFrm.Add(frendAcount, frmtcp);
                }
              
            }
            
        }
    }
}
