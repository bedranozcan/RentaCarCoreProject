using AutoMapper;
using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using RentaCar.Core.Repositories;
using RentaCar.Core.Services;
using RentaCar.Core.UnitOfWorks;
using RentaCar.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Service.Services
{
    public class CategoryService :Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CustomResponseDto<List<CategoryWithCarsDto>>> GetCategoriesWithCars()
        {
            var categories = await _categoryRepository.GetCategoriesWithCars();
            var categoriesDtos = _mapper.Map<List<CategoryWithCarsDto>>(categories);
            return CustomResponseDto<List<CategoryWithCarsDto>>.Success(200, categoriesDtos);
        }
    }
}
