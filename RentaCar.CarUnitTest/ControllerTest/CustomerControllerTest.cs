using AutoMapper;
using Moq;
using RentaCar.API.Controllers;
using RentaCar.API.RabbitMQ;
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
           //_customerController = new CustomerController(_mapper, _mock.Object);
         
        }
    }
}
