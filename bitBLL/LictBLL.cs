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
        public List<ShopTab> GetShopTabs(int ShopId, string ShopName, string Name, int ShopSpState)
        {
            return dal.GetShopTabs(ShopId, ShopName,Name,ShopSpState);
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
        //商品分类编辑
        public int AddFens(ShopFen s)
        {
            return dal.AddFens(s);
        }
        //获取商品分类编辑
        public List<ShopFen> GetToFens(string Fname)
        {
           
            return dal.GetToFens(Fname);
        }
        //删除商品属性
        public int DelToFens(int id)
        {
            return dal.DelToFens(id);
        }
        //编辑商品
        public int EditToFens(ShopFen s)
        {
            return dal.EditToFens(s);
        }
        //反填商品信息
        public ShopFen SeleToFenId(int id)
        {
            return dal.SeleToFenId(id);
        }
        //获取商品每个价格、所属品牌
        public List<ShopTab> GetSaxFens(string ShopName)
        {
            return dal.GetSaxFens(ShopName);
        }
        //添加商品价格信息
        public int AddSaxFens(ShopTab s)
        {
            return dal.AddSaxFens(s);
        }
     
        //获取商品每个价格、所属品牌
        public ShopTab SaxFensid(int id)
        {
            return dal.SaxFensid(id);
        }
        //删除商品属性
        public int Deltext(int id)
        {
            return dal.Deltext(id);
        }

        //修改
        public int UptSaxFens(ShopTab s)
        {
            return dal.UptSaxFens(s);
        }
        public int SangToJia(int id)
        {
            return dal.SangToJia(id);
        }
    }
}
