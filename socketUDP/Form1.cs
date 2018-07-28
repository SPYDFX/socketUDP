using Common;
using model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socketUDP
{
    public partial class frmServer : Form
    {
        UdpOp udp = new UdpOp();
        private ArrayList clientList;
        private Socket serverSocket;
        private byte[] dataStream = new byte[1024];
        private delegate void UpdateStatusDelegate(string status);
        private UpdateStatusDelegate updateStatusDelegate = null;
        public frmServer()
        {
            InitializeComponent();
            txtIP.Text = UdpOp.GetLocalIPAddress();
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 30000);
            serverSocket.Bind(server);
            this.clientList = new ArrayList();
            updateStatusDelegate +=new UpdateStatusDelegate( showmsg);
        }


        private void btnStart_Click(object sender, EventArgs e)
        {

            if (btnStart.Text == "关闭")
            {
                //serverSocket.Shutdown(SocketShutdown.Both);
                btnStart.Text = "开启";
            }
            else
            {
                IPEndPoint clients = new IPEndPoint(IPAddress.Any, 0);
                EndPoint epSender = (EndPoint)clients;
                serverSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref epSender, new AsyncCallback(ReceiveData), epSender);
                btnStart.Text = "关闭";
            }
        }

        private void ReceiveData(IAsyncResult asyncResult)
        {
            byte[] data;

            // Packet receivedData = new Packet(this.dataStream);
            Packet receivedData = (Packet)ByteHelper.Deserialize(this.dataStream);
            Packet sendData = new Packet();
            IPEndPoint clients = new IPEndPoint(IPAddress.Any, 0);
            EndPoint senderEndPoint = (EndPoint)clients;

            serverSocket.EndReceiveFrom(asyncResult, ref senderEndPoint);

            sendData.DataID = receivedData.DataID;
            sendData.ChatName = receivedData.ChatName;

            switch (receivedData.DataID)
            {
                case MessageType.Message:
                    sendData.ChatMessage = receivedData.ChatName + ": " + receivedData.ChatMessage;
                    break;

                case MessageType.Login:
                    Client client = new Client();
                    client.endPoint = senderEndPoint;
                    client.name = receivedData.ChatName;

                    this.clientList.Add(client);

                    sendData.ChatMessage = "--- " + receivedData.ChatName + " has logged in ---";
                    lstBox.Items.Add(client.name + "上线；（IP地址：" + client.endPoint + ")");
                    break;

                case MessageType.Logout:
                    foreach (Client c in this.clientList)
                    {
                        if (c.endPoint.Equals(senderEndPoint))
                        {
                            this.clientList.Remove(c);
                            break;
                        }
                    }

                    sendData.ChatMessage = "--- " + receivedData.ChatName + " has logged out ---";
                    break;
            }

            data = ByteHelper.Serialize(sendData);//sendData.GetDataStream();

            foreach (Client client in this.clientList)
            {
                if (client.endPoint != senderEndPoint || sendData.DataID != MessageType.Login)
                {
                    serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, client.endPoint, new AsyncCallback(this.SendData), client.endPoint);
                }
            }

            serverSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref senderEndPoint, new AsyncCallback(this.ReceiveData), senderEndPoint);

            //this.Invoke(this.updateStatusDelegate, new object[] { sendData.ChatMessage });
            showmsg(sendData.ChatMessage);
        }
        private void SendData(IAsyncResult asyncResult)
        {
            try
            {
                serverSocket.EndSend(asyncResult);
            }

            catch (Exception e)
            {
                MessageBox.Show("Message not sent: " + e.Message);
            }
        }

        private void frmServer_Load(object sender, EventArgs e)
        {

        }

        public void showmsg(string msg)
        {
            lstBox.Items.Add("转发信息：" + msg);
        }
    }
}
