using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Model
{
    public class PaymentType
    {
      
        public int Id { get; set; }
        public string? Name { get; set; }

        public Payment Payment { get; set; }
    }
}
