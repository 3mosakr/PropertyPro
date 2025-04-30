using PropertyPro.Frontend.Models;
using PropertyPro.Frontend.Models.Response;

namespace PropertyPro.Frontend.Services.Interfaces
{
    public interface ICategotyService
    {
        Task<ResponseModel<Category>> GetCategoriesListAsync();
        Task<ResponseModel<Category>> AddCategoryAsync(string category);
        Task DeleteCategoryAsync(int id);
    }
}
