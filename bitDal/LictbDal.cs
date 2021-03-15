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
        //获取商品列表所有数 据//根据商品编号,商品名称，商品品牌，商品状态查询多条件查询
        public List<ShopTab> GetShopTabs(int ShopId, string ShopName,string Name, int ShopSpState)
        {
            string sql = " select a.ShopId, a.ShopCoutID,a.ShopName,a.Shop_Tid,a.Shop_Stock,a.Shop_Pid,a.Shop_Sid,a.ShopKuState" +
                ",a.ShopSpState,b.Name,c.Size,c.Color,c.Fname,d.Texplain from ShopTab a join Shopbrand b " +
                "on a.Shop_Pid = b.Fid join ShopFen c on c.Fid=a.Shop_Pid join ShopImg d on d.Tid = a.Shop_Tid where 1=1 ";
            if (ShopId != 0)
            {
                sql += $"and a.ShopCoutID={ShopId} ";
            }
            if (!string.IsNullOrEmpty(ShopName))
            {
                sql += $"and a.ShopName like '%{ShopName}%' ";

            }
            if (!string.IsNullOrEmpty(Name))
            {
                sql += $"and b.Name like '%{Name}%' ";
            }
            if (ShopSpState != 0)
            {
                sql += $"and a.ShopSpState={ShopSpState} ";
            }
            return conn.Query<ShopTab>(sql).ToList();
        }

        //添加商品信息
        public int AddShops(ShopTab t)
        {
            string sql = $"insert into ShopTab values ('{t.ShopCoutID}','{t.ShopName}','{0}','{t.Shop_Pid}','{t.Shop_Sid}','{t.ShopKuState}','{0}','{t.Shopdate}','{0}','{t.Shop_Clear}','{0}')";
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
        //删除商品属性
        public int Deltext(int id)
        {
            string sql = $"delete from ShopFen where Fid={id} ";
            return conn.Execute(sql);
        }

        //添加商品属性
        public int AddOnTe(ShopFen s)
        {
            string sql = $"insert into ShopFen values ('{s.Fname}','{0}','{s.Size}','{s.Color}','{s.Kucun}','{null}')";
            return conn.Execute(sql);
        }
        //获取商品属性
        public List<ShopFen> GetFens()
        {

            string sql = "select  a.Fid,a.Fname, a.Size,a.Color,b.Shop_Unit,b.ShopId,b.Shop_Clear,b.ShopKuState from ShopFen a join ShopTab b on a.Fid=b.Shop_Sid";
            return conn.Query<ShopFen>(sql).ToList();
        }
        //商品分类编辑
        public int AddFens(ShopFen s)
        {
            string sql = $"insert into ShopFen values ('{s.Fname}','{0}','{0}','{0}','{0}','{s.FNameEass}')";
            return conn.Execute(sql);
        }
        //获取商品分类编辑
        public List<ShopFen> GetToFens(string Fname)
        {
            string sql = "select ShopFen.Fname,Fid,ShopFen.FNameEass  from ShopFen where 1=1 ";
            if (!string.IsNullOrEmpty(Fname))
            {
                sql += $"and Fname like '%{Fname}%' ";
            }
            return conn.Query<ShopFen>(sql).ToList();
        }
        //删除商品属性
        public int DelToFens(int id)
        {
            string sql = $"delete from ShopFen where Fid ={id} ";
            return conn.Execute(sql);
        }
        //编辑商品
        public int EditToFens(ShopFen s)
        {
            string sql = $"Update Shopfen set FName='{s.Fname}',FNameEass='{s.FNameEass}' where Fid={s.Fid} ";
            return conn.Execute(sql);
        }
        //反填商品信息
        public ShopFen SeleToFenId(int id)
        {
            string sql = $"select ShopFen.Fname,ShopFen.Fid,ShopFen.FNameEass  from ShopFen where Fid={id} ";
            return conn.QuerySingle<ShopFen>(sql);
        }
        //获取商品每个价格、所属品牌
        public List<ShopTab> GetSaxFens(string ShopName)
        {
            string sql = "select  a.ShopName,a.Shop_Pid,a.Shop_Sid,a.Shopdate,a.Shop_Stock,a.Shop_Clear," +
                "a.Shop_Unit,a.ShopId,b.Name,c.Fname from ShopTab a " +
                "join Shopbrand b on a.Shop_Pid=b.Fid join ShopFen c on c.Fid=a.Shop_Pid where 1=1 ";
            if (!string.IsNullOrEmpty(ShopName))
            {
                sql += $"and ShopName like '%{ShopName}%' ";
            }
            return conn.Query<ShopTab>(sql).ToList();
        }
        //添加商品价格信息
        public int AddSaxFens(ShopTab s)
        {
            string sql = $"insert into ShopTab values ('{0}','{s.ShopName}','{0}','{s.Shop_Pid}','{s.Shop_Sid}','{null}','{0}','{null}','{s.Shop_Stock}','{s.Shop_Clear}','{s.Shop_Unit}')";
            return conn.Execute(sql);
        }
        //获取商品每个价格、所属品牌
        public ShopTab SaxFensid(int id)
        {
            string sql = "select  a.ShopName,a.Shop_Pid,a.Shop_Sid,a.Shopdate,a.Shop_Stock,a.Shop_Clear," +
                "a.Shop_Unit,a.ShopId,b.Name,c.Fname from ShopTab a " +
                $"join Shopbrand b on a.Shop_Pid=b.Fid join ShopFen c on c.Fid=a.Shop_Sid where a.ShopId={id} ";
            return conn.QuerySingle<ShopTab>(sql);
        }
        //修改
        public int UptSaxFens(ShopTab s)
        {
            string sql = $"Update ShopTab set ShopName='{s.ShopName}',Shop_Pid='{s.Shop_Pid}',Shop_Sid='" +
                $"{s.Shop_Sid}',Shop_Stock='{s.Shop_Stock}',Shop_Clear='{s.Shop_Clear}',Shop_Unit='{s.Shop_Unit}' where ShopId={s.ShopId}";
            return conn.Execute(sql);
        }
        public int SangToJia(int id)
        {
            string sql = $"Update ShopTab set ShopSpState={0} where ShopId ={id} ";
            return conn.Execute(sql);
        }
    }
}
