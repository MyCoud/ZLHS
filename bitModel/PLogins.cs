using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    //账号表
    public class PLogins    //登录表
    {
        public int LoginId { get; set; }        //Id主键

        public string LoginPhone { get; set; }  //手机号

        public string LoginCode { get; set; }       //验证码

        public string LoginPass { get; set; }      //密码

    }
}
