using SweetRong2.IReporsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SweetRong2.Domain;

namespace SweetRong2.Repository
{
    public class BaseRepository<T> where T : class
    {

        private DataModelContainer _dbContext = new DataModelContainer();
        public T AddEntity(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> LoadEntities(Func<T, bool> whereLambda)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderByLambda)
        {
            throw new NotImplementedException();
        }
    }

}
