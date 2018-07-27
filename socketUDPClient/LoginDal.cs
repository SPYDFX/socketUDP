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
    public class LoginDal
    {
        public UserInfo GetLoginInfoByAccount(string account)
        {
            UserInfo user = new UserInfo();
            if (!string.IsNullOrWhiteSpace(account))
            {
                string strWhere = string.Format("uAccount={0}", account);
                var dt = DbHelper.GetTable(strWhere);
                if(dt!=null&&dt.Rows.Count>0)
                {

                }
            }
            return user;
        }
    }
}
