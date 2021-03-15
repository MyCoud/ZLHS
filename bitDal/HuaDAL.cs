using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using bitModel;

namespace bitDal
{
    public class HuaDAL
    {

        //订单报表
        SqlConnection conn = new SqlConnection("data source=192.168.0.100\\MSSQLSERVERSUN;User ID=lishibin;pwd=123456;Initial Catalog=ERP");
        //显示数据列表
        public List<ShopDetail> GetShopDetail(out int totalcount,string bid, string name,string statid,string sourid)
        {
            string sql = "select Did,DboId,Dtime,LoginName,Moneys,Depay,DName,SName,confirm from ShopDetail a join Source b on a.DeScourceId=b.DeScourceId join Stat c on a.DeStateId=c.DeStateId join PLogins d on a.LoginId=d.LoginId where 1=1";
            //查询订单号
            if (!string.IsNullOrEmpty(bid))
            {
                sql += $" and DboId='{bid}'";
            }
            //查询用户账号
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and LoginName like '%{name}%'";
            }
            if (!string.IsNullOrEmpty(statid) && statid !="0")
            {
                sql += $" and SName='{statid}'";
            }
            if (!string.IsNullOrEmpty(sourid) && sourid !="0")
            {
                sql += $" and DName='{sourid}'";
            }
            List<ShopDetail> data = conn.Query<ShopDetail>(sql).ToList();
            totalcount = data.Count();
            return conn.Query<ShopDetail>(sql).ToList();
        }

        //添加订单表
        public int AddShopDetail(ShopDetail sp)
        {
            string sql = $"insert into ShopDetail values('{sp.DboId}','{sp.Dtime}','{sp.LoginId}','{sp.Moneys}','{sp.Depay}','{sp.DeScourceId}','{sp.DeStateId}','{sp.confirm}')";
            return conn.Execute(sql);
        }


        //订单状态绑定下拉
        public List<Stat> BindState()
        {
            string sql = "select * from Stat";
            var list =  conn.Query<Stat>(sql).ToList();
            return list;
        }

        //订单来源绑定下拉
        public List<Source> BindSource()
        {
            string sql = "select * from Source";
            var list = conn.Query<Source>(sql).ToList();
            return list;
        }

        //确认收货的显示页面
        public List<ShopDetail> GetConfig(out int totalcount, string bid, string name, string statid, string sourid)
        {
            string sql = "select DIdDboId,Dtime,LoginName,Moneys,Depay,DName,SName,confirm from ShopDetail a join Source b on a.DeScourceId=b.DeScourceId join Stat c on a.DeStateId=c.DeStateId join PLogins d on a.LoginId=d.LoginId where 1=1";
            //查询订单号
            if (!string.IsNullOrEmpty(bid))
            {
                sql += $" and DboId={bid}";
            }
            //查询用户账号
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and LoginName like '%{name}%'";
            }
            if (!string.IsNullOrEmpty(statid))
            {
                sql += $" and DName='{statid}'";
            }
            if (!string.IsNullOrEmpty(sourid))
            {
                sql += $" and SName='{sourid}'";
            }
            List<ShopDetail> data = conn.Query<ShopDetail>(sql).ToList();
            totalcount = data.Count();
            return conn.Query<ShopDetail>(sql).ToList();
        }

        //确认收货(删除)
        public int DelConfirm(string id)
        {
            string sql = $"delete from ShopDetail where Did={id}";
            return conn.Execute(sql);
        }

        //确认收货(修改)
        public int UpdateConfirm(string id)
        {
            string sql = $"update ShopDetail set confirm-=1 where Did={id}";
            return conn.Execute(sql);
        }

        //反填
        public List<ShopDetail> FanConfirm(string id)
        {
            string sql = $"select Did,DboId,Dtime,LoginName,Moneys,Depay,DName,SName,confirm from ShopDetail a join Source b on a.DeScourceId=b.DeScourceId join Stat c on a.DeStateId=c.DeStateId join PLogins d on a.LoginId=d.LoginId where Did={id}";
            return conn.Query<ShopDetail>(sql).ToList();
        }

    }
}
