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
    public class UnitsReopsitory : BaseRepository<Unit>, IUnitsRepository
    {
        
        #region Fields
        private readonly DbSet<Unit> _units;
        #endregion

        #region Constructor
        public UnitsReopsitory(ApplicationDbContext dbContext) : base(dbContext)
        {
            _units = dbContext.Set<Unit>();
        }

        #endregion

        #region Handle Methods
        public async Task<IQueryable<Unit>> GetUnitsQuerableAsync()
        {
            return _units.AsNoTracking()
                .Include(u => u.Category)
                .Include(u => u.UnitType)
                .Include(u => u.SaleType)
                .Include(u => u.User)
                .Include(u => u.Images)
                .OrderByDescending(u => u.DatePosted)
                .AsQueryable();
        }

        public async Task<Unit> GetUnitByIdAsync(int id)
        {
            return await _units.AsNoTracking()
                .Include(u => u.User)
                .Include(u => u.Category)
                .Include(u => u.UnitType)
                .Include(u => u.SaleType)
                .Include(u => u.Ratings)
                .Include(u => u.Images)
                .Include(u => u.Comments)
                    .ThenInclude(c => c.User)
                .SingleOrDefaultAsync(u => u.Id == id);
                
        }

        public async Task<Unit> GetUnitByIdWithImagesAsync(int id)
        {
            return await _units
                .Include(u => u.Images)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IQueryable<Unit>> GetUnitsQuerableFilteredAsync(string search,
                                                                            int unitType,
                                                                            int userType,
                                                                            int minPrice,
                                                                            int maxPrice,
                                                                            int NumOfRooms,
                                                                            int NumOfBathrooms,
                                                                            int hotDeals)
        {
            // prepare Query and includes
            var querable = _units.AsNoTracking()
                .Include(u => u.Category)
                .Include(u => u.UnitType)
                .Include(u => u.SaleType)
                .Include(u => u.User)
                .Include(u => u.Images)
                .AsQueryable();

            // Filtring
            if (userType > 0)
                querable = querable.Where(u => u.User.UserTypeId == userType);
            if (unitType > 0)
                querable = querable.Where(u => u.UnitTypeId == unitType);
            if (minPrice > 0)
                querable = querable.Where(u => u.Price >= minPrice);
            if (maxPrice > 0 && maxPrice > minPrice)
                querable = querable.Where(u => u.Price <= maxPrice);

            if (NumOfRooms > 0 && NumOfRooms < 5)
                querable = querable.Where(u => u.NumberOfBedrooms == NumOfRooms);
            else if (NumOfRooms >= 5)
                querable = querable.Where(u => u.NumberOfBedrooms >= 5);

            if (NumOfBathrooms > 0 && NumOfBathrooms < 5)
                querable = querable.Where(u => u.NumberOfBathrooms == NumOfBathrooms);
            else if (NumOfBathrooms >= 5)
                querable = querable.Where(u => u.NumberOfBathrooms >= 5);

            // Search
            if (!string.IsNullOrEmpty(search))
            {
                querable = querable.Where(u => u.Title.Contains(search) || u.Address.Contains(search) || 
                                                u.User.FullName.Contains(search)
                                          );
            }

            // Hot Deals
            if (hotDeals > 0)
                if (hotDeals == 1)
                    querable = querable.Where(u => u.IsFeatured == true);
                else
                    querable = querable.Where(u => u.IsFeatured == false);

            // Order data
            querable = querable.OrderByDescending(u => u.DatePosted);
            return querable;
        }

        public async Task<IQueryable<Unit>> GetUnitsQuerableHotDealsAsync(string search, int minPrice, int maxPrice)
        {
            var queriable = _units.AsNoTracking()
                .Include(u => u.Category)
                .Include(u => u.UnitType)
                .Include(u => u.SaleType)
                .Include(u => u.User)
                .Include(u => u.Images)
                .AsQueryable();
            // Filtring
            queriable = queriable.Where(u => u.IsFeatured == true);

            if (minPrice > 0)
                queriable = queriable.Where(u => u.Price >= minPrice);
            if (maxPrice > 0 && maxPrice > minPrice)
                queriable = queriable.Where(u => u.Price <= maxPrice);
            if (!string.IsNullOrEmpty(search))
            {
                queriable = queriable.Where(u => u.Title.Contains(search) || u.Address.Contains(search) ||
                                                u.User.FullName.Contains(search)
                                          );
            }
            // Order data
            queriable = queriable.OrderByDescending(u => u.DatePosted);
            return queriable;
        }


        #endregion
    }
}
