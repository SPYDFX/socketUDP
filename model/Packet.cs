using Common;
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
        /// <summary>
        /// 消息的类型
        /// </summary>
        public MessageType type { get; set; }
        //public string ChatAcount { get; set; }
        //public string ChatName { get; set; }
        public string msg { get; set; }
        /// <summary>
        /// 消息发出者
        /// </summary>
        public string comeNo { get; set; }
        /// <summary>
        /// 消息发出者的名称
        /// </summary>
        public string comeName { get; set; }
        /// <summary>
        /// 消息的接收者
        /// </summary>
        public string toNo { get; set; }
        /// <summary>
        /// 消息接收者的名称
        /// </summary>
        public string toName { get; set; }
         
    }
    public enum MessageType
    {
        /// <summary>
        /// 登录
        /// </summary>
        Login,
        /// <summary>
        /// 登出
        /// </summary>
        Logout,
        /// <summary>
        /// 消息
        /// </summary>
        Message,
        /// <summary>
        /// 服务器断开
        /// </summary>
        ServerClose,
        /// <summary>
        /// 抖动
        /// </summary>
        Shake,
        Null
    }
}
