using Common;
using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socketUDPClient
{
    public class UserDal
    {
        public UserInfo GetLoginInfoByAccount(string account)
        {
            UserInfo user = new UserInfo();
            if (!string.IsNullOrWhiteSpace(account))
            {
                string strWhere = string.Format("uAccount='{0}'", account);
                var dt = DbHelper.GetTableByCondition("userinfo", strWhere);
                if(dt!=null&&dt.Rows.Count>0)
                {
                    user.userPwd = dt.Rows[0]["uPwd"].ToString();
                    user.userName = dt.Rows[0]["uName"].ToString();
                    user.userAccount = account;
                }
            }
            return user;
        }
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUserList()
        {
            List<UserInfo> ulist = new List<UserInfo>();
            var dt= DbHelper.GetTableByCondition("userinfo");
            if (dt != null && dt.Rows.Count > 0)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    var u = new UserInfo();
                    u.userName = dt.Rows[i]["uName"].ToString();
                    u.ipAddress = dt.Rows[i]["ipAddress"].ToString();
                    u.userSex = dt.Rows[i]["uSex"].ToString();
                    u.userAccount = dt.Rows[i]["uAccount"].ToString();
                    var temp = dt.Rows[i]["online"].ToString();
                    u.onLine = string.IsNullOrWhiteSpace(dt.Rows[i]["online"].ToString())?0:int.Parse(dt.Rows[i]["online"].ToString());
                    ulist.Add(u);
                }
            }
            return ulist;
        }

        public int UpdateUserInfoLogin(UserInfo model)
        {
            int result = 0;
            if(model!=null)
            {
                string strWhere = string.Format("uAccount='{0}'", model.userAccount);
                string strSet = string.Format("online={0},ipAddress='{1}'", model.onLine,model.ipAddress);
                result=DbHelper.UpdateTableByCondition("userinfo", strWhere, strSet);
            }
            return result;
        }
    }
}
