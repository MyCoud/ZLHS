using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Purchase

    {
        //采购单表


        public int PurchaseId { get; set; }//采购id
        public int PurchaseTime { get; set; }//发起日期
        public string PurchaseBid { get; set; }//采购单编号
        public int PurchaseState { get; set; }//采购单状态

        public int Purchase_supplierId { get; set; }//供应商编号（供应商外键）
        public string PurchaseName { get; set; }//供应商名称

        public int PurchaseQPeople { get; set; }//请购负责人
        public string PurchaseCPeople { get; set; }//采购处理人
        public string PurchaseSPeople { get; set; }//采购审核人
        public string PurchaseCSPeople { get; set; }//财务审核人
        public int PFId { get; set; }//外键（采购单详情）
    }
}


