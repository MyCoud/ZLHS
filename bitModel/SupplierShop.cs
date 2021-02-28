using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class SupplierShop //供应商商品表
    {
        public int Uid { get; set; }

        //商品编号
        public int Sho_Id { get; set; }

        //商品名称
        public string Tax { get; set; }

        //规格
        public string GuiGe { get; set; }

        //单位
        public string Spect { get; set; }
    }
}
