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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socketUDPClient
{
    public partial class FrmClientTcp : Form
    {
        private int startX, startY;
        private Socket skt;
        private Chat ct;
        public FrmClientTcp()
        {
            InitializeComponent();
        }
        public FrmClientTcp(Chat chat, Socket skt)
        {
            InitializeComponent();
            this.skt = skt;
            this.ct = chat;
            lblFriendName.Text = ct.chatName;
           
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
                sendData.comeNo = ct.userNo;
                sendData.toNo = ct.chatNo;
                sendData.type = MessageType.Message;
                sendData.msg = txtSendMsg.Text;
                byte[] data = ByteHelper.Serialize(sendData);
                skt.Send(data);
                DisplayMessage(ct.userName,txtSendMsg.Text);
                txtSendMsg.Text = "";
            }
           
        }
        public void DisplayMessage(string comeName,string msg)
        {
            //this.WindowState = FormWindowState.Normal;
            //if (this.WindowState == FormWindowState.Minimized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
            if (!string.IsNullOrWhiteSpace(msg))
            {
                lstMsg.Items.Add(comeName + ":" + msg);
            }
            
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

        private void btnShake_Click(object sender, EventArgs e)
        {
            Packet sendData = new Packet();
            sendData.comeNo = ct.userNo;
            sendData.toNo = ct.chatNo;
            sendData.type = MessageType.Shake;
            byte[] data = ByteHelper.Serialize(sendData);
            skt.Send(data);
        }

        public void FrmShake()
        {
            if(this.WindowState==FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                Thread.Sleep(1500);
            }
            for(int i=0;i<100;i++)
            {
                this.Top -= 10;
                this.Left += 10;
                Thread.Sleep(10);
                this.Top += 10;
                this.Left -= 10;
            }
        }
    }
}
