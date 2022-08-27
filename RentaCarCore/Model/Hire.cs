using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Model
{
    public class Hire
    {
        public int Id { get; set; }
        public int CarsId { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int StatusId { get; set; }
        public  Car Cars { get; set; } = null!;
        public  Customer Customers { get; set; } = null!;
        public  Status Status { get; set; } = null!;
        public Payment Payment { get; set; }

    }
}
