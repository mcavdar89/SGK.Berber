using Infrastructure.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DAL.Concretes
{
    public class BaseRepository
    {
        private DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        #region Add,Update,Delete,Save

        public void Add<T>(T entity) where T : BaseEntity,new()
        {
            _context.Set<T>().Add(entity);
            
        }
        public void Update<T>(T entity) where T : BaseEntity, new()
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete<T>(T entity) where T : BaseEntity, new()
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        #endregion
        #region Select

        public async Task<T> GetByIdAsync<T>(int id) where T : BaseEntity, new()
        {
            return await _context.Set<T>().FindAsync(id);
        } 
        #endregion




    }
}
