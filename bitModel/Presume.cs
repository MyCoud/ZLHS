using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
  public  class Presume     //个人简历表
    {
        public int Preid	 { get; set; }      //ID主键
        public string Rname	 { get; set; }         //姓名

        public DateTime Rbirth	 { get; set; }     //出生年月

        public int Rsex	 { get; set; }          //性别
        public int Reducate { get; set; }       //学历
        public string Rphone	 { get; set; }      //电话
        public string Rhouse	 { get; set; }      //现居住地
        public string Remail { get; set; }          //邮箱
        public string Rpostition { get; set; }         //意向职位

        public bool Rindustry	   { get; set; }    //从事行业
        public int Rwork		   { get; set; }    //工作经验
        public int Rpay		   { get; set; }        //期望薪资
        public int Rpid		   { get; set; }        //期望城市
        public string Rjob		   { get; set; }        //工作性质
        public DateTime Rtime		   { get; set; }    //到岗时间
        public bool Rstate		       { get; set; }      //求职状态
        public int Login_id { get; set; }           //个人帐号 （外键）
      
    }
}
