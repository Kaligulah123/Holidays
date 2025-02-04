using Holidays.Domain.Apartments;
using Holidays.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Infrastructure.Configurations
{
    internal sealed class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("apartments");

            builder.HasKey(apartment => apartment.Id);

            builder.OwnsOne(apartment => apartment.Address);

            builder.Property(apartment => apartment.Name)
                .HasMaxLength(200)
                .HasConversion(name => name.Value, value => new Name(value));

            builder.Property(apartment => apartment.Description)
               .HasMaxLength(2000)
               .HasConversion(description => description.Value, value => new Description(value));

            builder.OwnsOne(apartment => apartment.Price, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                priceBuilder.Property(money => money.Amount)
                    .HasPrecision(18, 4); // Especifica la precisión del decimal
            });

            builder.OwnsOne(apartment => apartment.CleaningFee, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                priceBuilder.Property(money => money.Amount)
                    .HasPrecision(18, 4); // Especifica la precisión del decimal
            });

            builder.Property<uint>("Version").IsRowVersion();
        }
    }
}
