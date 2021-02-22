using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace bitDal
{
    public interface BaseUsers<T> where T : class

    {
        IQueryable<T> Table { get; }
        //插入接口
        bool InsertEntiy(T entity);
        //修改接口
        bool UpsertEntity(T entity);
        //删除接口
        bool DelEntity(T entity);
        //添加接口
        bool AddEntity(T entity);
        //带条件查询

        T Get(Expression<Func<T, bool>> where);

        //根据id查询(包括反填)
        T GetEntityid(object Id);
        //查询所有
        IEnumerable<T> GetAllEntity();

        //Ienumerable类型带条件查询
        IQueryable<T> GetAll(Expression<Func<T, bool>> where);
        //分页
        IList<T> GetPage(int PageIndex, int PageSize);
        //分页条件查询
        IList<T> GetSelePage(int PageIndex, int PageSize, Expression<Func<T, bool>> where);

    }
}
