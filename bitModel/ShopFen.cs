using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    //商品分类表
   public class ShopFen
    {
 
        public int Fid { get; set; }//ID

        public string Fname { get; set; }//商品分类名称

        public int Pid { get; set; }//父级ID
        public int Size { get; set; }//大小
       
        public string FNameEass     { get; set; }
        public int Color { get; set; }//颜色
        public int Kucun      { get; set; }//库存
                                           //外键
        public int ShoId { get; set; }//ID
     
        public string Shop_Unit { get; set; }//商品单位表

        public decimal Shop_Clear { get; set; }//商品出售价格
        public string ShopKuState { get; set; }//商品库存

    }
}
