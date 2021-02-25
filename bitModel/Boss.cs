using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Boss   //Boss招聘表
    {
        public int Bossid { get; set; }     //主键Id

        public string Bossimg { get; set; }     //头像

        public string Bossname { get; set; }    //姓名

        public string Bosspos { get; set; }     //招聘职位

        public string Bossaddress { get; set; }     //招聘地区

        public string Bossphone { get; set; }       //联系电话

        public int Enter_id { get; set; }       //外键 用于和Entel表链接
    }
}
