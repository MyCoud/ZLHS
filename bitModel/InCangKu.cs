using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class InCangKu

    {
        //入库表
  


        public int Icid { get; set; }//入库ID
        public DateTime Ictime { get; set; }//入库日期


        public string IcNUmber { get; set; }//入库单编号
        public int Ic_CaiId { get; set; }//采购单编号
        public int Icstate { get; set; }//入库状态
        public string Icstyle        { get; set; }//入库类型
        public int Ic_BuyingId { get; set; }//供应商编号
        public int Ic_Inid { get; set; }//入货仓库
        public string Icshou { get; set; }//收货员
        public string Iccang { get; set; }//仓管员
        }
}
