using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bitModel;
using bitDal;
namespace bitBLL
{
   public class LictBLL
    {
        LictbDal dal = new LictbDal();
        //获取商品列表所有数据
        public List<ShopTab> GetShopTabs(int ShopCoutID, string ShopName, int Shop_Pid, int ShopSpState)
        {
            return dal.GetShopTabs(ShopCoutID,ShopName,Shop_Pid,ShopSpState);
        }
   
        //添加商品信息
        public int AddShops(ShopTab t)
        {
            return dal.AddShops(t);
        }
        //上传图片
        public int AddImgs(ShopImg s)
        {
            return dal.AddImgs(s);
        }
        //添加商品说明
        public int Addtext(ShopImg s)
        {
            return dal.Addtext(s);
        }
        //添加商品属性
        public int AddOnTe(ShopFen s)
        {
            return dal.AddOnTe(s);
        }
        //获取商品属性
        public List<ShopFen> GetFens()
        {
            return dal.GetFens();
        }
    }
}
