using Infrastructure.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #endregion
    }
}
