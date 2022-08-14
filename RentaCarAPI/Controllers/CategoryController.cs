using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using RentaCar.Core.Services;

namespace RentaCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Category> _service;

        public CategoryController(IService<Category> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categories = await _service.GetAllAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CreateActionResult<List<CategoryDto>>(CustomResponseDto<List<CategoryDto>>.Success(200, categoryDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categories = await _service.GetByIdAsync(id);
            var categoryDtos = _mapper.Map<CategoryDto>(categories);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, categoryDtos));
        }


        [HttpPost()]
        public async Task<IActionResult> Save(CategoryDto  categoryDto)
        {
            var categories = await _service.AddAsync(_mapper.Map<Category>(categoryDto));
            var categoryDtos = _mapper.Map<CategoryDto>(categories);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, categoryDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _service.UpdateAsync(_mapper.Map<Category>(categoryDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var categories = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(categories);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
