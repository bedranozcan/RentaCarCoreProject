﻿using RentaCar.Core.Model;
using RentaCar.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Repository.Repositories
{
    public class CarImageRepository:GenericRepository<CarImage>,ICarImageRepository
    {
        public CarImageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
