﻿using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CoffeeShop.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private CoffeeSystemDbContext dbContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected CoffeeSystemDbContext DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual IEnumerable<Shop> GetMultiPagingForShop(Expression<Func<Shop, bool>> predicate, out int total, int curPage = 1, int pageSize = 20, string sort = "", string type = "")
        {
            int skipCount = (curPage - 1) * pageSize;
            IQueryable<Shop> _resetSet;


            _resetSet = predicate != null ? dbContext.Set<Shop>().Where<Shop>(predicate).AsQueryable() : dbContext.Set<Shop>().AsQueryable();


            switch (sort)
            {
                case "ID":
                    if (type == "asc")
                    {
                        _resetSet = skipCount == 0 ? _resetSet.OrderBy(s => s.ID).Take(pageSize) : _resetSet.OrderBy(s => s.ID).Skip(skipCount).Take(pageSize);


                    }
                    else  // type = default hoặc type = desc
                    {
                        _resetSet = skipCount == 0 ? _resetSet.OrderByDescending(s => s.ID).Take(pageSize) : _resetSet.OrderByDescending(s => s.ID).Skip(skipCount).Take(pageSize);

                    }
                    break;
                case "Name":
                    if (type == "asc")
                    {
                        _resetSet = skipCount == 0 ? _resetSet.OrderBy(s => s.Name).Take(pageSize) : _resetSet.OrderBy(s => s.Name).Skip(skipCount).Take(pageSize);

                    }
                    else
                    {
                        _resetSet = skipCount == 0 ? _resetSet.OrderByDescending(s => s.Name).Take(pageSize) : _resetSet.OrderByDescending(s => s.Name).Skip(skipCount).Take(pageSize);

                    }
                    break;
                case "Address":
                    if (type == "asc")
                    {
                        _resetSet = skipCount == 0 ? _resetSet.OrderBy(s => s.DetailAddress).Take(pageSize) : _resetSet.OrderBy(s => s.DetailAddress).Skip(skipCount).Take(pageSize);

                    }
                    else
                    {
                        _resetSet = skipCount == 0 ? _resetSet.OrderByDescending(s => s.DetailAddress).Take(pageSize) : _resetSet.OrderByDescending(s => s.DetailAddress).Skip(skipCount).Take(pageSize);

                    }
                    break;
                case "Description":
                    if (type == "asc")
                    {
                        _resetSet = skipCount == 0 ? _resetSet.OrderBy(s => s.Description).Take(pageSize) : _resetSet.OrderBy(s => s.Description).Skip(skipCount).Take(pageSize);

                    }
                    else
                    {
                        _resetSet = skipCount == 0 ? _resetSet.OrderByDescending(s => s.Description).Take(pageSize) : _resetSet.OrderByDescending(s => s.Description).Skip(skipCount).Take(pageSize);

                    }
                    break;


                default:
                    break;
            }

            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }

        public virtual T Delete(int id)
        {
            var entity = dbSet.Find(id);
            return dbSet.Remove(entity);
        }

        public virtual T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }


        public virtual T GetSingleById(int? id)
        {   if (id.HasValue == false)
            {
                return null;
            }
            return dbSet.Find(id);
        }

        public virtual T GetsingleByCondition(Expression<Func<T, bool>> where, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.FirstOrDefault(where);
            }
            return dbContext.Set<T>().FirstOrDefault(where);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where<T>(where).ToList<T>();
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }

        public virtual IEnumerable<T> GetAll(string[] includes = null)
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
            return dbContext.Set<T>().AsQueryable<T>();
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() >= 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.Where<T>(predicate).AsQueryable<T>();
            }
            return dbContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;

            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                _resetSet = predicate != null ? query.Where<T>(predicate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = predicate != null ? dbContext.Set<T>().Where<T>(predicate).AsQueryable() : dbContext.Set<T>().AsQueryable();
            }

            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Count<T>(predicate) > 0;
        }
    }
}