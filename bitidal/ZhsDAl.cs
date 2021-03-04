using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
    
using bitModel;
using System.Data.SqlClient;

namespace bitidal
{
  public  class ZhsDAl
    {
        SqlConnection conn = new SqlConnection("data source=192.168.0.100\\MSSQLSERVERSUN;User ID=lishibin;pwd=123456;Initial Catalog=ERP");
        //注册
        public int Zhuce(PLogins s)
        {
            string sql = $"insert into PLogins values ('{s.LoginPhone}','{s.LoginCode}','{s.LoginPass}','{null}','{null}')";
            return conn.Execute(sql);
        }
        //登录
        public int GetReuslt(string LoginPhone, string LoginPass)
        {
            string sql = $"select count(1) from PLogins where LoginPhone = '{LoginPhone}' and LoginPass= '{LoginPass}'";
            return Convert.ToInt32(conn.ExecuteScalar(sql));
        }
    }
}
