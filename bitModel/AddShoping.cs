using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class AddShoping
    {
        public int AddId { get; set; }

        //商品表外键
        public int Add_ShopName { get; set; }

        //规格
        public string AddSpecification { get; set; }

        //请购数量
        public int AddNumber { get; set; }

        //可用量
        public int AddKnumber { get; set; }

        //现有量
        public int AddXNumber { get; set; }

        //商品市场价
        public decimal AddSprice { get; set; }

        //小计
        public int AddCount { get; set; }

    }
}
