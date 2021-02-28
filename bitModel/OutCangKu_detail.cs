using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
   public class OutCangKu_detail

    {
        //出库详情表
        public int OdId { get; set; }//出库详情id
        public string OdNumber { get; set; }//订单编号
        public string OdAddress { get; set; }//收货地址
        public int OdStyle { get; set; }//配送方式
        public int OdCangku { get; set; }//出货仓库
        public string OdPeople { get; set; }//收货人
        public string OdPhone { get; set; }//联系方式
        public string OdPalyer { get; set; }//打包员
        public string OdSpecit { get; set; }//规格

        public string Odunit { get; set; }//单位
        public int Oddlery { get; set; }//出库数量
        public int OdStock { get; set; }//库存量
        public int OdValue { get; set; }//出库预警值
    }
}
