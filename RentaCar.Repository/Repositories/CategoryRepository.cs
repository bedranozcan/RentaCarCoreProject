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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithCarsAsync(int categoryId)
        {
            return await _context.Categories.Include(x => x.Car).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
