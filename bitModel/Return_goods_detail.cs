using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
  public  class Return_goods_detail
    {
        //退货详情表

        public int RgdId { get; set; }//退货详情id
        public DateTime RgdTime { get; set; }//退货单创建日期
        public int Rgd_buyingId { get; set; }//供应商编号
        public string RgdName { get; set; }//供应商名称

        public string RgdAddress { get; set; }//退货地址
        public string RgdPeople { get; set; }//退货联系人

        public int Rgdcang { get; set; }//退货仓库
        public string RgdStyle { get; set; }//退货方式
        public string Rgdtpeople { get; set; }//退货发起人
        public string RgdDepart { get; set; }//所在部门
        public int Rgd_shopid { get; set; }//外键（商品表）
        public string Rgd_shopname { get; set; }//商品名称

        public string Rgd_Dan { get; set; }//商品单位
        public int Rgd_PId { get; set; }//商品批次号
        public int Rgd_Price { get; set; }//采购单价
        public int Rgd_Number { get; set; }//可退货数量
        public decimal Rgd_Money { get; set; }//退货金额

    }
}
