using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using RentaCar.Core.Services;

namespace RentaCar.API.Controllers
{

    public class CarsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Car> _service;

        public CarsController(IService<Car> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var cars = await _service.GetAllAsync();
            var carsDtos = _mapper.Map<List<CarsDto>>(cars.ToList());
            //return Ok( CustomResponseDto<List<CarsDto>>.Success(200, carsDto));
            return CreatActionResult<List<CarsDto>>(CustomResponseDto<List<CarsDto>>.Success(200, carsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cars = await _service.GetByIdAsync(id);
            var carsDtos = _mapper.Map<CarsDto>(cars);
            //return Ok( CustomResponseDto<List<CarsDto>>.Success(200, carsDto));
            return CreatActionResult(CustomResponseDto<CarsDto>.Success(200, carsDtos));
        }

        [HttpPost()]
        public async Task<IActionResult> Save(CarsDto carsDto)
        {
            var car = await _service.AddAsync(_mapper.Map<Car>(carsDto));
            var carsDtos = _mapper.Map<CarsDto>(car);
            //return Ok( CustomResponseDto<List<CarsDto>>.Success(200, carsDto));
            return CreatActionResult(CustomResponseDto<CarsDto>.Success(201, carsDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CarsDto carsDto)
        {
            await _service.UpdateAsync(_mapper.Map<Car>(carsDto));
           
            return CreatActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var cars = await _service.GetByIdAsync(id);
             await _service.RemoveAsync(cars);
          
            return CreatActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
