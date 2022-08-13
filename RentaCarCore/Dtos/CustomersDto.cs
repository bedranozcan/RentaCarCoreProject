using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Dtos
{
    public class CustomersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdentityNumber { get; set; }
        public int PhoneNumber { get; set; }
        public int UserId { get; set; }
        public string LicanceClass { get; set; }
    }
}
