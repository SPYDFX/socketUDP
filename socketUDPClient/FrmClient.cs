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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socketUDPClient
{
    public partial class FrmClient : Form
    {
        private int startX, startY;
        public string userName { get; set; }
        public Socket clientSocket { get; set; }
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

        private EndPoint serverEndPoint;
        private byte[] dataStream = new byte[1024];

        private delegate void DisplayMessageDelegate(string message);
        private DisplayMessageDelegate displayMessageDelegate = null;
        public FrmClient()
        {
            InitializeComponent();
        }
        public FrmClient(string cName,string account)
        {
            InitializeComponent();
            this.userName = account;
            lblChatName.Text = cName;
            this.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPEndPoint server = new IPEndPoint(serverIP, port);
            serverEndPoint = (EndPoint)server;

            //发送登录信息
            SendLogin();
          
            //开始接收数据
            this.dataStream = new byte[1024];
            clientSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref serverEndPoint, new AsyncCallback(this.ReceiveData), null);
            this.displayMessageDelegate = new DisplayMessageDelegate(this.DisplayMessage);
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSendMsg.Text))
            {
                Packet sendData = new Packet();
                sendData.ChatName = this.userName;
                sendData.ChatMessage = txtSendMsg.Text;
                sendData.DataID = MessageType.Message;
                byte[] byteData = ByteHelper.Serialize(sendData);//sendData.GetDataStream();
                clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, serverEndPoint, new AsyncCallback(this.SendData), null);
                txtSendMsg.Text = String.Empty;
            }
        }
        /// <summary>
        /// 发送登录信息
        /// </summary>
        private void SendLogin()
        {
            if(!string.IsNullOrWhiteSpace(this.userName)&& serverEndPoint!=null)
            {
                Packet sendData = new Packet();
                sendData.ChatName = this.userName;
                sendData.DataID = MessageType.Login;
                byte[] data = ByteHelper.Serialize(sendData);//sendData.GetDataStream();
                clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, serverEndPoint, new AsyncCallback(this.SendData), null);
                
            }
           
        }

        #region Send and Receive
        private void SendData(IAsyncResult a)
        {
            try
            {
                clientSocket.EndSend(a);
            }
            catch (Exception e)
            {
                MessageBox.Show("Message was not sent: " + e.Message);
            }
        }

        private void ReceiveData(IAsyncResult a)
        {
            this.clientSocket.EndReceive(a);

            // Packet receivedData = new Packet(this.dataStream);
            Packet receivedData =(Packet)ByteHelper.Deserialize(this.dataStream);
            if (receivedData.DataID == MessageType.Login)
            {
                //lstUser.Items.Add(receivedData.ChatName);
            }

            if (receivedData.ChatMessage != null)
                this.Invoke(this.displayMessageDelegate, new object[] { receivedData.ChatMessage });

            this.dataStream = new byte[1024];

            clientSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref serverEndPoint, new AsyncCallback(this.ReceiveData), null);

            //if (!lstUser.Items.Contains(receivedData.ChatName))
            //{
            //   // lstUser.Items.Add(receivedData.ChatName);
            //}
        }
        #endregion

        public void DisplayMessage(string message)
        {
            lstMsg.Items.Add( message);
        }

        private void lstMsg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtSendMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmClient_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startX = e.X;
                startY = e.Y;
            }
        }

        private void plHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - startX;
                this.Top += e.Y - startY;
            }
        }

        private void plHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startX = e.X;
                startY = e.Y;
            }
        }

        private void FrmClient_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - startX;
                this.Top += e.Y - startY;
            }
        }
    }
}
