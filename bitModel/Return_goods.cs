using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Return_goods

    {

        //退货单

        public int ReId   { get; set; }//退货id
        public int Retime { get; set; }//发起时间
        public string ReDate { get; set; }//退货日期
        public int ReTId { get; set; }//退货单号

        public int ReState { get; set; }//退货状态
        public string Re_Buying { get; set; }//外键（供应商名称）

        public int RePeople { get; set; }//退货仓库（外键）
        public string Restyle { get; set; }//退货方式
        public string ReTPeople { get; set; }//退货联系人
        public string ReWId { get; set; }//外键（退货单详情表）

    }
}
