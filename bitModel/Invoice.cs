using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Invoice //发票表
    {
        public int Vid { get; set; }

        //单位名称
        public string Unit { get; set; }

        //纳税号
        public string Tax { get; set; }

        //开户银行
        public string Bank { get; set; }

        //地址
        public string Bankurl { get; set; }

        //是否含税
        public bool Duty { get; set; }

        //税率
        public string Rate { get; set; }
    }
}
