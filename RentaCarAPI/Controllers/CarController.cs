using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentaCar.API.Filters;
using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using RentaCar.Core.Services;

namespace RentaCar.API.Controllers
{
    public class CarController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICarService _service;
    
        public CarController( IMapper mapper, ICarService carService, IService<Car> ıservice)
        {
            _mapper = mapper;
            _service = carService;
            
        }

        [HttpGet("GetCarsWithCategory")]
        public async Task<IActionResult> GetCarsWithCategory()
        {
            return CreateActionResult(await _service.GetCarsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var cars = await _service.GetAllAsync();
            var carsDtos = _mapper.Map<List<CarDto>>(cars.ToList());
            return CreateActionResult<List<CarDto>>(CustomResponseDto<List<CarDto>>.Success(200, carsDtos));
        }

//       [ServiceFilter(typeof(NotFoundFilter<Car>))] 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cars = await _service.GetByIdAsync(id);
            var carsDtos = _mapper.Map<CarDto>(cars);
            return CreateActionResult(CustomResponseDto<CarDto>.Success(200, carsDtos));
        }

        [HttpPost()]
        public async Task<IActionResult> Save(CarDto carsDto)
        {
            var car = await _service.AddAsync(_mapper.Map<Car>(carsDto));
            var carsDtos = _mapper.Map<CarDto>(car);
            return CreateActionResult(CustomResponseDto<CarDto>.Success(201, carsDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CarDto carsDto)
        {
            await _service.UpdateAsync(_mapper.Map<Car>(carsDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var cars = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(cars);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }








    }
}
