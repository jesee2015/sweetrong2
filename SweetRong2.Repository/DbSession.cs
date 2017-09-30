using SweetRong2.IReporsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.Repository
{
    public class DbSession:IDbSession
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
            return EFContextFactory.GetCurrentDbContext().SaveChanges();
        }

        public int ExcuteSql(string strSql, System.Data.Common.DbParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
