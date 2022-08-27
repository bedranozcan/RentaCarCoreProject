using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Services
{
    public interface ICarService:IService<Car>
    {
        Task<CustomResponseDto<List<CarsWithCategoryDto>>> GetCarsWithCategory();
    }
}
