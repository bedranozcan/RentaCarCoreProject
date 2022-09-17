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
    public class PaymentTypeControllerTest
    {
        private readonly Mock<IPaymentTypeService> _mock;
        private readonly PaymentTypeController _paymentTypeController;
        private readonly IMapper _mapper;

        public PaymentTypeControllerTest()
        {
            _mock = new Mock<IPaymentTypeService>();
            _mapper = new Mapper(new MapperConfiguration(x => x.AddProfile(new MapProfile())));
            _paymentTypeController = new PaymentTypeController(_mapper, _mock.Object);
        }

        [Fact]
        public async void GetById_ActionExecute_ReturnSuccess()
        {
            List<PaymentType> paymentTypes = new List<PaymentType>();

            paymentTypes.Add(new PaymentType
            {
                Id = 1,
                Name="Cash",

            });

            _mock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(paymentTypes.First());
            var result = await _paymentTypeController.GetById(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<PaymentTypeDto>>(response.Value);

        }


        [Fact]
        public async void GetAll_ActionExecute_ReturnSuccess()
        {
            List<PaymentType> paymentTypes = new List<PaymentType>();

            paymentTypes.Add(new PaymentType
            {
                Id = 1,
                Name = "Cash",


            });

            _mock.Setup(x => x.GetAllAsync()).ReturnsAsync(paymentTypes);
            var result = await _paymentTypeController.GetAll();
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<List<PaymentTypeDto>>>(response.Value);
            Assert.Equal(1, responseValue.Data.Count);

        }
        [Fact]
        public async void Save_ActionExecute_ReturnSuccess()
        {
            List<PaymentTypeDto> paymentTypes = new List<PaymentTypeDto>();

            paymentTypes.Add(new PaymentTypeDto
            {

                Id = 1,
                Name = "Cash",
            });

            _mock.Setup(x => x.AddAsync(_mapper.Map<PaymentType>(paymentTypes.First()))).ReturnsAsync(_mapper.Map<PaymentType>(paymentTypes.First()));
            var result = await _paymentTypeController.Save(paymentTypes.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<PaymentTypeDto>>(response.Value);

        }
        [Fact]
        public async void Delete_ActionExecute_ReturnSuccess()
        {
            List<PaymentType> paymentTypes = new List<PaymentType>();

            paymentTypes.Add(new PaymentType
            {

                Id = 1,
                Name = "Cash",
            });

            _mock.Setup(x => x.RemoveAsync(paymentTypes.First()));
            var result = await _paymentTypeController.Remove(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);

        }
        [Fact]
        public async void Update_ActionExecute_ReturnSuccess()
        {
            List<PaymentTypeDto> paymentTypes = new List<PaymentTypeDto>();

            paymentTypes.Add(new PaymentTypeDto
            {
                Id = 1,
                Name = "Cash",
            });
            _mock.Setup(x => x.UpdateAsync(_mapper.Map<PaymentType>(paymentTypes.First())));
            var result = await _paymentTypeController.Update(paymentTypes.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);
        }

    }
}
