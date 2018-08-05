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

        private Dictionary<string, FrmClientTcp> dicChatFrm = new Dictionary<string, FrmClientTcp>();//用来记录打开窗体对象

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
            //隐藏任务栏区图标
            this.ShowInTaskbar = false;
            //图标显示在托盘区
           
            this.account = account;
            InitializeBaseInfo();
            InitializeUserList();
            notify.Visible = true;
            notify.Text = this.uname;
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
            ExitEvent();
            //if (clientSocket != null && clientSocket.Connected)
            //{
            //    thDataFromServer.Abort();
            //    Packet sendData = new Packet();
            //    sendData.comeName = this.uname;
            //    sendData.comeNo = this.account;
            //    sendData.type = MessageType.Logout;
            //    byte[] data = ByteHelper.Serialize(sendData);
            //    clientSocket.Send(data);
            //    clientSocket.Close();
            //    clientSocket = null;
            //    bll.LoginOut(this.account);
            //}
            //this.Close();

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Minimized;
            ////隐藏任务栏区图标
            //this.ShowInTaskbar = false;
            ////图标显示在托盘区
            //notify.Visible = true;
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
                    lvi.Text = u.userName;
                    lvi.Name = u.userAccount;
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
            if (listOnLine.Visible)
            {
                if (listOnLine.SelectedItems.Count > 0)
                {
                    //var txt = listOnLine.SelectedItems[0].Name;
                    //// MessageBox.Show(txt);
                    var chatName = listOnLine.SelectedItems[0].Text;
                    var chatNo = listOnLine.SelectedItems[0].Name;
                    if (!dicChatFrm.Keys.Contains(chatNo))
                    {
                        Chat ct = new Chat()
                        {
                            userNo = this.account,
                            userName = this.uname,
                            chatName = chatName,
                            chatNo = chatNo,
                        };
                        FrmClientTcp chatClient = new FrmClientTcp(ct, clientSocket);
                        chatClient.Show();
                        chatClient.Closed += (s, args) => this.RemoveFrm(chatNo);
                        dicChatFrm.Add(chatNo, chatClient);
                    }
                    else
                    {
                        var frm = dicChatFrm[chatNo];
                        if(frm.WindowState==FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
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
                                sendData.comeName = this.uname;
                                sendData.comeNo = this.account;
                                sendData.type = MessageType.Login;
                                byte[] data = ByteHelper.Serialize(sendData);
                               // clientSocket.Send(BitConverter.GetBytes(data.Length));
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
            byte[] bytesFrom = new byte[4096];
            try
            {
                while (isListen)
                {
                    //clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
                    int len1= clientSocket.Receive(bytesFrom);
                    long total = BitConverter.ToInt32(bytesFrom, 0);
                    byte[] data = new byte[len1 - 4];
                    System.Buffer.BlockCopy(bytesFrom, 4, data, 0, len1-4);
                   
                    long receiveLength = len1 - 4 ;
                    while (receiveLength<total)
                    {
                        int len = 0;
                        try
                        {

                            len = clientSocket.Receive(bytesFrom);
                            receiveLength += len;
                        }
                        catch
                        {

                        }
                        byte[] tmp = new byte[data.Length + len];
                        System.Buffer.BlockCopy(data, 0, tmp, 0, data.Length);
                        System.Buffer.BlockCopy(bytesFrom, 0, tmp, data.Length, len);
                        data = tmp;
                    }
                    //Int32 len = clientSocket.Receive(bytesFrom);

                    Packet receivedData = (Packet)ByteHelper.Deserialize(data);
                    //Packet receivedData = (Packet)ByteHelper.Deserialize(bytesFrom);
                    if (receivedData != null)
                    {
                        //如果收到服务器已经关闭的消息，那么就把客户端接口关了，免得出错，并在客户端界面上显示出来
                        if (receivedData.type == MessageType.ServerClose)
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
                        if (receivedData.type == MessageType.Message|| receivedData.type == MessageType.Shake|| receivedData.type==MessageType.Img)
                        {
                            ShowMsg(receivedData);
                        }

                        if (receivedData.type == MessageType.Login)
                        {
                            var user = offLineUserList.FirstOrDefault(u => u.userAccount == receivedData.comeNo);
                            if (user != null)
                            {
                                onLineUserList.Add(user);
                                offLineUserList.Remove(user);
                                this.Invoke(new Action(() =>
                                {
                                    foreach (ListViewItem item in listOffLine.Items)
                                    {
                                        if (item.Name == user.userAccount)
                                        {
                                            listOffLine.Items.Remove(item);
                                            listOnLine.Items.Add(item);
                                        }
                                    }
                                }));
                            }
                        }

                        if (receivedData.type == MessageType.Logout)
                        {
                            var user = onLineUserList.FirstOrDefault(u => u.userAccount == receivedData.comeNo);
                            if (user != null)
                            {
                                offLineUserList.Add(user);
                                onLineUserList.Remove(user);
                                this.Invoke(new Action(() =>
                                {
                                    foreach (ListViewItem  item in listOnLine.Items)
                                    {
                                        if(item.Name==user.userAccount)
                                        {
                                            listOnLine.Items.Remove(item);
                                            listOffLine.Items.Add(item);
                                        }
                                    }
                                }));

                            }
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
                    //sendData.comeName = this.uname;
                    sendData.comeNo = this.account;
                    sendData.type = MessageType.Logout;
                    byte[] data = ByteHelper.Serialize(sendData);
                    clientSocket.Send(BitConverter.GetBytes(data.Length));
                    clientSocket.Send(data);
                    //没有在客户端关闭连接，而是给服务器发送一个消息，在服务器端关闭连接
                    //这样可以将异常的处理放到服务器。客户端关闭会让客户端和服务器都抛异常
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
            }
        }

        private void tsmShow_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            ExitEvent();
        }

        private void ExitEvent()
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                thDataFromServer.Abort();
                Packet sendData = new Packet();
                sendData.comeName = this.uname;
                sendData.comeNo = this.account;
                sendData.type = MessageType.Logout;
                byte[] data = ByteHelper.Serialize(sendData);
                clientSocket.Send(BitConverter.GetBytes(data.Length));
                clientSocket.Send(data);
                clientSocket.Close();
                clientSocket = null;
                bll.LoginOut(this.account);
            }
            this.Close();
        }

        private void ctMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ShowMsg(Packet pct)
        {
            var friend = onLineUserList.Where(s => s.userAccount == pct.comeNo).FirstOrDefault();
            if (friend == null)
            {
                friend = offLineUserList.Where(s => s.userAccount == pct.comeNo).FirstOrDefault();
            }
            if (friend != null)
            {
                pct.comeName = friend.userName;
                FrmClientTcp frmtcp = null;
                if (dicChatFrm.Keys.Contains(pct.comeNo))
                {
                    frmtcp=dicChatFrm[pct.comeNo];
                    frmtcp.Invoke(new Action(() =>
                    {
                        if(pct.type==MessageType.Message)
                        {
                            frmtcp.DisplayMessage(pct.comeName, pct.msg);
                            frmtcp.Show();
                        }
                        if (pct.type == MessageType.Shake)
                        {
                            frmtcp.FrmShake();
                            //pct.msg = "发来振动";
                        }
                        if(pct.type==MessageType.Img)
                        {
                            frmtcp.DisplayImg(pct);
                        }
                        //frmtcp.DisplayMessage(pct.comeName, pct.msg);
                        //frmtcp.Show();
                        //if (pct.type == MessageType.Shake)
                        //{
                        //    this.thDataFromServer.sl
                        //    if (frmtcp.WindowState == FormWindowState.Minimized)
                        //    {
                        //        frmtcp.WindowState = FormWindowState.Normal;
                        //    }
                            
                        //}
                    }));
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        Chat ct = new Chat()
                        {
                            userNo = this.account,
                            userName = this.uname,
                            chatName = pct.comeName,
                            chatNo = pct.comeNo,

                        };
                        frmtcp = new FrmClientTcp(ct, clientSocket);
                        frmtcp.Closed += (s, args) => this.RemoveFrm(pct.comeNo);
                        dicChatFrm.Add(pct.comeNo, frmtcp);
                        if(pct.type==MessageType.Message)
                        {
                            frmtcp.DisplayMessage(pct.comeName, pct.msg);
                            frmtcp.Show();
                        }
                        if(pct.type == MessageType.Shake)
                        {
                            frmtcp.FrmShake();
                        }
                        if (pct.type == MessageType.Img)
                        {
                            frmtcp.DisplayImg(pct);
                        }
                    }));
                }
               
            }
        }
    }
}
