using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Model
{
    public class Customer
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdentityNumber { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LicanceClass { get; set; }
        public ICollection<Hire> Hires { get; set; }

    }
}
