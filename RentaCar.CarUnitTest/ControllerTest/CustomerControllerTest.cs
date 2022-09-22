using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RentaCar.API.Controllers;
using RentaCar.API.RabbitMQ;
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
    public class CustomerControllerTest
    {

        private readonly Mock<ICustomerService> _mock;
        private readonly CustomerController _customerController;
        private readonly IMapper _mapper;
        private readonly IRabbitMQ _rabbitMQ;

        public CustomerControllerTest()
        {
            _mock = new Mock<ICustomerService>();
            _mapper = new Mapper(new MapperConfiguration(x => x.AddProfile(new MapProfile())));
            _rabbitMQ = new MessageBrokerRabbit();
           _customerController = new CustomerController(_mapper,_rabbitMQ,_mock.Object);
         
        }

        [Fact]
        public async void GetById_ActionExecute_ReturnSuccess()
        {
            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer
            {
                Id=1,
                IdentityNumber=1231234,
                Name="Bedran",
                Surname="Özcan",
                Email="bedranozcan@gmail.com",
                Password="123412",
                PhoneNumber=123456789,
                LicanceClass="B",

            });

            _mock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(customers.First());
            var result = await _customerController.GetById(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<CustomerDto>>(response.Value);

        }


        [Fact]
        public async void GetAll_ActionExecute_ReturnSuccess()
        {
            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer
            {

                Id = 1,
                IdentityNumber = 1231234,
                Name = "Bedran",
                Surname = "Özcan",
                Email = "bedranozcan@gmail.com",
                Password = "123412",
                PhoneNumber = 123456789,
                LicanceClass = "B",
            });

            _mock.Setup(x => x.GetAllAsync()).ReturnsAsync(customers);
            var result = await _customerController.GetAll();
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<List<CustomerDto>>>(response.Value);
            Assert.Equal(1, responseValue.Data.Count);

        }

        [Fact]
        public async void Remove_ActionExecute_ReturnSuccess()
        {
            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer
            {
                Id = 1,
                IdentityNumber = 1231234,
                Name = "Bedran",
                Surname = "Özcan",
                Email = "bedranozcan@gmail.com",
                Password = "123412",
                PhoneNumber = 123456789,
                LicanceClass = "B",
            });

            _mock.Setup(x => x.RemoveAsync(customers.First()));
            var result = await _customerController.Remove(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);
        }

        [Fact]
        public async void Save_ActionExecute_ReturnSuccess()
        {
            List<CustomerDto> customerDtos = new List<CustomerDto>();

            customerDtos.Add(new CustomerDto
            {
                Id = 1,
                IdentityNumber = 1231234,
                Name = "Bedran",
                Surname = "Özcan",
                Email = "bedranozcan@gmail.com",
                Password = "123412",
                PhoneNumber = 123456789,
                LicanceClass = "B",
            });

            _mock.Setup(x => x.AddAsync(_mapper.Map<Customer>(customerDtos.First()))).ReturnsAsync(_mapper.Map<Customer>(customerDtos.First()));
            var result = await _customerController.Save(customerDtos.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<CustomerDto>>(response.Value);

        }

        [Fact]
        public async void Update_ActionExecute_ReturnSuccess()
        {
            List<CustomerDto> customerDtos = new List<CustomerDto>();

            customerDtos.Add(new CustomerDto
            {

                Id = 1,
                IdentityNumber = 1231234,
                Name = "Bedran",
                Surname = "Özcan",
                Email = "bedranozcan@gmail.com",
                Password = "123412",
                PhoneNumber = 123456789,
                LicanceClass = "B",
            });

            _mock.Setup(x => x.UpdateAsync(_mapper.Map<Customer>(customerDtos.First())));
            var result = await _customerController.Update(customerDtos.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);
        }

    }
}
