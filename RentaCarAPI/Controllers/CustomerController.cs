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
    public class CustomerController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Customer> _service;

        public CustomerController(IService<Customer> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customers = await _service.GetAllAsync();
            var customersDtos = _mapper.Map<List<CustomerDto>>(customers.ToList());
            return CreateActionResult<List<CustomerDto>>(CustomResponseDto<List<CustomerDto>>.Success(200, customersDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customers = await _service.GetByIdAsync(id);
            var customerDtos = _mapper.Map<CustomerDto>(customers);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(200, customerDtos));
        }


        [HttpPost()]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            var customers = await _service.AddAsync(_mapper.Map<Customer>(customerDto));
            var customerDtos = _mapper.Map<CustomerDto>(customers);  
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(201, customerDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            await _service.UpdateAsync(_mapper.Map<Customer>(customerDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var customers = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(customers);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }





    }
}
