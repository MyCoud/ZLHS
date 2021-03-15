using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bitModel;
using bitDal;

namespace bitBLL
{
    public class SunJcBll
    {
        SunjcDal dal = new SunjcDal();
        public int CreateSupplier(Supplier Model)
        {
            return dal.CreateSupplier(Model);
        }


        public int CreateInvoice(Invoice Model)
        {
            return dal.CreateInvoice(Model);
        }

        public List<Supplier> GongYingShangListShow(out int total,string SupplierBh = null, string CreateDate = null, string SupplierForm = null, string FuZeRen = null,
        string Danwei = null, string Pinpai = null, string Jingying = null)
        {
            return dal.GongYingShangListShow(out total,SupplierBh, CreateDate, SupplierForm, FuZeRen, Danwei, Pinpai, Jingying);
        }

        public List<Supplier> BindList()
        {
            return dal.BindList();
        }

        public int UpdateAudit(int Uid)
        {
            return dal.UpdateAudit(Uid);
        }
        public List<Supplier> ReturnGetListSupplier(int Uid)
        {
            return dal.ReturnGetListSupplier(Uid);
        }
        public int UpdateSupplier(Supplier Model,int Uid)
        {
            return dal.UpdateSupplier(Model,Uid);
        }

        public List<ShopTab> GetShopTabs()
        {
            return dal.GetShopTabs();
        }

        public int DeleteShopTab(int Uid)
        {
            return dal.DeleteShopTab(Uid);
        }
        public int CreateBuying(Buying Model)
        {
            return dal.CreateBuying(Model);
        }
        public int CreatePurchase(Purchase Model)
        {
            return dal.CreatePurchase(Model);
        }

        public List<Purchase> GetPurchaseDate(out int total, string PurchaseState = null, string PuchaseTime = null, string SupName = null, string Fzr = null)
        {
            return dal.GetPurchaseDate(out total,PurchaseState, PuchaseTime, SupName, Fzr);
        }
        //获取请购单
        public List<Buying> GetBuyings()
        {
            return dal.GetBuyings();
        }
    }


}
