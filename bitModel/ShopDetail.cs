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
        public string DeScource { get; set; }//订单来源
        public int DeState { get; set; }//订单状态
    }
}
