using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bitidal;
using bitModel;
namespace bitibll
{
  public  class ZhsbLL
    {
        ZhsDAl dal = new ZhsDAl();
        //注册
        public int Zhuce(PLogins s)
        {
            return dal.Zhuce(s);
        }
        //登录
        public int GetReuslt(string LoginPhone, string LoginPass)
        {
            return dal.GetReuslt(LoginPhone,LoginPass);
        }
    }
}
