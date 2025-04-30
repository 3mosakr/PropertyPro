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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        //public IBaseRepository<Author> Authors { get; private set; }

        public IUnitsRepository Units { get; private set; }
        public ICommentRepository Comments { get; private set; }
        public IFavoriteRepository Favorites { get; private set; }
        public IRatingRepository Ratings { get; private set; }
        public IBaseRepository<Image> Images { get; private set; }
        public IBaseRepository<Governorate> Governorates { get; private set; }
        public IBaseRepository<City> Cities { get; private set; }
        public IBaseRepository<Area> Areas { get; private set; }
        public IBaseRepository<UnitType> UnitTypes { get; private set; }
        public IBaseRepository<UserType> UserTypes { get; private set; }
        public IBaseRepository<SaleType> SaleTypes { get; private set; }
        public IBaseRepository<Category> Categories { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            //Authors = new BaseRepository<Author>(_context);
            Units = new UnitsReopsitory(_context);
            Comments = new CommentRepository(_context);
            Favorites = new FavoriteRepository(_context);
            Ratings = new RatingRepository(_context);
            Images = new BaseRepository<Image>(_context);

            Governorates = new BaseRepository<Governorate>(_context);
            Cities = new BaseRepository<City>(_context);
            Areas = new BaseRepository<Area>(_context);

            UnitTypes = new BaseRepository<UnitType>(_context);
            UserTypes = new BaseRepository<UserType>(_context);
            SaleTypes = new BaseRepository<SaleType>(_context);
            Categories = new BaseRepository<Category>(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
