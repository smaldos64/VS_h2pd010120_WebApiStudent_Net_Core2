using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WebApiStudent_Net_Core2.Models
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DatabaseContext RepositoryContext { get; set; }

        public RepositoryBase(DatabaseContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        //public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        //{
        //    ParameterExpression s = Expression.Parameter(typeof(T));
        //    return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        //}

        public List<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            ParameterExpression s = Expression.Parameter(typeof(T));
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToList();
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
