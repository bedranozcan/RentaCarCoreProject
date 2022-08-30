using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentaCar.Core.Model;
namespace RentaCar.Repository.Configuration
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.PlakaNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.SeatsNumber).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Color).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Brand).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DoorNumber).IsRequired().HasMaxLength(1);
            builder.Property(x => x.FuelType).IsRequired().HasMaxLength(25);
            builder.Property(x => x.LicanceClass).IsRequired().HasMaxLength(25);
          
        }
      
    }
}
