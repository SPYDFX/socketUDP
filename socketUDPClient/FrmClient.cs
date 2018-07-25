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

        public FrmClient(string cName)
        {
            InitializeComponent();
            this.userName = cName;

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
                sendData.DataID = Packet.MessageType.Message;
                byte[] byteData = sendData.GetDataStream();
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
                sendData.DataID = Packet.MessageType.Login;
                byte[] data = sendData.GetDataStream();
                clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, serverEndPoint, new AsyncCallback(this.SendData), null);
                lstUser.Items.Add(this.userName);
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

            Packet receivedData = new Packet(this.dataStream);

            if (receivedData.DataID == Packet.MessageType.Login)
            {
                lstUser.Items.Add(receivedData.ChatName);
            }

            if (receivedData.ChatMessage != null)
                this.Invoke(this.displayMessageDelegate, new object[] { receivedData.ChatMessage });

            this.dataStream = new byte[1024];

            clientSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref serverEndPoint, new AsyncCallback(this.ReceiveData), null);

            if (!lstUser.Items.Contains(receivedData.ChatName))
            {
                lstUser.Items.Add(receivedData.ChatName);
            }
        }
        #endregion

        private void DisplayMessage(string message)
        {
            lstMsg.Items.Add( message);
        }
    }
}
