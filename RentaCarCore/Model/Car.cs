using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string PlakaNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int SeatsNumber { get; set; }
        public int DoorNumber { get; set; }
        public string FuelType { get; set; }
        public string LicanceClass { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public ICollection<Hire> Hires { get; set; }
        public  Category Category { get; set; } = null!;
        public  Status Status { get; set; } = null!;
        
    }
}
