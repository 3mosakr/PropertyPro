using Microsoft.EntityFrameworkCore;
using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Data;
using PropertyPro.Infrastructure.Reposatories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Infrastructure.Reposatories.Implementation
{
    public class FavoriteRepository : BaseRepository<Favorite>, IFavoriteRepository
    {
        #region Fields
        private readonly DbSet<Favorite> _favorites;
        #endregion

        #region Constructor
        public FavoriteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _favorites = dbContext.Set<Favorite>();
        }

        #endregion
        

        

        public async Task<Favorite> GetFavoriteByIdAsync(int memberId, int unitId)
        {
            return await _favorites.FindAsync(memberId, unitId);
        }

        public async Task<IQueryable<Favorite>> GetFavoritsQuerableAsync()
        {
            return _favorites.Include(f => f.Unit)
                                .ThenInclude(u => u.Category)
                             .Include(f => f.Unit)
                                .ThenInclude(u => u.UnitType)
                             .Include(f => f.Unit)
                                .ThenInclude(u => u.SaleType)
                             .Include(f => f.Unit)
                                .ThenInclude(u => u.User)
                             .AsQueryable();
        }
    }
}
