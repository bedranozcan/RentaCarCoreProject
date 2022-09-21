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
    public class StatusService : Service<Status>, IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;
        public StatusService(IGenericRepository<Status> repository,
                            IUnitOfWork unitOfWork, IMapper mapper,
                            IStatusRepository statusRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _statusRepository = statusRepository;
        }
    }
}
