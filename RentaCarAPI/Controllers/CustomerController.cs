using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCar.API.RabbitMQ;
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
        private readonly ICustomerService _customerService;
        private readonly IRabbitMQ _rabbitMQ;

        public CustomerController(IMapper mapper, IRabbitMQ rabbitMQ, ICustomerService customerService)
        {
           
            _mapper = mapper;
            _rabbitMQ = rabbitMQ;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            var customersDtos = _mapper.Map<List<CustomerDto>>(customers.ToList());
            return CreateActionResult<List<CustomerDto>>(CustomResponseDto<List<CustomerDto>>.Success(200, customersDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customers = await _customerService.GetByIdAsync(id);
            var customerDtos = _mapper.Map<CustomerDto>(customers);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(200, customerDtos));
        }


        [HttpPost()]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            var customers = await _customerService.AddAsync(_mapper.Map<Customer>(customerDto));
            var customerDtos = _mapper.Map<CustomerDto>(customers);  
            _rabbitMQ.SendUserMessage(customerDtos);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(201, customerDtos));

        }


        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            await _customerService.UpdateAsync(_mapper.Map<Customer>(customerDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var customers = await _customerService.GetByIdAsync(id);
            await _customerService.RemoveAsync(customers);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }





    }
}
