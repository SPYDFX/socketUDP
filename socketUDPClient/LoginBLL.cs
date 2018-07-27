using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socketUDPClient
{
    public class LoginBLL
    {
        LoginDal dal = new LoginDal();
        public bool Login(UserInfo model)
        {
            bool isSuccess = false;
            var ret = dal.GetLoginInfoByAccount(model.userName);
            if (ret != null)
            {
                if (ret.userPwd == model.userPwd)
                {
                    isSuccess = true;
                }
            }
            return isSuccess;
        }
    }
}
