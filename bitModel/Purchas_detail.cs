using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Purchas_detail
    {
        //采购单详情表

        public int PdId { get; set; }//采购单ID

        public DateTime PdTime { get; set; }//采购单创建日期

        public int Pd_BuyingId { get; set; }//外键（请购单）

        public int Pd_SupplierId { get; set; }//外键（供应商）


        public int Pd_BuyingTax { get; set; }//商品税

        public string Pd_BuyingRate { get; set; }//商品税率


        public string PdAddress { get; set; }//到货地址


        public string PdBPeople { get; set; }//编辑人员

        public string PdDepart { get; set; }//所在部门

        public int Pd_shopid { get; set; }//外键（商品表）

        public string Pd_shopname { get; set; }//商品名称

        public string Pd_Dan { get; set; }//商品单位

        public int PdCaNumber { get; set; }//采购数量

        public int PdKNumber     { get; set; }//可用量

        public int PdXNumber      { get; set; }//现存量

        public decimal PdCPrice { get; set; }//商品报价

        public float PdZhe { get; set; }//商品采购价

        public decimal PdPrice { get; set; }//商品采购价
        public int PdXiao { get; set; }//小计


    }
}
