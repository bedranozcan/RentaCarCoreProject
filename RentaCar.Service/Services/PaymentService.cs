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
    public class PaymentService:Service<Payment>,IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public PaymentService(IPaymentRepository paymentRepository,
            IMapper mapper, IGenericRepository<Payment> repository,
            IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }
    }
}
