using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using RentaCar.Core.Services;

namespace RentaCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IStatusService _statusService;

        public StatusController(IMapper mapper, IStatusService statusService)
        {

            _mapper = mapper;
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var statuses = await _statusService.GetAllAsync();
            var statusDtos = _mapper.Map<List<StatusDto>>(statuses.ToList());
            return CreateActionResult<List<StatusDto>>(CustomResponseDto<List<StatusDto>>.Success(200, statusDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var statuses = await _statusService.GetByIdAsync(id);
            var statusDtos = _mapper.Map<StatusDto>(statuses);
            return CreateActionResult(CustomResponseDto<StatusDto>.Success(200, statusDtos));
        }


        [HttpPost()]
        public async Task<IActionResult> Save(StatusDto statusDto)
        {
            var statuses = await _statusService.AddAsync(_mapper.Map<Status>(statusDto));
            var statusDtos = _mapper.Map<StatusDto>(statuses);
            return CreateActionResult(CustomResponseDto<StatusDto>.Success(201, statusDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(StatusDto statusDto)
        {
            await _statusService.UpdateAsync(_mapper.Map<Status>(statusDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var statuses = await _statusService.GetByIdAsync(id);
            await _statusService.RemoveAsync(statuses);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

       



    }
}
