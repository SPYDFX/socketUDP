using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class UserInfo
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string userAccount { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string userSex { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string userPwd { get; set; }
        /// <summary>
        /// 是否记住密码
        /// </summary>
        public bool isRemPwd { get; set; }

        public int onLine { get; set; }
        /// <summary>
        /// ip地址
        /// </summary>
        public string ipAddress { get; set; }
}
}
