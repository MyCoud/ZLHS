using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bitModel;
namespace bitDal
{
    public class MyContext : DbContext

    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
             : base(options)
        {
        }

        public DbSet<Users> _Users { get; set; }
    }
}
