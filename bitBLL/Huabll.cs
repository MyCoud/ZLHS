
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bitDal;
using bitModel;

namespace bitBLL
{
    public class Huabll
    {
        //实例化dal层
        HuaDAL dal = new HuaDAL();
        //显示数据列表
        //订单号 订单状态 用户账号的查询
        public List<ShopDetail> GetShopDetail(out int totalcount, string bid, string name, string statid, string sourid)
        {
            return dal.GetShopDetail(out totalcount,bid, name, statid, sourid);
        }

        //添加订单表
        public int AddShopDetail(ShopDetail sp)
        {
            return dal.AddShopDetail(sp);
        }

        //订单状态绑定下拉
        public List<Stat> BindState()
        {
            return dal.BindState();
        }

        //订单来源绑定下拉
        public List<Source> BindSource()
        {
            return dal.BindSource();
        }
        //确认收货(显示)
        public List<ShopDetail> GetConfig(out int totalcount, string bid, string name, string statid, string sourid)
        {
            return dal.GetConfig(out totalcount,bid,name,statid,sourid);
        }

        //确认收货(删除)
        public int DelConfirm(string id)
        {
            return dal.DelConfirm(id);
        }

        //确认收货(修改)
        public int UpdateConfirm(string id)
        {
            return dal.UpdateConfirm(id);
        }

        //反填
        public List<ShopDetail> FanConfirm(string id)
        {
            return dal.FanConfirm(id);
        }

    }

}
