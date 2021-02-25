using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Resume    //个人简历
    {
        public int RId { get; set; }        //主键Id

        public string ResumeName { get; set; }  //姓名

        public string ResumeSex { get; set; }   //性别

        public string ResumeBirthday { get; set; }      //生日    

        public string Addresss { get; set; }    //居住地

        public string Education { get; set; }   //学历

        public string Undergo { get; set; }     //工作经验

        public string Phone { get; set; }   //手机号

        public string ResumeEmail { get; set; }     //邮箱

        public string Position { get; set; }    //期待职位

        public string WorkFrom { get; set; }        //从事行业

        public string WantMoney { get; set; }   //期待薪资

        public string WantCity { get; set; }        //期望城市

        public string WorkNature { get; set; }      //工作性质

        public DateTime ArrivalTime { get; set; }   //入职时间

        public bool WorkBit { get; set; }       //求职状态

        public bool Yincang { get; set; }       //是否显示

        public int Login_id { get; set; }       //外键 个人帐号
    }
}
