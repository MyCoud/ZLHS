using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using bitModel;
using Microsoft.Data.SqlClient;

namespace bitDal
{
    public class SunjcDal
    {
        SqlConnection conn = new SqlConnection("data source=192.168.0.100\\MSSQLSERVERSUN;User ID=lishibin;pwd=123456;Initial Catalog=ERP");


        public List<Supplier> GongYingShangListShow(out int total, string SupplierBh = null, string CreateDate = null, string SupplierForm = null, string FuZeRen = null,
         string Danwei = null, string Pinpai = null, string Jingying = null)
        {
            string sql = "select * from Supplier where 1=1 ";

            if (SupplierBh != null)
            {
                sql += $"and   LoCode like '%{SupplierBh}%' ";
            }
            if (CreateDate != null)
            {
                sql += $" and  CreateTime like '%{CreateDate}%'";
            }
            if (SupplierForm != null)
            {
                sql += $"and  LoScouce like '%{SupplierForm}%' ";
            }
            if (FuZeRen != null)
            {
                sql += $"and  linkman like '%{FuZeRen}%' ";
            }
            if (Danwei != null)
            {
                sql += $"and  LoCompany like '%{Danwei}%' ";
            }
            if (Pinpai != null)
            {
                sql += $" and  Lobrand like '%{Pinpai}%' ";
            }
            if (Jingying != null)
            {
                sql += $" and  Loscope Like '%{Jingying}%'";
            }
            List<Supplier> data = conn.Query<Supplier>(sql).ToList();
            total = data.Count;
            return conn.Query<Supplier>(sql).ToList();
        }

        public int CreateSupplier(Supplier Model)
        {
            string sql = $"insert into Supplier values('{Model.Lname}','{Model.LoCode}','{Model.LoScouce}','{Model.LoCompany}','{Model.LoSonComp}','{Model.Lobrand}','{Model.Loclassify}'" +
               $",'{Model.Loscope}','{Model.linkman}','{Model.Lojob}','{Model.LoPhone}','{Model.LoTelPhone}','{Model.Fax}','{Model.Email}','{Model.LoQQ}'," +
               $"'{Model.LoWeixin}',{Model.City_Id},'{Model.LoWhere}','{Model.Losit}','{Model.Lourl}',{DateTime.Now:yyyy-MM-dd},{0})";
            return conn.Execute(sql);
        }

        public int CreateInvoice(Invoice Model)
        {
            string sql = $"insert into Invoice values ('{Model.Unit}','{Model.Tax}','{Model.Bank}','{Model.Bankurl}',{(Model.Duty == true ? 1 : 0)},'{Model.Rate}')";
            return conn.Execute(sql);
        }

        public List<Supplier> BindList()
        {
            string sql = $"Select * from Supplier";
            return conn.Query<Supplier>(sql).ToList();
        }

        public int UpdateAudit(int Uid)
        {
            string sql = $"Update Supplier set Audit = 1 where LId = {Uid}";
            return conn.Execute(sql);
        }
        public List<Supplier> ReturnGetListSupplier(int Uid)
        {
            string sql = $"select * from Supplier where LId = {Uid}";
            return conn.Query<Supplier>(sql).ToList();
        }
        public int UpdateSupplier(Supplier Model,int Uid)
        {
            string sql = $"Update Supplier Set  Lname = '{Model.Lname}' ,Locode='{Model.LoCode}',LoScouce='{Model.LoScouce}',LoCompany='{Model.LoCompany}',LoSonComp='{Model.LoSonComp}'," +
                $"Lobrand= '{Model.Lobrand}', Loclassify='{Model.Loclassify}'" +
               $",Loscope = '{Model.Loscope}' ,linkman='{Model.linkman}',Lojob='{Model.Lojob}',LoPhone='{Model.LoPhone}',LoTelPhone='{Model.LoTelPhone}'," +
               $"Fax='{Model.Fax}',Email='{Model.Email}',LoQQ='{Model.LoQQ}'," +
               $"LoWeixin='{Model.LoWeixin}',City_Id={Model.City_Id}, LoWhere='{Model.LoWhere}',Losit='{Model.Losit}',Lourl='{Model.Lourl}' where Lid = {Uid} ";
            return conn.Execute(sql);
        }
        public List<ShopTab> GetShopTabs()
        {
            string sql = $"select * from ShopTab";
            return conn.Query<ShopTab>(sql).ToList();
        }

        public int DeleteShopTab(int Uid)
        {
            string sql = $"Delete  ShopTab where ShopId = {Uid}";
            return conn.Execute(sql);
        }
        public int CreateBuying(Buying Model)
        {
            string sql = $"insert into Buying values('{Model.BuyingDate}',{Model.BuyingState},'{Model.BuyingFPeople}','{Model.BuyingSPeople}'" +
                $",'{Model.BuyingContent}','{Model.BuyingAddress}','{Model.BuyingPeople}','{Model.BuyingDepartment}','{Model.Buying_AddId}')";
            return conn.Execute(sql);
        }
        public int CreatePurchase(Purchase Model)
        {
            string sql = $"insert into Purchase values('{Model.PurchaseDate}','{Model.Purchase_BuyingId}'{Model.Purchase_SupplierId}," +
                $"'{Model.Purchase_SupplierName}',{Model.Purchase_HaveTax},'{Model.Purchase_Tax}','{Model.Purchase_Site}','{Model.Purchase_Compile}','{Model.Purchase_Department},default(0)')";
            return conn.Execute(sql);
        }

        public List<Purchase> GetPurchaseDate(out int total,string PurchaseState=null , string PuchaseTime=null,string SupName=null,string Fzr=null)
        {
            string sql = $"Select * from Purchase where 1=1 ";
            if (PurchaseState != null)
            {
                sql += $"and   LoCode like '%{PurchaseState}%' ";
            }
            if (PuchaseTime != null)
            {
                sql += $" and  CreateTime like '%{PuchaseTime}%'";
            }
            if (SupName != null)
            {
                sql += $"and  LoScouce like '%{SupName}%' ";
            }
            if (Fzr != null)
            {
                sql += $"and  linkman like '%{Fzr}%' ";
            }

            List<Purchase> data = conn.Query<Purchase>(sql).ToList();
            total = data.Count;
            return conn.Query<Purchase>(sql).ToList();

        }
        //获取请购单
        public List<Buying> GetBuyings()
        {
            string sql = "select  a.BuyingDate,a.BuyingId,BuyingState,a.BuyingFPeople,a.BuyingSPeople,a.BuyingContent, * from Buying a";
            return conn.Query<Buying>(sql).ToList();
        }
    }
}
