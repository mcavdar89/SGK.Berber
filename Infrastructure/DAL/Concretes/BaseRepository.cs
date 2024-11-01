﻿using AutoMapper;
using Infrastructure.DAL.Abstracts;
using Infrastructure.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DAL.Concretes
{
    public class BaseRepository : IBaseRepository
    {
        private DbContext _context;
        private IMapper _mapper;
        public BaseRepository(DbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Add,Update,Delete,Save

        public void Add<T>(T entity) where T : BaseEntity, new()
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
        public async Task<T> GetAsync<T>(
           Expression<Func<T, bool>>? filter = null          
           ) where T : BaseEntity, new()
        {
            IQueryable<T> dbSet = _context.Set<T>();

            if (filter != null)
            {
                dbSet = dbSet.Where(filter);
            }

            return await dbSet.FirstOrDefaultAsync();

        }

        public async Task<TDto> GetProjectAsync<TEntity, TDto>(
          Expression<Func<TEntity, bool>>? filter = null
          
          ) where TEntity : BaseEntity, new()
        {
            IQueryable<TEntity> dbSet = _context.Set<TEntity>();

            if (filter != null)
            {
                dbSet = dbSet.Where(filter);
            }
           
            return await _mapper.ProjectTo<TDto>(dbSet).FirstOrDefaultAsync();

        }

        public async Task<List<T>> ListAsync<T>(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
            )where T : BaseEntity, new()
        {
           IQueryable<T> dbSet = _context.Set<T>();

            if(filter != null)
            {
                dbSet = dbSet.Where(filter);
            }
            if(orderBy != null)
            {
                dbSet = orderBy(dbSet);
            }

            return await dbSet.ToListAsync();

        }
        public async Task<List<TDto>> ListProjectAsync<TEntity,TDto>(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null
            ) where TEntity : BaseEntity, new()
        {
            IQueryable<TEntity> dbSet = _context.Set<TEntity>();

            if (filter != null)
            {
                dbSet = dbSet.Where(filter);
            }
            if (orderBy != null)
            {
                dbSet = orderBy(dbSet);
            }
           return await _mapper.ProjectTo<TDto>(dbSet).ToListAsync();

        }


        #endregion




    }
}
