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
    public class PaymentController :  CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Payment> _service;

        public PaymentController(IService<Payment> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var payments = await _service.GetAllAsync();
            var paymentDtos = _mapper.Map<List<PaymentDto>>(payments.ToList());
            return CreateActionResult<List<PaymentDto>>(CustomResponseDto<List<PaymentDto>>.Success(200,paymentDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payments = await _service.GetByIdAsync(id);
            var paymentDtos = _mapper.Map<PaymentDto>(payments);
            return CreateActionResult(CustomResponseDto<PaymentDto>.Success(200, paymentDtos));
        }


        [HttpPost()]
        public async Task<IActionResult> Save(PaymentDto paymentDto )
        {
            var payments = await _service.AddAsync(_mapper.Map<Payment>(paymentDto));
            var paymentDtos = _mapper.Map<PaymentDto>(payments);
            return CreateActionResult(CustomResponseDto<PaymentDto>.Success(201, paymentDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(PaymentDto paymentDto)
        {
            await _service.UpdateAsync(_mapper.Map<Payment>(paymentDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var payments = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(payments);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
