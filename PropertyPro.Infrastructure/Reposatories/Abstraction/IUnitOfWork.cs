using PropertyPro.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Infrastructure.Reposatories.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        //IBaseRepository<Author> Authors { get; }
        IUnitsRepository Units { get; }
        ICommentRepository Comments { get; }
        IFavoriteRepository Favorites { get; }
        IRatingRepository Ratings { get; }
        IBaseRepository<Image> Images { get; }

        IBaseRepository<Governorate> Governorates { get; }
        IBaseRepository<City> Cities { get; }
        IBaseRepository<Area> Areas { get; }

        IBaseRepository<UserType> UserTypes { get; }
        IBaseRepository<UnitType> UnitTypes { get; }
        IBaseRepository<SaleType> SaleTypes { get; }



        Task<int> Complete();
    }
}
