using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Dto.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Abstract
{
    public interface IRatingService
    {
        public Task<ResponseModel<Rating>> AddOrUpdateRatingAsync(RatingDto rate);
        public Task<ResponseModel<Rating>> DeleteRatingAsync(int unitId);

    }
}
