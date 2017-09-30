using SweetRong2.IReporsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SweetRong2.Domain;
using System.Data.Entity;

namespace SweetRong2.Repository
{
    public class BaseRepository<T> where T : class
    {

        //private DataModelContainer _dbContext = new DataModelContainer();
        private DbContext _dbContext = EFContextFactory.GetCurrentDbContext();
        public void AddEntity(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void UpdateEntity(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeleteEntity(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;

        }

        public IEnumerable<T> LoadEntities(Func<T, bool> whereLambda)
        {
            return _dbContext.Set<T>().Where(whereLambda);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页总记录</param>
        /// <param name="total">总共多少记录</param>
        /// <param name="whereLambda"></param>
        /// <param name="isAsc">升序</param>
        /// <param name="orderByLambda"></param>
        /// <returns></returns>
        public IEnumerable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderByLambda)
        {
            IEnumerable<T> temp = LoadEntities(whereLambda);
            //排序,获取当前页的数据
            if (isAsc)
            {
                temp = temp.OrderBy<T, S>(orderByLambda)
                     .Skip<T>(pageSize * (pageIndex - 1)) //越过多少条
                     .Take<T>(pageSize); //取出多少条
            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1)) //越过多少条
                    .Take<T>(pageSize); //取出多少条
            }
            total = temp.Count();
            return temp;
        }
    }

}
