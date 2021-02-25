using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class ComBrief   //公司简介表
    {
        public int Briefid { get; set; }    //简介Id

        public string BriefImg { get; set; }    //公司图片

        public int Enter_id { get; set; }       //外键 用于和Entel表链接

        public string BriefGuild { get; set; }  //公司行业

        public string BriefScale { get; set; }  //公司规模

        public string Briefintroduce { get; set; }      //公司介绍

        public string BriefAddress { get; set; }    //公司地址

        public string BriefImges { get; set; }      //公司地址照片

        public string BriefFace { get; set; }       //公司面貌

        public int Bid { get; set; }        //boss招聘外键
    }
}
