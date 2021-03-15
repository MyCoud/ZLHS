using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class ShopDetail
    {
        public int Did { get; set; }//订单主键
        public string DboId { get; set; }//订单编号
        public DateTime Dtime { get; set; }//提交时间
        public int Login_Id { get; set; }//用户账号
        public string Depay { get; set; }//支付方式
        public int DeScourceId { get; set; }//订单来源
        public int DeStateId { get; set; }//订单状态
        public int LoginId { get; set; }//Id主键
        public string DName { get; set; }//订单来源
        public string SName { get; set; }//订单状态
        public string LoginName { get; set; }
        public int Moneys { get; set; }
        public bool confirm { get; set; }
    }
}
