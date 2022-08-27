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
    public class CarImageController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<CarImage> _service;

        public CarImageController(IService<CarImage> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var carImages = await _service.GetAllAsync();
            var carImageDtos = _mapper.Map<List<CarImageDto>>(carImages.ToList());
            return CreateActionResult<List<CarImageDto>>(CustomResponseDto<List<CarImageDto>>.Success(200, carImageDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var carImages = await _service.GetByIdAsync(id);
            var carImageDtos = _mapper.Map<CarImageDto>(carImages);
            return CreateActionResult(CustomResponseDto<CarImageDto>.Success(200, carImageDtos));
        }

        [HttpPost()]
        public async Task<IActionResult> Save(CarImageDto carImageDto)
        {
            var carImages = await _service.AddAsync(_mapper.Map<CarImage>(carImageDto));
            var carImageDtos = _mapper.Map<CarImageDto>(carImages);
            return CreateActionResult(CustomResponseDto<CarImageDto>.Success(201, carImageDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CarImageDto carImageDto)
        {
            await _service.UpdateAsync(_mapper.Map<CarImage>(carImageDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var carImages = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(carImages);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
