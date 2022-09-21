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
    public class PaymentTypeService:Service<PaymentType>,IPaymentTypeService
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IMapper _mapper;
        public PaymentTypeService(IPaymentTypeRepository paymentTypeRepository,
            IMapper mapper,IGenericRepository<PaymentType> repository,IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _paymentTypeRepository = paymentTypeRepository;
            _mapper = mapper;
        }
    }
}
