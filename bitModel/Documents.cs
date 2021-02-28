using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Documents //证件表
    {
        public int Did { get; set; }

        //营业执照
        public string Doing { get; set; }

        //食品安全执照
        public string FoodImg { get; set; }

        //证件照
        public string NumberImg { get; set; }
    }
}
