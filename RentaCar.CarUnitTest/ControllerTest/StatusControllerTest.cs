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
    public class StatusControllerTest
    {
        private readonly Mock<IStatusService> _mock;
        private readonly StatusController _statusController;
        private readonly IMapper _mapper;

        public StatusControllerTest()
        {
            _mock = new Mock<IStatusService>();
            _mapper = new Mapper(new MapperConfiguration(x => x.AddProfile(new MapProfile())));
            _statusController = new StatusController(_mapper, _mock.Object);
        }

        [Fact]
        public async void GetById_ActionExecute_ReturnSuccess()
        {
            List<Status> statuses = new List<Status>();

            statuses.Add(new Status
            {
                Id = 1,
                Name="Unknown"

            });

            _mock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(statuses.First());
            var result = await _statusController.GetById(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<StatusDto>>(response.Value);

        }
        [Fact]
        public async void GetAll_ActionExecute_ReturnSuccess()
        {
            List<Status> statuses = new List<Status>();

            statuses.Add(new Status
            {
                Id = 1,
                Name = "Unknown"


            });

            _mock.Setup(x => x.GetAllAsync()).ReturnsAsync(statuses);
            var result = await _statusController.GetAll();
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<List<StatusDto>>>(response.Value);
            Assert.Equal(1, responseValue.Data.Count);

        }
        [Fact]
        public async void Save_ActionExecute_ReturnSuccess()
        {
            List<StatusDto> statuses = new List<StatusDto>();

            statuses.Add(new StatusDto
            {

                    Id = 1,
                    Name= "Unknown"
            });

            _mock.Setup(x => x.AddAsync(_mapper.Map<Status>(statuses.First()))).ReturnsAsync(_mapper.Map<Status>(statuses.First()));
            var result = await _statusController.Save(statuses.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<StatusDto>>(response.Value);

        }
        [Fact]
        public async void Delete_ActionExecute_ReturnSuccess()
        {
            List<Status> statuses = new List<Status>();

            statuses.Add(new Status
            {
                Id = 1,
                Name = "Unknown"
            });

            _mock.Setup(x => x.RemoveAsync(statuses.First()));
            var result = await _statusController.Remove(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);

        }
        [Fact]
        public async void Update_ActionExecute_ReturnSuccess()
        {
            List<StatusDto> statuses = new List<StatusDto>();

            statuses.Add(new StatusDto
            {
                Id = 1,
                Name= "Unknown"
            });
            _mock.Setup(x => x.UpdateAsync(_mapper.Map<Status>(statuses.First())));
            var result = await _statusController.Update(statuses.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);
        }

    }
}
