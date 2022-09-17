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
    public class CategoryApiControllerTest
    {
        private readonly Mock<ICategoryService> _mock;
        private readonly CategoryController _categoryController;
        private readonly IMapper _mapper;
        public CategoryApiControllerTest()
        {
            _mock = new Mock<ICategoryService>();
            _mapper = new Mapper(new MapperConfiguration(x => x.AddProfile(new MapProfile())));
            _categoryController = new CategoryController(_mapper, _mock.Object);
        }

        [Fact]
        public async void GetById_ActionExecute_ReturnSuccess()
        {
            List<Category> categories = new List<Category>();

            categories.Add(new Category
            {
               Id=1,
               Name="Otomobil",
            });

            _mock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(categories.First());
            var result = await _categoryController.GetById(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<CategoryDto>>(response.Value);

        }

        [Fact]
        public async void GetAll_ActionExecute_ReturnSuccess()
        {
            List<Category> categories = new List<Category>();

            categories.Add(new Category
            {
                Id = 1,
                Name = "Otomobil",
            });

            _mock.Setup(x => x.GetAllAsync()).ReturnsAsync(categories);
            var result = await _categoryController.GetAll();
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<List<CategoryDto>>>(response.Value);
            Assert.Equal(1, responseValue.Data.Count);

        }

        [Fact]
        public async void Save_ActionExecute_ReturnSuccess()
        {
            List<CategoryDto> categories = new List<CategoryDto>();

            categories.Add(new CategoryDto
            {
                Id = 1,
                Name = "Otomobil",
            });

            _mock.Setup(x => x.AddAsync(_mapper.Map<Category>(categories.First()))).ReturnsAsync(_mapper.Map<Category>(categories.First()));
            var result = await _categoryController.Save(categories.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, response.StatusCode);
            var responseValue = Assert.IsType<CustomResponseDto<CategoryDto>>(response.Value);

        }

        [Fact]
        public async void Delete_ActionExecute_ReturnSuccess()
        {
            List<Category> categories = new List<Category>();

            categories.Add(new Category
            {
                Id = 1,
                Name = "Otomobil",
            });

            _mock.Setup(x => x.RemoveAsync(categories.First()));
            var result = await _categoryController.Remove(1);
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);

        }

        [Fact]
        public async void Update_ActionExecute_ReturnSuccess()
        {
            List<CategoryDto> categories = new List<CategoryDto>();

            categories.Add(new CategoryDto
            {
                Id = 1,
                Name = "Otomobil",
            });
            _mock.Setup(x => x.UpdateAsync(_mapper.Map<Category>(categories.First())));
            var result = await _categoryController.Update(categories.First());
            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, response.StatusCode);
        }



    }
}
