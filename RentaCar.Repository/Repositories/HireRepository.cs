using RentaCar.Core.Model;
using RentaCar.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Repository.Repositories
{
    public class HireRepository : GenericRepository<Hire>, IHireRepository
    {
        public HireRepository(AppDbContext context) : base(context)
        {
        }
    }
}
