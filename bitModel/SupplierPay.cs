using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class SupplierPay //供应商付款表
    {
        public int Fid { get; set; }

        //付款方式
        public string SuBuy { get; set; }

        //进货后几天付款
        public string SuDay { get; set; }

        //账单起始日
        public string DateState { get; set; }

        //账期
        public string DateMony { get; set; }

        //支付时限
        public string DatePay { get; set; }
    }
}
