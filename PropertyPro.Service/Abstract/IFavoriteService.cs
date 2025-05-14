using Microsoft.AspNetCore.Http;
using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Reposatories.Abstraction;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Dto.Favorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Abstract
{
    public interface IFavoriteService 
    {
        Task<ResponseModel<FavoriteDto>> GetAllFavoritesForUserAsync(int userId);
        Task<ResponseModel<Favorite>> AddFavoriteAsync(int unitId);
        Task<ResponseModel<Favorite>> DeleteFavoriteAsync(int unitId);

    }
}
