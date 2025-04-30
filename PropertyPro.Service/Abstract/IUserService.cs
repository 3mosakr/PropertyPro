using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Dto.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Abstract
{
    public interface IUserService
    {
        public Task<ResponseModel<GetUserByIdDto>> GetUserByIdAsync(int id);
        Task<ResponseModel<GetUserByIdDto>> GetUsersListAsync(int page, int pageSize);
        public Task<ResponseModel<UserPostsDto>> GetUserPostsByIdAsync(int id, int page, int pageSize);
        public Task<ResponseModel<UserFavoritsDto>> GetUserFavoritsByIdAsync(int id, int page, int pageSize);

        Task<ResponseModel<bool>> LockUnlockUserAsync(int id);


    }
}
