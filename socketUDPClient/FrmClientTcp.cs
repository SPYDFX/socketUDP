using Common;
using model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            plHandImg.Visible = false;
            btnSave.Visible = false;
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
            SendMsgEvent();
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

        private void btnSend_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                SendMsgEvent();
            }
           
        }

        public void FrmShake()
        {
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            DisplayMessage(ct.chatName, "发来振动");
            
            for (int i=0;i<100;i++)
            {
                this.Top -= 10;
                this.Left += 10;
                Thread.Sleep(10);
                this.Top += 10;
                this.Left -= 10;
            }
        }

        private void btnSend_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.btnClose_Click(sender,e);
        }

        private void btnSelectImg_Click(object sender, EventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG" + "|All Files (*.*)|*.*";
            file.ShowDialog();
            if(file!=null)
            {
                picSelectedImg.ImageLocation = file.FileName;//包含路径的文件名
                plHandImg.Visible = true;
                lblFileName.Text = file.SafeFileName;//只有文件名
                btnHandImg.Text = "删除";
                btnSave.Visible = false;
            }
           
            //picSelectedImg.
        }

        private void SendMsgEvent()
        {
            var imgPath = picSelectedImg.ImageLocation;
            if (!string.IsNullOrWhiteSpace(imgPath))
            {
                string filename = System.IO.Path.GetFileName(imgPath);//文件名  “Default.aspx”
                //string extension = System.IO.Path.GetExtension(imgPath);//扩展名 “.aspx”
               // string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(imgPath);// 没有扩展名的文件名 “Default”
                var img = picSelectedImg.Image;
                Packet sendData = new Packet();
                sendData.comeNo = ct.userNo;
                sendData.toNo = ct.chatNo;
                sendData.type = MessageType.Img;
                sendData.msg = filename;
                sendData.file = ImageHelper.ImageToBytes(img);
                byte[] data = ByteHelper.Serialize(sendData);
                skt.Send(BitConverter.GetBytes(data.Length));
                int result= skt.Send(data);
                DisplayMessage(ct.userName, "已发送图片"+ filename+"，发送长度："+ result);
            }
            if (!string.IsNullOrWhiteSpace(txtSendMsg.Text))
            {
                Packet sendData = new Packet();
                sendData.comeNo = ct.userNo;
                sendData.toNo = ct.chatNo;
                sendData.type = MessageType.Message;
                sendData.msg = txtSendMsg.Text;
                byte[] data = ByteHelper.Serialize(sendData);
                skt.Send(BitConverter.GetBytes(data.Length));
                skt.Send(data);
                DisplayMessage(ct.userName, txtSendMsg.Text);
                txtSendMsg.Text = "";
            }
        }

        private void btnHandImg_Click(object sender, EventArgs e)
        {
            if(btnHandImg.Text=="保存")
            {
                var img = picSelectedImg.Image;
                var path = System.IO.Directory.GetCurrentDirectory()+ "\\Receive\\Images\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\" + lblFileName.Text;
                img.Save(path);
                picSelectedImg.Image = null;
                plHandImg.Visible = false;
                MessageBox.Show("保存成功!");
                DisplayMessage(ct.userName, "已保存图片 " + path);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "保存为";
            saveDlg.OverwritePrompt = true;
            saveDlg.Filter =
                "BMP文件 (*.bmp) | *.bmp|" +
                "Gif文件 (*.gif) | *.gif|" +
                "JPEG文件 (*.jpg) | *.jpg|" +
                "PNG文件 (*.png) | *.png";
            saveDlg.ShowHelp = true;
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                var img = picSelectedImg.Image;
                string fileName = saveDlg.FileName;
                string strFilExtn = fileName.Remove(0, fileName.Length - 3);
                switch (strFilExtn)
                {               
                    case "bmp":
                        img.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        img.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        img.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        img.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        img.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
                picSelectedImg.Image = null;
                plHandImg.Visible = false;
                MessageBox.Show("保存成功!");
                DisplayMessage(ct.userName, "已保存图片 " + fileName);
            }
        }

        public void DisplayImg(Packet pct)
        {
            if(pct.file!=null)
            {
                this.Show();
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                picSelectedImg.Image = ImageHelper.BytesToImage(pct.file);
                lblFileName.Text = pct.msg;
                plHandImg.Visible = true;
                btnSave.Visible = true;
                btnHandImg.Text = "保存";
                lblTitle.Text = "已接收图片";
                DisplayMessage(ct.chatName, "发来图片" + pct.msg);
            }
        }
    }
}
