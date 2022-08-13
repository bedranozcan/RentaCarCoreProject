using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public DateTime? PaymentDate { get; set; }
        public float? Total { get; set; }
        public int PaymentTypeId { get; set; }
        public int HiresId { get; set; }
    }
}
