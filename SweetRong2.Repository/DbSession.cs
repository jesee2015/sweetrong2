using SweetRong2.IReporsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.Repository
{
    public class DbSession
    {
        public IUserRepository UserRepository
        {
            get { return new UserRepository(); }
        }

        public IProductRepository ProductRepository
        {
            get { return new ProductRepository(); }
        }

        public int SaveChanges()
        {
            //调用ef的上下文处理
            return 0;
        }
    }
}
