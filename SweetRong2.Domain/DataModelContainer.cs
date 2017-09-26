using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.Domain
{
    public class DataModelContainer : DbContext
    {
        public DataModelContainer()
            : base("SweetRong2Context")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
