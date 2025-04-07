using PropertyPro.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Infrastructure.Reposatories.Abstraction
{
    public interface IRatingRepository : IBaseRepository<Rating>
    {
         Task<Rating> GetRatingByIdAsync(int memberId, int unitId);

    }
}
