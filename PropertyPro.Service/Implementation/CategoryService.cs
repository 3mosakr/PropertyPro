using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Reposatories.Abstraction;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel<Category>> GetCategoriesListAsync()
        {
            try
            {
                var categories = await _unitOfWork.Categories.GetAllNoTrackingAsync();
                return new ResponseModel<Category>(categories, "Get data Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<Category>("Faild to retrive the data.", false, [ex.Message]);
            }
        }
        
        public async Task<ResponseModel<Category>> AddCategoryAsync(string category)
        {
            try
            {
                // find if gov is exist before
                var categories = await _unitOfWork.Categories.GetAllNoTrackingAsync();
                if (categories is not null)
                {
                    var categoriesIsExist = categories.FirstOrDefault(u => u.CategoryName.Equals(category, StringComparison.OrdinalIgnoreCase));
                    if (categoriesIsExist is not null) return new ResponseModel<Category>("this Type is Already Exist.", false);
                }

                var newCategory = await _unitOfWork.Categories.AddAsync(new Category { CategoryName = category });
                return new ResponseModel<Category>([newCategory], "Get Categories Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<Category>("Faild adding operation.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<Category>> DeleteCategoryAsync(int id)
        {
            try
            {
                // find if gov is exist
                var Category = await _unitOfWork.Categories.GetByIdAsync(id);
                if (Category is null) return new ResponseModel<Category>("Not Found.", false);

                await _unitOfWork.Categories.DeleteAsync(Category);
                return new ResponseModel<Category>([Category], "Category deleted Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<Category>("Faild operation.", false, [ex.Message]);
            }
        }

        
    }
}
