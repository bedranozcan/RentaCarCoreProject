using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentaCar.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Repository.Configuration
{
    internal class HireConfiguration : IEntityTypeConfiguration<Hire>
    {
        public void Configure(EntityTypeBuilder<Hire> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.DeliveryDate).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PurchaseDate).IsRequired().HasMaxLength(100);

        }
    }
}
