using System;
using System.Collections.Generic;
using System.Text;

namespace bitibll
{
    //写入固定增删改查方法
   public interface IbaseSerive<T>
    {
        //添加接口
        T Add(T entity);
        //删除接口
        bool Delforts(T entity);
        //修改接口
        bool Uptforts(T entity);
        //根据id查询
        List<T> Getforid(T entity);


        //获取所有数据
        List<T> Getformany();
        //带条件查询
        List<T> GetforEncter(T entity);
        //分页
        List<T> GetPage(int PageIndex, int PageSize);
        //分页带条件查询
        List<T> GetPageSelect(int PageIndex, int PageSize, T entity);

    }
}
