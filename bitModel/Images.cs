using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitModel
{
    public class Images

    {
        public Images()
        {
            IsDelete = false;
        }
        public int ImId { get; set; }
        public string Name { get; set; } //图片名
        public string Url { get; set; } //路径
        public bool IsDelete { get; set; }//是否删除


    }

}
