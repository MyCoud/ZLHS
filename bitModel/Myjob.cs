using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Myjob  //我的工作
    {
        public int MId { get; set; }        //主键Id

        public string JobTitle { get; set; }    //职位名称

        public string Compensation { get; set; }    //薪资

        public string Workplace { get; set; }   //工作地点

        public string WorkNature { get; set; }  //工作性质

        public string BossidId { get; set; }    //Hr外键

        public DateTime IssueTime { get; set; }     //发布时间

        public int Interview { get; set; }      //是否面试
    }
}
