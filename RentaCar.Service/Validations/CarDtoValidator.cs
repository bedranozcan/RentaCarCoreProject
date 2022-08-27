using FluentValidation;
using RentaCar.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Service.Validations
{
    public class CarDtoValidator:AbstractValidator<CarDto>
    {
        public CarDtoValidator()
        {
            RuleFor(x => x.PlakaNumber).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x=>x.Brand).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Model).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Color).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.DoorNumber).InclusiveBetween(1, 9).WithMessage("{PropertyName} Enter a number between 1 and 9");
            RuleFor(x => x.SeatsNumber).InclusiveBetween(1, 9).WithMessage("{PropertyName} Enter a number between 1 and 9");
            


        }
    }
}
