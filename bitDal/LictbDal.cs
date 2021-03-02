using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using bitModel;
namespace bitDal
{
    public class LictbDal
    {

        SqlConnection conn = new SqlConnection("data source=192.168.0.100\\MSSQLSERVERSUN;User ID=lishibin;pwd=123456;Initial Catalog=ERP");
        //获取商品列表所有数据//根据商品编号,商品名称，商品品牌，商品状态查询多条件查询
        public List<ShopTab> GetShopTabs(int ShopCoutID, string ShopName, int Shop_Pid, int ShopSpState)
        {
            string sql = "select a.ShopCoutID,a.ShopName,a.Shop_Tid,a.Shop_Stock,a.Shop_Pid,a.Shop_Sid," +
                "a.ShopKuState,a.ShopSpState,b.Fname,c.Size,c.Color,c.Fname,d.Timg " +
                "from ShopTab a join Shopbrand b on a.Shop_Pid = b.Fid join ShopFen c on c.Fid" +
                " = a.Shop_Pid join ShopImg d on d.Tid = a.Shop_Tid where 1=1 ";
            if (ShopCoutID != 0)
            {
                sql += $"and ShopCoutID={ShopCoutID} ";
            }
            if (!string.IsNullOrEmpty(ShopName))
            {
                sql += $"and ShopName like '{ShopName}' ";

            }
            if (ShopSpState != 0)
            {
                sql += $"and ShopSpState={ShopSpState} ";

            }
            return conn.Query<ShopTab>(sql).ToList();
        }
     
        //添加商品信息
        public int AddShops(ShopTab t)
        {
            string sql = $"insert into ShopTab values ('{t.ShopCoutID}','{t.ShopName}','{0}','{t.Shop_Pid}','{t.Shop_Sid}','{null}','{0}','{t.Shopdate}','{0}','{t.Shop_Clear}','{t.Shop_Unit}')";
            return conn.Execute(sql);
        }
        //上传图片
        public int AddImgs(ShopImg s)
        {
            string sql = $"insert into ShopImg values ('{null}','{s.Timg}')";
            return conn.Execute(sql);
        }
        //添加商品说明
        public int Addtext(ShopImg s)
        {
            string sql = $"insert into ShopImg values ('{s.Texplain}','{null}')";
            return conn.Execute(sql);
        }
    }
}
