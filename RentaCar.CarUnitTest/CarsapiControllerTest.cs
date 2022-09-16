using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RentaCar.API.Controllers;
using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using RentaCar.Core.Services;
using RentaCar.Service.Mapping;

namespace RentaCar.CarUnitTest
{
    public class CarsapiControllerTest
    {
        private readonly Mock<ICarService> _mock;
        private readonly CarController _carController;
        private readonly IMapper _mapper;

        public CarsapiControllerTest()
        {
            _mock = new Mock<ICarService>();
            _mapper=new Mapper(new MapperConfiguration(x => x.AddProfile(new MapProfile())));
            _carController = new CarController(_mapper,_mock.Object);
           
        }

        [Fact]
        public async void GetById_ActionExecute_ReturnSuccess()
        {
            List<Car> cars = new List<Car>();

            cars.Add(new Car {
                Id = 1,
                PlakaNumber = "17ab213123",
                Brand = "asdasd",
                Model = "asdasd",
                SeatsNumber = 4,
                DoorNumber = 4,
                FuelType = "Dizel",
                LicanceClass = "B",
                CategoryId = 1,
                StatusId = 1,
            });

            _mock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(cars.First());
            var result = await _carController.GetById(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<CarDto>>(response.Value);
            
        }

        [Fact]
        public async void GetAll_ActionExecute_ReturnSuccess()
        {
            List<Car> cars = new List<Car>();

            cars.Add(new Car
            {
                Id = 1,
                PlakaNumber = "17ab213123",
                Brand = "asdasd",
                Model = "asdasd",
                SeatsNumber = 4,
                DoorNumber = 4,
                FuelType = "Dizel",
                LicanceClass = "B",
                CategoryId = 1,
                StatusId = 1,
            });

            _mock.Setup(x => x.GetAllAsync()).ReturnsAsync(cars);
            var result = await _carController.GetAll();
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<List<CarDto>>>(response.Value);
            Assert.Equal(1, responseValue.Data.Count);

        }


        [Fact]
        public async void Remove_ActionExecute_ReturnSuccess()
        {
            List<Car> cars = new List<Car>();

            cars.Add(new Car
            {
                Id = 1,
                PlakaNumber = "17ab213123",
                Brand = "asdasd",
                Model = "asdasd",
                SeatsNumber = 4,
                DoorNumber = 4,
                FuelType = "Dizel",
                LicanceClass = "B",
                CategoryId = 1,
                StatusId = 1,
            });

            _mock.Setup(x => x.RemoveAsync(cars.First()));
            var result = await _carController.Remove(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);
        }


        [Fact]
        public async void Save_ActionExecute_ReturnSuccess()
        {
            List<CarDto> cars = new List<CarDto>();
           
            cars.Add(new CarDto
            {
                Id = 1,
                PlakaNumber = "17ab213123",
                Brand = "asdasd",
                Model = "asdasd",
                SeatsNumber = 4,
                DoorNumber = 4,
                FuelType = "Dizel",
                LicanceClass = "B",
                CategoryId = 1,
                StatusId = 1,
            });

            _mock.Setup(x => x.AddAsync(_mapper.Map<Car>(cars.First()))).ReturnsAsync(_mapper.Map<Car>(cars.First()));
            var result = await _carController.Save(cars.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<CarDto>>(response.Value);
           
        }

        [Fact]
        public async void Update_ActionExecute_ReturnSuccess()
        {
            List<CarDto> cars = new List<CarDto>();

            cars.Add(new CarDto
            {
                Id = 1,
                PlakaNumber = "17ab213123",
                Brand = "asdasd",
                Model = "asdasd",
                SeatsNumber = 4,
                DoorNumber = 4,
                FuelType = "Dizel",
                LicanceClass = "B",
                CategoryId = 1,
                StatusId = 1,
            });

            _mock.Setup(x => x.UpdateAsync(_mapper.Map<Car>(cars.First())));
            var result = await _carController.Update(cars.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);
        }

    }
}