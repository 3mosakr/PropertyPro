using Microsoft.EntityFrameworkCore.Storage;
using PropertyPro.Data.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Infrastructure.Reposatories.Abstraction
{
    public interface IBaseRepository<T> where T : class
    {
        //T GetById(int id);
        //Task<T> GetByIdAsync(int id);
        //IEnumerable<T> GetAll();
        //Task<IEnumerable<T>> GetAllAsync();

        //T Find(Expression<Func<T, bool>> criteria, string[] includes = null);
        //Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        //IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);
        //IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip);
        //IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip,
        //    Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);

        //Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        //Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int skip, int take);
        //Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take,
        //    Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        //T Add(T entity);
        //Task<T> AddAsync(T entity);
        //IEnumerable<T> AddRange(IEnumerable<T> entities);
        //Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        //T Update(T entity);
        //void Delete(T entity);
        //void DeleteRange(IEnumerable<T> entities);
        //void Attach(T entity);
        //void AttachRange(IEnumerable<T> entities);
        //int Count();
        //int Count(Expression<Func<T, bool>> criteria);
        //Task<int> CountAsync();
        //Task<int> CountAsync(Expression<Func<T, bool>> criteria);


        ///////////////////////////////////
        ///

        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllNoTrackingAsync();
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(int id);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task<T> UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);

        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task RollBackAsync();
    }
}
