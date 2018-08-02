using Common;
using model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socketUDPClient
{
    public partial class FrmClientTcp : Form
    {
        private int startX, startY;
        private Socket skt;
        private string friendName;
        private string frend;
        private string user;
        public FrmClientTcp()
        {
            InitializeComponent();
        }
        public FrmClientTcp(string frend,string friendName,string user, Socket skt)
        {
            InitializeComponent();
            this.skt = skt;
            this.friendName = friendName;
            this.frend = frend;
            this.user = user;
            lblFriendName.Text = friendName;
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtSendMsg.Text))
            {
                Packet sendData = new Packet();
                sendData.ChatAcount = this.user;
                sendData.to = this.frend;
                sendData.come = this.user;
                sendData.DataID = MessageType.Message;
                sendData.ChatMessage = txtSendMsg.Text;
                byte[] data = ByteHelper.Serialize(sendData);
                skt.Send(data);
            }
           
        }
        public void DisplayMessage(string message)
        {
            lstMsg.Items.Add(message);
        }

        private void FrmClientTcp_MouseMove(object sender, MouseEventArgs e)
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

        private void plHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - startX;
                this.Top += e.Y - startY;
            }
        }

        private void FrmClientTcp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startX = e.X;
                startY = e.Y;
            }
        }
    }
}
