using RentaCar.Core.Model;
using RentaCar.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Repository.Repositories
{
    public class PaymentRepository:GenericRepository<Payment>,IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }

    }
}
