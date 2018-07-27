using Common;
using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socketUDPClient
{
    public class UserBLL
    {
        UserDal dal = new UserDal();
        public bool Login(UserInfo model)
        {
            bool isSuccess = false;
            var ret = dal.GetLoginInfoByAccount(model.userAccount);
            if (ret != null)
            {
                if (ret.userPwd == model.userPwd)
                {
                    ret.onLine = 1;
                    ret.ipAddress = UdpOp.GetLocalIPAddress();
                    dal.UpdateUserInfoLogin(ret);
                    isSuccess = true;
                }
            }
            return isSuccess;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string account)
        {
            return dal.GetLoginInfoByAccount(account);
        }
        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUserList()
        {
            return dal.GetUserList();
        }
    }
}
