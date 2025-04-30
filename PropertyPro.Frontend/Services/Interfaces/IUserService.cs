using PropertyPro.Frontend.Models.Auth;
using PropertyPro.Frontend.Models.Response;
using PropertyPro.Frontend.Models.User;

namespace PropertyPro.Frontend.Services.Interfaces
{
    public interface IUserService
    {
        //Task<ResponseModel<UserDto>> GetUserByIdAsync(int id);
        Task<PaginatedResult<UserDto>> GetUsersListAsync(int page = 1, int pageSize = 10);
        //Task<ApiResponse<List<PostDto>>> GetUserPostsByIdAsync(int id, int page = 1, int pageSize = 10);
        //Task<ApiResponse<List<FavoritDto>>> GetUserFavoritsByIdAsync(int id, int page = 1, int pageSize = 10);
        Task<ResponseModel<bool>> LockUnlockUserAsync(int id);
        Task<string> AddUserRoleAsync(AddRoleModel model);

        Task<ResponseModel<AuthModel>> CreateUserAsync(MultipartFormDataContent model);
    }
}
