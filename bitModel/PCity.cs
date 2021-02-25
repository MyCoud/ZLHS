using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class PCity    //城市表
    {
        public int Id { get; set; }     //Id主键

        public string CitName { get; set; }     //城市名

        public int PId { get; set; }       //副Id
    }
}
