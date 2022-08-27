using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Model;
using RentaCar.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Repository.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Car>> GetCarsWithCategory()
        {
            return await _context.Cars.Include(x => x.Category).ToListAsync();
        }
    }
}
