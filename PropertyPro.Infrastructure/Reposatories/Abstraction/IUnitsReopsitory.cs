using PropertyPro.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Infrastructure.Reposatories.Abstraction
{
    public interface IUnitsRepository : IBaseRepository<Unit>
    {
        Task<IQueryable<Unit>> GetUnitsQuerableAsync();
        Task<Unit> GetUnitByIdAsync(int id);
        Task<IQueryable<Unit>> GetUnitsQuerableFilteredAsync(string search, int unitType,
                                                                            int userType,
                                                                            int minPrice,
                                                                            int maxPrice,
                                                                            int NumOfRooms,
                                                                            int NumOfBathrooms);
        Task<Unit> GetUnitByIdWithImagesAsync(int id);
    }
}
