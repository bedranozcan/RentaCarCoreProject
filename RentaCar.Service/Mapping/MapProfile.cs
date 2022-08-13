using AutoMapper;
using RentaCar.Core.Dtos;
using RentaCar.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomersDto>().ReverseMap();
            CreateMap<Hire, HiresDto>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<Car, CarsDto>().ReverseMap();
            CreateMap<Payment, PaymentsDto>().ReverseMap();
            CreateMap<PaymentType, PaymentTypeDto>().ReverseMap();
            CreateMap<Category, CategoriesDto>().ReverseMap();
        }
    }
}
