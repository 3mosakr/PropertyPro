using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Reposatories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Infrastructure.Reposatories.Abstraction
{
    public interface IFavoriteRepository : IBaseRepository<Favorite>
    {
        Task<Favorite> GetFavoriteByIdAsync(int memberId, int unitId);
        Task<IQueryable<Favorite>> GetFavoritsQuerableAsync();
    }
}
