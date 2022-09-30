using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
      public Task<CustomResponseDto<CategoryWithCarsDto>> GetSingleCategoryByIdWithCarsAsync(int categoryId);

        Task<CustomResponseDto<List<CategoryWithCarsDto>>> GetCategoriesWithCars();
    }
}
