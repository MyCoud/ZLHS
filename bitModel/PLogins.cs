using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    //登录注册表
  public  class PLogins
    {
        public int LoginId { get; set; }//ID
        public string LoginPhone { get; set; }//手机号


        public string LoginCode {get; set; }//验证码
        public string LoginPass { get; set; }//密码
        public string LoginImg { get; set; }//头像
        public string LoginName { get; set; }//账户名

    }
}

