using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class User_Address
    {
        public int AID { get; set; }//ID
        public string Aname { get; set; }//收货人
        public string Aphone { get; set; }//电话号码
        public string Address { get; set; }//收取地址
        public int Shop_ID { get; set; }//商品表ID
    }
}
