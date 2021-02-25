using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class EnterLogins        //企业注册表
    {
        public int Eid { get; set; }    //主键Id

        public string Companyname { get; set; }     //企业名称

        public string Entername { get; set; }       //负责人姓名

        public string EnterIphone { get; set; }     //手机号

        public string EnterCode { get; set; }       //验证码

        public string EnterPassword { get; set; }   //注册密码

        public string Enteremaile { get; set; }     //邮箱
    }
}
