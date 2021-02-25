using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Enterprise     //企业资料表
    {
        public int EId { get; set; }        //企业ID

        public string EnterName { get; set; }  //企业名称

        public bool Business { get; set; }   //企业性质

        public bool EnterSpeciality { get; set; }    //企业规模

        public int EnterpriseScale { get; set; }    //所在地外键

        public int City_id { get; set; }        //详细地址

        public string Addresss { get; set; }   //联系人

        public string EnterProfile { get; set; }   //联系人电话

        public string LinkMan { get; set; }    //座机

        public string LinkManPhone { get; set; }   //标签

        public string Telephone { get; set; }      //外键  用于和Entel连接

        public bool Lable { get; set; }

        public bool Enter_id { get; set; }
    }
}
