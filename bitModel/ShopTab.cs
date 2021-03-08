using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    //商品表
    public class ShopTab
    {


        public int ShopId { get; set; }//ID
        public int ShopCoutID { get; set; }//商品编号
        public string ShopName { get; set; }//商品名称
        public int Shop_Tid { get; set; }//商品图片
        public int Shop_Pid { get; set; }//商品品牌
        public string Name { get; set; } //外键商品品牌名

        public int Shop_Sid { get; set; }//商品属性

        public string Fname        { get; set; } //外键商品分类

        public string ShopKuState { get; set; }//库存状态
        public int ShopSpState        { get; set; }//商品状态
        public DateTime Shopdate { get; set; }//商品上架时间
        public decimal Shop_Stock { get; set; }//商品进货价格

        public decimal Shop_Clear { get; set; }//商品出售价格

        public string Shop_Unit { get; set; }//商品单位表

    }
}
