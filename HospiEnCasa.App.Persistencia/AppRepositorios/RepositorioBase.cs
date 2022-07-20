using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HospiEnCasa.App.Persistencia
{
    public abstract class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected DbContext Context { get; set; }

        protected RepositorioBase(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public T Create(T entity)
        {
            T result = Context.Set<T>().Add(entity).Entity;
            Context.SaveChanges();
            return result;
        }

        public bool Delete(T entity)
        {
            var result = Context.Set<T>().Remove(entity).State;
            Context.SaveChanges();
            return result == EntityState.Deleted;
        }

        public IQueryable<T> FindAll() =>
            Context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            Context.Set<T>().Where(expression).AsNoTracking();
        public T FindById(int id) =>
            Context.Set<T>().Find(id);
        public bool Update(T entity, string propertyName)
        {
            Context.Entry<T>(entity).Property(propertyName).IsModified = false;
            var result = Context.Set<T>().Update(entity).State;
            Context.SaveChanges();
            return result == EntityState.Modified;
        }
    }
}
