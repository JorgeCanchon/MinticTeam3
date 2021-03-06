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

        public IQueryable<T> FindAll() =>
            Context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            Context.Set<T>().Where(expression).AsNoTracking();

        public T FindById(int id) =>
            Context.Set<T>().Find(id);
            
        public T Update(T entity)
        {
            Context.Attach(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public T Delete(int id)
        {
            var entity = Context.Set<T>().Find(id);
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();

            return entity;
        }

        public T Delete2(T entity)
        {
            Context.Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
            return entity;
        }
    }
}
