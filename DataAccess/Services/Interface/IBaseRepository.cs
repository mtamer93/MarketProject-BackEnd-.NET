﻿using ApplicationCore.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetByDefaultsAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByDefaultAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task<List<TResult>> GetFilteredListAsync<TResult>
            (
                Expression<Func<T, TResult>> select,
                Expression<Func<T, bool>> where = null,
                Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null,
                Func<IQueryable<T>, IIncludableQueryable<T,object>> join = null
            );

    }
}
