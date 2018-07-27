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
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string userPwd { get; set; }
        /// <summary>
        /// 是否记住密码
        /// </summary>
        public bool isRemPwd { get; set; }
    }
}
