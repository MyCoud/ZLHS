using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Buying
    {
        public int BuyingId { get; set; }

        //发起日期
        public DateTime BuyingDate { get; set; }

        //请购单Id
        public Guid BuyingBid { get; set; }

        //请购单状态
        public bool BuyingState { get; set; }

        //请购发起人
        public string BuyingFPeople { get; set; }

        //请购负责人
        public string BuyingSPeople { get; set; }

        //请购单备注
        public string BuyingContent { get; set; }

        //请购单地址
        public string BuyingAddress { get; set; }

        //请购人员
        public string BuyingPeople { get; set; }

        //所在部门 
        public string BuyingDepartment { get; set; }

        //外键
        public int Buying_AddId { get; set; }


    }
}
