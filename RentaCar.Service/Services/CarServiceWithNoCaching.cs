using AutoMapper;
using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using RentaCar.Core.Repositories;
using RentaCar.Core.Services;
using RentaCar.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Service.Services
{
    public class CarServiceWithNoCaching : Service<Car>, ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public CarServiceWithNoCaching(IGenericRepository<Car> repository,
                            IUnitOfWork unitOfWork, IMapper mapper,
                            ICarRepository carRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<CustomResponseDto<List<CarsWithCategoryDto>>> GetCarsWithCategory()
        {
            var car = await _carRepository.GetCarsWithCategory();
            var carDto = _mapper.Map<List<CarsWithCategoryDto>>(car);
            return CustomResponseDto<List<CarsWithCategoryDto>>.Success(200, carDto);
        }
    }
}
