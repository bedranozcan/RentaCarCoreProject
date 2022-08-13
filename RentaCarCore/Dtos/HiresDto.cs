using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Dtos
{
    public class HiresDto
    {
        public int Id { get; set; }
        public int CarsId { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int StatusId { get; set; }
    }
}
