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
    public class HireService:Service<Hire>,IHireService
    {

        private readonly IHireRepository _hireRepository;
        private readonly IMapper _mapper;

        public HireService(IHireRepository hireRepository,
            IMapper mapper, IGenericRepository<Hire> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _hireRepository = hireRepository;
            _mapper = mapper;
        }
    }
}
