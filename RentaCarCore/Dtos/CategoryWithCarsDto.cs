using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Dtos
{
    public class CategoryWithCarsDto:CategoryDto
    {
        public CarDto Car { get; set; }
    }
}
