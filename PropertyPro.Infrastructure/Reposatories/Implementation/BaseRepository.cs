using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using PropertyPro.Infrastructure.Data;
using PropertyPro.Infrastructure.Reposatories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PropertyPro.Data.Consts;

namespace PropertyPro.Infrastructure.Reposatories.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        //private readonly ApplicationDbContext _dbContext;

        //public BaseRepository(ApplicationDbContext context)
        //{
        //    _dbContext = context;
        //}
        //public T GetById(int id)
        //{
        //    return _dbContext.Set<T>().Find(id);
        //}

        //public IEnumerable<T> GetAll()
        //{
        //    return _dbContext.Set<T>().ToList();
        //}

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    return await _dbContext.Set<T>().ToListAsync();
        //}



        //public async Task<T> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Set<T>().FindAsync(id);
        //}

        //public T Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        //{
        //    IQueryable<T> query = _dbContext.Set<T>();

        //    if (includes != null)
        //        foreach (var incluse in includes)
        //            query = query.Include(incluse);

        //    return query.SingleOrDefault(criteria);
        //}

        //public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        //{
        //    IQueryable<T> query = _dbContext.Set<T>();

        //    if (includes != null)
        //        foreach (var incluse in includes)
        //            query = query.Include(incluse);

        //    return await query.SingleOrDefaultAsync(criteria);
        //}

        //public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        //{
        //    IQueryable<T> query = _dbContext.Set<T>();

        //    if (includes != null)
        //        foreach (var include in includes)
        //            query = query.Include(include);

        //    return query.Where(criteria).ToList();
        //}

        //public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int skip, int take)
        //{
        //    return _dbContext.Set<T>().Where(criteria).Skip(skip).Take(take).ToList();
        //}

        //public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take,
        //    Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        //{
        //    IQueryable<T> query = _dbContext.Set<T>().Where(criteria);

        //    if (skip.HasValue)
        //        query = query.Skip(skip.Value);

        //    if (take.HasValue)
        //        query = query.Take(take.Value);

        //    if (orderBy != null)
        //    {
        //        if (orderByDirection == OrderBy.Ascending)
        //            query = query.OrderBy(orderBy);
        //        else
        //            query = query.OrderByDescending(orderBy);
        //    }

        //    return query.ToList();
        //}

        //public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        //{
        //    IQueryable<T> query = _dbContext.Set<T>();

        //    if (includes != null)
        //        foreach (var include in includes)
        //            query = query.Include(include);

        //    return await query.Where(criteria).ToListAsync();
        //}

        //public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
        //{
        //    return await _dbContext.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
        //}

        //public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
        //    Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        //{
        //    IQueryable<T> query = _dbContext.Set<T>().Where(criteria);

        //    if (take.HasValue)
        //        query = query.Take(take.Value);

        //    if (skip.HasValue)
        //        query = query.Skip(skip.Value);

        //    if (orderBy != null)
        //    {
        //        if (orderByDirection == OrderBy.Ascending)
        //            query = query.OrderBy(orderBy);
        //        else
        //            query = query.OrderByDescending(orderBy);
        //    }

        //    return await query.ToListAsync();
        //}

        //public T Add(T entity)
        //{
        //    _dbContext.Set<T>().Add(entity);
        //    return entity;
        //}

        //public async Task<T> AddAsync(T entity)
        //{
        //    await _dbContext.Set<T>().AddAsync(entity);
        //    return entity;
        //}

        //public IEnumerable<T> AddRange(IEnumerable<T> entities)
        //{
        //    _dbContext.Set<T>().AddRange(entities);
        //    return entities;
        //}

        //public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        //{
        //    await _dbContext.Set<T>().AddRangeAsync(entities);
        //    return entities;
        //}

        //public T Update(T entity)
        //{
        //    _dbContext.Update(entity);
        //    return entity;
        //}

        //public void Delete(T entity)
        //{
        //    _dbContext.Set<T>().Remove(entity);
        //}

        //public void DeleteRange(IEnumerable<T> entities)
        //{
        //    _dbContext.Set<T>().RemoveRange(entities);
        //}

        //public void Attach(T entity)
        //{
        //    _dbContext.Set<T>().Attach(entity);
        //}

        //public void AttachRange(IEnumerable<T> entities)
        //{
        //    _dbContext.Set<T>().AttachRange(entities);
        //}

        //public int Count()
        //{
        //    return _dbContext.Set<T>().Count();
        //}

        //public int Count(Expression<Func<T, bool>> criteria)
        //{
        //    return _dbContext.Set<T>().Count(criteria);
        //}

        //public async Task<int> CountAsync()
        //{
        //    return await _dbContext.Set<T>().CountAsync();
        //}

        //public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        //{
        //    return await _dbContext.Set<T>().CountAsync(criteria);
        //}

        //////////////////////////////////////
        ///
        #region Vars / Props

        protected readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructor(s)
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion


        #region Methods

        #endregion

        #region Actions

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllNoTrackingAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {

            return await _dbContext.Set<T>().FindAsync(id);
        }


        public IQueryable<T> GetTableNoTracking()
        {
            return _dbContext.Set<T>().AsNoTracking().AsQueryable();
        }


        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();

        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
         
        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }



        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public IQueryable<T> GetTableAsTracking()
        {
            return _dbContext.Set<T>().AsQueryable();

        }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task RollBackAsync()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }
        #endregion
    }
}
