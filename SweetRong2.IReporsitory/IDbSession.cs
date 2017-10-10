using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetRong2.IReporsitory;
using System.Data.Common;

namespace SweetRong2.IRepository
{
    public interface IDbSession
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        int SaveChanges();
        int ExcuteSql(string strSql, DbParameter[] parameters);
    }
}
