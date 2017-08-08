using CoffeeShop.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoffeeShop.Service
{
    public abstract class Service<T> : IService<T> where T : class
    {
        IRepository<T> repository;
        IUnitOfWork uot;

        public Service(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.uot = unitOfWork;
        }

        public T Add(T group)
        {
            return repository.Add(group);
        }

        public T Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<T> GetAll()
        {
            return repository.GetAll();
        }

        public T GetByID(int id)
        {
            return repository.GetSingleById(id);
        }

        public void Update(T group)
        {
            repository.Update(group);
        }

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return repository.CheckContains(predicate);
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            return repository.Count(where);
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            return repository.GetAll(includes);
        }

        public IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            return repository.GetMulti(predicate, includes);
        }

        public IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            return repository.GetMultiPaging(filter, out total, index, size, includes);
        }

        public T GetsingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            return repository.GetsingleByCondition(expression, includes);
        }

        public T GetSingleById(int id)
        {
            return repository.GetSingleById(id);
        }

        public T Delete(T entity)
        {
            return repository.Delete(entity);
        }
    }
}
