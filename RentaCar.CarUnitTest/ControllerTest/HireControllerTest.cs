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
    public class HireControllerTest
    {

        private readonly Mock<IHireService> _mock;
        private readonly HireController _hireController;
        private readonly IMapper _mapper;

        public HireControllerTest()
        {
            _mock = new Mock<IHireService>();
            _mapper = new Mapper(new MapperConfiguration(x => x.AddProfile(new MapProfile())));
            _hireController = new HireController(_mapper, _mock.Object);
        }

        [Fact]
        public async void GetById_ActionExecute_ReturnSuccess()
        {
            List<Hire> hires = new List<Hire>();

            hires.Add(new Hire
            {
               Id=1,
             PurchaseDate=DateTime.Now,
             DeliveryDate=DateTime.Now,
             CarsId=1,
             StatusId=1,
             CustomerId=1,
            });

            _mock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(hires.First());
            var result = await _hireController.GetById(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<HireDto>>(response.Value);

        }

        [Fact]
        public async void GetAll_ActionExecute_ReturnSuccess()
        {
            List<Hire> hires = new List<Hire>();

            hires.Add(new Hire
            {

                Id = 1,
                PurchaseDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                CarsId = 1,
                StatusId = 1,
                CustomerId = 1,
            });

            _mock.Setup(x => x.GetAllAsync()).ReturnsAsync(hires);
            var result = await _hireController.GetAll();
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<List<HireDto>>>(response.Value);
            Assert.Equal(1, responseValue.Data.Count);

        }
        [Fact]
        public async void Save_ActionExecute_ReturnSuccess()
        {
            List<HireDto> hires = new List<HireDto>();

            hires.Add(new HireDto
            {
                Id = 1,
                PurchaseDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                CarsId = 1,
                StatusId = 1,
                CustomerId = 1,
            });

            _mock.Setup(x => x.AddAsync(_mapper.Map<Hire>(hires.First()))).ReturnsAsync(_mapper.Map<Hire>(hires.First()));
            var result = await _hireController.Save(hires.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<HireDto>>(response.Value);

        }
        [Fact]
        public async void Delete_ActionExecute_ReturnSuccess()
        {
            List<Hire> hires = new List<Hire>();

            hires.Add(new Hire
            {
                Id = 1,
                PurchaseDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                CarsId = 1,
                StatusId = 1,
                CustomerId = 1,
            });

            _mock.Setup(x => x.RemoveAsync(hires.First()));
            var result = await _hireController.Remove(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);

        }
        [Fact]
        public async void Update_ActionExecute_ReturnSuccess()
        {
            List<HireDto> hires = new List<HireDto>();

            hires.Add(new HireDto
            {
                Id = 1,
                PurchaseDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                CarsId = 1,
                StatusId = 1,
                CustomerId = 1,
            });
            _mock.Setup(x => x.UpdateAsync(_mapper.Map<Hire>(hires.First())));
            var result = await _hireController.Update(hires.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);
        }

    }
}
