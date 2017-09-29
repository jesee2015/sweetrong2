using SweetRong2.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.Repository
{

    public class EFContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            DbContext dbContext = CallContext.GetData("SweetRong2Context") as DbContext;
            if (dbContext==null)  //线程在数据槽里面没有此上下文
            {
                 dbContext = new DataModelContainer(); //如果不存在上下文的话，创建一个EF上下文
               //我们在创建一个，放到数据槽中去
                 CallContext.SetData("DbContext", dbContext);
             }
             return dbContext;
        }
    }
}
