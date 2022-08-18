using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Model
{
    public class CarImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int CarId { get; set; }
        public Car Cars { get; set; }
    }
}
