using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class supplier
    {
        public int Lid { get; set; }//ID
        public string Lname { get; set; }//引进负责人
        public string LoCode { get; set; }//供应商编号
        public string LoScouce { get; set; }//供应商来源
        public string LoCompany { get; set; }//单位名称
        public string LoSonComp { get; set; }//单位简称
        public string Lobrand { get; set; }//品牌
        public string Loclassify { get; set; }//所属分类
        public string Loscope { get; set; }//经营范围
        public string linkman { get; set; }//联系人
        public decimal Lojob { get; set; }//职业
        public string LoPhone { get; set; }//手机号
        public string LoTelPhone { get; set; }//固定电话
        public string LoWeixin { get; set; }//微信
        public int City_Id { get; set; }//所属省市
        public string LoWhere { get; set; }//所在区域
        public string Losit { get; set; }//地址
        public string Lourl { get; set; }//网址
        public string LoEmail { get; set; }//邮件
        public string LoQQ { get; set; }//QQ
    }
}
