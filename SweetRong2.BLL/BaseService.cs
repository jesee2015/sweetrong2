﻿using SweetRong2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.BLL
{
    public abstract class BaseService<T> where T : class
    {
        public IReporsitory.IBaseRepository<T> _currentRepository;
        public DbSession _DbSession = new DbSession();
        public BaseService()
        {
            SetCurrentRepository();
        }

        public abstract void SetCurrentRepository();

        public T AddEntity(T entity)
        {
            //调用T对应的仓储来做添加工作
            _currentRepository.AddEntity(entity);
            _DbSession.SaveChanges();
            return entity;
        }

        //实现对数据库的修改功能
        public bool UpdateEntity(T entity)
        {
            _currentRepository.UpdateEntity(entity);
            return _DbSession.SaveChanges() > 0;
        }

        //实现对数据库的删除功能
        public bool DeleteEntity(T entity)
        {
            _currentRepository.DeleteEntity(entity);
            return _DbSession.SaveChanges() > 0;
        }

        //实现对数据库的查询  --简单查询
        public IEnumerable<T> LoadEntities(Func<T, bool> whereLambda)
        {
            return _currentRepository.LoadEntities(whereLambda);
        }

        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <typeparam name="S">按照某个类进行排序</typeparam>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="total">总条数</param>
        /// <param name="whereLambda">取得排序的条件</param>
        /// <param name="isAsc">如何排序，根据倒叙还是升序</param>
        /// <param name="orderByLambda">根据那个字段进行排序</param>
        /// <returns></returns>
        public IEnumerable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderByLambda)
        {
            return _currentRepository.LoadPageEntities(pageIndex, pageSize, out total, whereLambda, isAsc, orderByLambda);
        }
    }
}
