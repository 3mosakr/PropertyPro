using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Abstract
{
    public interface ICategoryService
    {
        Task<ResponseModel<Category>> GetCategoriesListAsync();
        Task<ResponseModel<Category>> AddCategoryAsync(string category);
        Task<ResponseModel<Category>> DeleteCategoryAsync(int id);
    }
}
