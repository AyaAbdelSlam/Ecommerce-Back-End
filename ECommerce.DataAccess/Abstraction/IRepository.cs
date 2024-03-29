﻿using ECommerce.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstraction
{
    public interface IRepository<T> where T: IEntity
    {
        Task<T> GetById(int id);

        Task<T> FindFirstByCond(Expression<Func<T, bool>> predicate);

        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);

        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}
