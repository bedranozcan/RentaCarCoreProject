using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using RentaCar.Core.Services;

namespace RentaCar.API.Controllers
{

    public class CategoryController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet(" GetCategoryWithCars")]
        public async Task<IActionResult> GetCategoryWithCars()
        {
            return CreateActionResult(await _categoryService.GetCategoriesWithCars());
        }

        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CreateActionResult<List<CategoryDto>>(CustomResponseDto<List<CategoryDto>>.Success(200, categoryDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categories = await _categoryService.GetByIdAsync(id);
            var categoryDtos = _mapper.Map<CategoryDto>(categories);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, categoryDtos));
        }


        [HttpPost()]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var categories = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            var categoryDtos = _mapper.Map<CategoryDto>(categories);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, categoryDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var categories = await _categoryService.GetByIdAsync(id);
            await _categoryService.RemoveAsync(categories);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
