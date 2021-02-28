using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
   public class OutCangKu

    {
        //出库表



        public int Outid { get; set; }//出库ID
        public DateTime Outtime { get; set; }//出库日期
        public string OutNumber { get; set; }//订单编号
        public string Outstyle { get; set; }//配送方式
        public string OutPhone { get; set; }//收货人联系方式
        public string OutArea { get; set; }//配送区域
        public int OutCangId { get; set; }//出货仓库
        public string Outshou { get; set; }//收货员
        public string Outcang { get; set; }//打包员

        public int OutWid { get; set; }//出库详情表
    }
}
