using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioBase<T>
    {
        IQueryable<T> FindAll();
        T FindById(int id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        // bool Update(T entity, string propertyName);
        T Update(T entity);
        bool Delete(T entity);
    }
}
