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
    public class PaymentTypeController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IPaymentTypeService _paymentTypeService;


        public PaymentTypeController(IMapper mapper,IPaymentTypeService paymentTypeService)
        {

            _mapper = mapper;
            _paymentTypeService = paymentTypeService;
        }

        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var paymentTypes = await _paymentTypeService.GetAllAsync();
            var paymentTypeDtos = _mapper.Map<List<PaymentTypeDto>>(paymentTypes.ToList());
            return CreateActionResult<List<PaymentTypeDto>>(CustomResponseDto<List<PaymentTypeDto>>.Success(200, paymentTypeDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paymentTypes = await _paymentTypeService.GetByIdAsync(id);
            var paymentTypeDtos = _mapper.Map<PaymentTypeDto>(paymentTypes);
            return CreateActionResult(CustomResponseDto<PaymentTypeDto>.Success(200, paymentTypeDtos));
        }


        [HttpPost()]
        public async Task<IActionResult> Save(PaymentTypeDto paymentTypeDto)
        {
            var paymentTypes = await _paymentTypeService.AddAsync(_mapper.Map<PaymentType>(paymentTypeDto));
            var paymentTypeDtos = _mapper.Map<PaymentTypeDto>(paymentTypes);
            return CreateActionResult(CustomResponseDto<PaymentTypeDto>.Success(201, paymentTypeDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(PaymentTypeDto paymentTypeDto)
        {
            await _paymentTypeService.UpdateAsync(_mapper.Map<PaymentType>(paymentTypeDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var paymentTypes = await _paymentTypeService.GetByIdAsync(id);
            await _paymentTypeService.RemoveAsync(paymentTypes);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
