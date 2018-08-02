﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    [Serializable]
    public class Packet
    {
        public MessageType DataID { get; set; }
        public string ChatAcount { get; set; }
        public string ChatName { get; set; }
        public string ChatMessage { get; set; }
        /// <summary>
        /// 消息发出者
        /// </summary>
        public string come { get; set; }
        /// <summary>
        /// 消息的接收者
        /// </summary>
        public string to { get; set; }
       

        //public Packet()
        //{
        //    this.DataID = MessageType.Null;
        //    this.ChatName = null;
        //    this.ChatMessage = null;
        //}

        //public Packet(byte[] dataStream)
        //{
        //    this.DataID = (MessageType)BitConverter.ToInt32(dataStream, 0);
        //    int ChatNameLength = BitConverter.ToInt32(dataStream, 4);
        //    int MessageLength = BitConverter.ToInt32(dataStream, 8);
        //    if (ChatNameLength > 0)
        //        this.ChatName = Encoding.GetEncoding("GB2312").GetString(dataStream, 12, ChatNameLength);
        //    else
        //        this.ChatName = null;
        //    if (MessageLength > 0)
        //        this.ChatMessage = Encoding.GetEncoding("GB2312").GetString(dataStream, 12 + ChatNameLength, MessageLength);
        //    else
        //        this.ChatMessage = null;
        //}

        //public byte[] GetDataStream()
        //{
        //    //return ByteHelper.Serialize();
        //    //string msg=this.DataID+"|"+this.ChatName+"|"
        //    //List<byte> dataStream = new List<byte>();

        //    //dataStream.AddRange(BitConverter.GetBytes((int)this.DataID));

        //    //if (this.ChatName != null)
        //    //    dataStream.AddRange(BitConverter.GetBytes(this.ChatName.Length));
        //    //else
        //    //    dataStream.AddRange(BitConverter.GetBytes(0));

        //    //if (this.ChatMessage != null)
        //    //    dataStream.AddRange(BitConverter.GetBytes(this.ChatMessage.Length));
        //    //else
        //    //    dataStream.AddRange(BitConverter.GetBytes(0));

        //    //if (this.ChatName != null)
        //    //    dataStream.AddRange(Encoding.GetEncoding("GB2312").GetBytes(this.ChatName)); ;

        //    //if (this.ChatMessage != null)
        //    //    dataStream.AddRange(Encoding.GetEncoding("GB2312").GetBytes(this.ChatMessage));
        //    //return dataStream.ToArray();
        //}
    }
    public enum MessageType
    {
        Login,
        Logout,
        Message,
        ServerClose,
        Null
    }
}
