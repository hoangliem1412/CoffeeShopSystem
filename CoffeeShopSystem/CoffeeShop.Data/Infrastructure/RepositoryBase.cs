using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private CoffeeShopDbContext dbContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }
        protected CoffeeShopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = new CoffeeShopDbContext()); }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = dbContext.Set<T>();

        }


        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                dbSet.Remove(obj);
            }
        }

        public virtual T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual T GetSingleByCondition(Expression<Func<T, bool>> where, string[] includes = null)
        {
            return GetAll(includes).FirstOrDefault(where);
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where<T>(where).ToList<T>();
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }

        public virtual IQueryable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() >= 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.AsQueryable();
            }
            return dbContext.Set<T>().AsQueryable();
        }

        IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() >= 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.AsQueryable();
            }
            return dbContext.Set<T>().Include(predicate).AsQueryable();
        }

    }
}
