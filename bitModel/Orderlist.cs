using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Orderlist     //公司订单表
    {
        public int Orid { get; set; }       //主键Id

        public string OrName { get; set; }      //岗位名称

        public string OrAge { get; set; }       //年龄

        public bool Oreducate { get; set; }     //学历

        public int OrPeop { get; set; }     //招聘人数

        public string Orsex { get; set; }       //性别

        public string Orposition { get; set; }  //岗位职责

        public string Orrequest { get; set; }       //任职要求

        public string OrPrice { get; set; }     //薪资待遇

        public bool OrTime { get; set; }        //发布时间

        public bool Orgift { get; set; }        //公司福利

        public string Orgiftes { get; set; }    //其他福利

        public string OrPlace { get; set; }     //工作地址

        public string OrImgs { get; set; }      //企业面貌

        public string OrOverImg { get; set; }       //上传后

        public Guid OrNumber { get; set; }      //订单编号

        public DateTime OrFatime { get; set; }      //发布时间

        public bool OrState { get; set; }       //订单状态

        public int Orlike { get; set; }     //点赞

        public int Orcollect { get; set; }      //收藏

        public int Orattention { get; set; }        //关注
    }
}
