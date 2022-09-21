using AutoMapper;
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
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(IGenericRepository<Customer> repository,
                            IUnitOfWork unitOfWork, IMapper mapper,
                            ICustomerRepository customerRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _customerRepository= customerRepository;
        }
    }
}
