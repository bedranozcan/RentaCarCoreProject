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
    public class CarImageControllerTest
    {
        private readonly Mock<ICarImageService> _mock;
        private readonly CarImageController _carImageController;
        private readonly IMapper _mapper;

        public CarImageControllerTest()
        {
            _mock = new Mock<ICarImageService>();
            _mapper = new Mapper(new MapperConfiguration(x => x.AddProfile(new MapProfile())));
            _carImageController = new CarImageController(_mapper, _mock.Object);
        }

        [Fact]
        public async void GetById_ActionExecute_ReturnSuccess()
        {
            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage
            {
                Id = 1,
                ImagePath="asdasdasd",
                CarId=1,
            });

            _mock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(carImages.First());
            var result = await _carImageController.GetById(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<CarImageDto>>(response.Value);

        }
        [Fact]
        public async void GetAll_ActionExecute_ReturnSuccess()
        {
            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage
            {
                Id = 1,
                ImagePath = "asdasdasd",
                CarId = 1,
            });

            _mock.Setup(x => x.GetAllAsync()).ReturnsAsync(carImages);
            var result = await _carImageController.GetAll();
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<List<CarImageDto>>>(response.Value);
            Assert.Equal(1, responseValue.Data.Count);

        }
        [Fact]
        public async void Save_ActionExecute_ReturnSuccess()
        {
            List<CarImageDto> carImages = new List<CarImageDto>();

            carImages.Add(new CarImageDto
            {
                Id = 1,
                ImagePath = "asdasdasd",
                CarId = 1,
            });

            _mock.Setup(x => x.AddAsync(_mapper.Map<CarImage>(carImages.First()))).ReturnsAsync(_mapper.Map<CarImage>(carImages.First()));
            var result = await _carImageController.Save(carImages.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<CarImageDto>>(response.Value);

        }
        [Fact]
        public async void Delete_ActionExecute_ReturnSuccess()
        {
            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage
            {
                Id = 1,
                ImagePath = "asdasdasd",
                CarId = 1,
            });

            _mock.Setup(x => x.RemoveAsync(carImages.First()));
            var result = await _carImageController.Remove(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);

        }
        [Fact]
        public async void Update_ActionExecute_ReturnSuccess()
        {
            List<CarImageDto> carImages = new List<CarImageDto>();

            carImages.Add(new CarImageDto
            {
                Id = 1,
                ImagePath = "asdasdasd",
                CarId = 1,
            });
            _mock.Setup(x => x.UpdateAsync(_mapper.Map<CarImage>(carImages.First())));
            var result = await _carImageController.Update(carImages.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);
        }
    }
}
