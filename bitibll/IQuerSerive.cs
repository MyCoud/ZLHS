using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitibll
{
    public class IQuerSerive<T> : IbaseSerive<T> where T : class
    {
        protected IbaseSerive<T> ibase { get; set; }
        public T Add(T entity)
        {
            return ibase.Add(entity);
        }

        public bool Delforts(T entity)
        {
            return ibase.Delforts(entity);
        }

        public List<T> GetforEncter(T entity)
        {
            return ibase.GetforEncter(entity);
        }

        public List<T> Getforid(T entity)
        {
            return ibase.Getforid(entity);
        }

        public List<T> Getformany()
        {
            return ibase.Getformany();
        }

        public List<T> GetPage(int PageIndex, int PageSize)
        {
            return ibase.GetPage(PageIndex,PageSize);
        }

        public List<T> GetPageSelect(int PageIndex, int PageSize, T entity)
        {
            return ibase.GetPageSelect(PageIndex, PageSize, entity);
        }

        public bool Uptforts(T entity)
        {
            return ibase.Uptforts(entity);
        }
    }
}
