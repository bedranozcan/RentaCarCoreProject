using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using RentaCar.Core.Repositories;
using RentaCar.Core.Services;
using RentaCar.Core.UnitOfWorks;
using RentaCar.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Caching
{
    public class CarServiceWithCaching : ICarService
    {
        private const string CacheCarKey = "carCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly ICarRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CarServiceWithCaching(IUnitOfWork unitOfWork, ICarRepository repository, IMemoryCache memoryCache, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _memoryCache = memoryCache;
            _mapper = mapper;

            if(!_memoryCache.TryGetValue(CacheCarKey,out _))
            {
                _memoryCache.Set(CacheCarKey, _repository.GetCarsWithCategory().Result);
            }


        }

        public async Task<Car> AddAsync(Car entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
           await CacheAllCarsAsync();
            return entity;
        }

        public async Task<IEnumerable<Car>> AddRangeAsync(IEnumerable<Car> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCarsAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<Car, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAllAsync()
        {
          var cars =  _memoryCache.Get<IEnumerable<Car>>(CacheCarKey);
            return Task.FromResult(cars);
        }

        public  Task<Car> GetByIdAsync(int id)
        {
            var car = _memoryCache.Get<List<Car>>(CacheCarKey).FirstOrDefault(x => x.Id == id);
            if(car == null)
            {
                throw new NotFoundException($"{typeof(Car).Name} not found");
            }
            return Task.FromResult(car);
        }

        public  Task<CustomResponseDto<List<CarsWithCategoryDto>>> GetCarsWithCategory()
        {
            var cars   =   _memoryCache.Get<IEnumerable<Car>>(CacheCarKey);

            var carsWithCategoryDto=_mapper.Map<List<CarsWithCategoryDto>>(cars);

            return Task.FromResult(CustomResponseDto<List<CarsWithCategoryDto>>.Success(200,carsWithCategoryDto));
        }

        public async Task RemoveAsync(Car entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCarsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Car> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCarsAsync();
          ;
        }

        public async Task UpdateAsync(Car entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCarsAsync();
        }

        public IQueryable<Car> Where(Expression<Func<Car, bool>> expression)
        {
            return _memoryCache.Get<List<Car>>(CacheCarKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllCarsAsync()
        {
            _memoryCache.Set(CacheCarKey,await _repository.GetAll().ToListAsync());
        }
    }
}
