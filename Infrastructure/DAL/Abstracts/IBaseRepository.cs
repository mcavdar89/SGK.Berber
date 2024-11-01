using Infrastructure.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DAL.Abstracts
{
    public interface IBaseRepository
    {
        #region Add,Update,Delete,Save

        void Add<T>(T entity) where T : BaseEntity,new();
        void Update<T>(T entity) where T : BaseEntity, new();
        void Delete<T>(T entity) where T : BaseEntity, new();

        Task<int> SaveAsync();

        #endregion
        #region Select

        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity, new();
        Task<T> GetAsync<T>(Expression<Func<T, bool>>? filter = null) where T : BaseEntity, new();
        Task<TDto> GetProjectAsync<TEntity, TDto>(Expression<Func<TEntity, bool>>? filter = null) where TEntity : BaseEntity, new();


        Task<List<T>> ListAsync<T>(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
            ) where T : BaseEntity, new();

        Task<List<TDto>> ListProjectAsync<TEntity, TDto>(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null
            ) where TEntity : BaseEntity, new();

        #endregion
    }
}
