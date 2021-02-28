using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
   public class Keeper
    {
        //仓库表
        public int KOId { get; set; }//仓库Id

        public string Kname { get; set; }//仓库名

        public string Kwhere { get; set; }//仓库位置

        public string Kpeople { get; set; }//仓库员

        public int Area_ID { get; set; }//区域外键

        public int Shelf_Id { get; set; }//货架表

        public int Reat_Id { get; set; }//库位表外键


    }
}
