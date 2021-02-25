﻿using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Company
    {
        public int CId { get; set; }    //主键

        public string Comwork { get; set; }    //公司名称1111

        public string ComImg { get; set; }     //公司图片

        public string jobAge { get; set; }     //年龄

        public int jobNum { get; set; }     //招聘人数

        public string jobsex { get; set; }     //性别

        public string jobposition { get; set; }    //岗位职责

        public string jobrequest { get; set; }     //任职要求

        public string jobPrice { get; set; }       //薪资待遇

        public DateTime jobTime { get; set; }        //作息时间

        public string jobgift { get; set; }        //公司福利

        public string jobgiftes { get; set; }      //其他福利

        public string jobPlace { get; set; }       //工作地址

        public string jobImgs { get; set; }        //企业面貌

        public string jobOverImg { get; set; }     //上传后

        public int Enter_id { get; set; }       //外键

    }
}
