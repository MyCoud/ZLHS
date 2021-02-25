using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class ResumeOutgoing    //简历外发表
    {
        public int Reid { get; set; }       //邮件外发Id

        public string ResumegEmail { get; set; }    //企业邮箱

        public string ResumePosition { get; set; }  //应聘职位

        public int Enter_id { get; set; }       //外键 用于和Entel表相连
    }
}
