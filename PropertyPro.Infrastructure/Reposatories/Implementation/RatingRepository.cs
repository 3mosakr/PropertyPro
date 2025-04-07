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
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {
        public RatingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Rating> GetRatingByIdAsync(int memberId, int unitId)
        {
            return await _dbContext.Ratings.FindAsync(memberId, unitId);
        }
    }
}
