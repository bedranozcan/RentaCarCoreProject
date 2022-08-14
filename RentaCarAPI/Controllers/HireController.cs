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
    public class HireController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Hire> _service;

        public HireController(IService<Hire> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var hires = await _service.GetAllAsync();
            var hiresDtos = _mapper.Map<List<HireDto>>(hires.ToList());
            return CreateActionResult<List<HireDto>>(CustomResponseDto<List<HireDto>>.Success(200, hiresDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hires = await _service.GetByIdAsync(id);
            var hiresDtos = _mapper.Map<HireDto>(hires);
            return CreateActionResult(CustomResponseDto<HireDto>.Success(200, hiresDtos));
        }


        [HttpPost()]
        public async Task<IActionResult> Save(HireDto hireDto)
        {
            var hires = await _service.AddAsync(_mapper.Map<Hire>(hireDto));
            var hiresDtos = _mapper.Map<HireDto>(hires);
            return CreateActionResult(CustomResponseDto<HireDto>.Success(201, hiresDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(HireDto hireDto)
        {
            await _service.UpdateAsync(_mapper.Map<Hire>(hireDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var hires = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(hires);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
