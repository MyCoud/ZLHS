using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bitidal;
using bitModel;
namespace bitibll
{
  public  class ZhsbLL
    {
        ZhsDAl dal = new ZhsDAl();
        //注册
        public int Zhuce(PLogin s)
        {
            return dal.Zhuce(s);
        }
    }
}
