using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RentaCar.API.Controllers;
using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using RentaCar.Core.Services;
using RentaCar.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.CarUnitTest.ControllerTest
{
    public class PaymentControllerTest
    {
        private readonly Mock<IPaymentService> _mock;
        private readonly PaymentController _paymentController;
        private readonly IMapper _mapper;

        public PaymentControllerTest()
        {
            _mock = new Mock<IPaymentService>();
            _mapper = new Mapper(new MapperConfiguration(x => x.AddProfile(new MapProfile())));
            _paymentController = new PaymentController(_mapper, _mock.Object);
        }

        [Fact]
        public async void GetById_ActionExecute_ReturnSuccess()
        {
            List<Payment> payments = new List<Payment>();

            payments.Add(new Payment
            {
                Id=1,
                PaymentDate=DateTime.Now,
                Total=123,
                PaymentTypeId=1,
                HiresId=1,

            });

            _mock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(payments.First());
            var result = await _paymentController.GetById(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<PaymentDto>>(response.Value);

        }
        [Fact]
        public async void GetAll_ActionExecute_ReturnSuccess()
        {
            List<Payment> payments = new List<Payment>();

            payments.Add(new Payment
            {
                Id = 1,
                PaymentDate = DateTime.Now,
                Total = 123,
                PaymentTypeId = 1,
                HiresId = 1,

            });

            _mock.Setup(x => x.GetAllAsync()).ReturnsAsync(payments);
            var result = await _paymentController.GetAll();
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<List<PaymentDto>>>(response.Value);
            Assert.Equal(1, responseValue.Data.Count);

        }
        [Fact]
        public async void Save_ActionExecute_ReturnSuccess()
        {
            List<PaymentDto> payments = new List<PaymentDto>();

            payments.Add(new PaymentDto
            {

                Id = 1,
                PaymentDate = DateTime.Now,
                Total = 123,
                PaymentTypeId = 1,
                HiresId = 1,
            });

            _mock.Setup(x => x.AddAsync(_mapper.Map<Payment>(payments.First()))).ReturnsAsync(_mapper.Map<Payment>(payments.First()));
            var result = await _paymentController.Save(payments.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<PaymentDto>>(response.Value);

        }
        [Fact]
        public async void Delete_ActionExecute_ReturnSuccess()
        {
            List<Payment> payments = new List<Payment>();

            payments.Add(new Payment
            {
                Id = 1,
                PaymentDate = DateTime.Now,
                Total = 123,
                PaymentTypeId = 1,
                HiresId = 1,
            });

            _mock.Setup(x => x.RemoveAsync(payments.First()));
            var result = await _paymentController.Remove(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);

        }
        [Fact]
        public async void Update_ActionExecute_ReturnSuccess()
        {
            List<PaymentDto> payments = new List<PaymentDto>();

            payments.Add(new PaymentDto
            {
                Id = 1,
                PaymentDate = DateTime.Now,
                Total = 123,
                PaymentTypeId = 1,
                HiresId = 1,
            });
            _mock.Setup(x => x.UpdateAsync(_mapper.Map<Payment>(payments.First())));
            var result = await _paymentController.Update(payments.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);
        }



    }

}

