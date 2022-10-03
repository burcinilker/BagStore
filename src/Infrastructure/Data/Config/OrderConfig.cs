using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.BuyerId)
                .IsRequired();

            builder.OwnsOne(x => x.ShippingAdress, navigationBuilder =>
            {
                navigationBuilder.WithOwner();

                navigationBuilder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(180);

                navigationBuilder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

                navigationBuilder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(60);

                navigationBuilder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(90);

                navigationBuilder.Property(a => a.ZipCode)
                .IsRequired()
                .HasMaxLength(18);

            });

            builder.Navigation(x => x.ShippingAdress).IsRequired();

        }
    }
}
