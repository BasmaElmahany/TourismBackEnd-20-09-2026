using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Domain.Entities;

namespace Tourism.Infrastructure.Persistence.Configurations
{
    public class SouvenirCategoryConfiguration : IEntityTypeConfiguration<SouvenirCategory>
    {
        public void Configure(EntityTypeBuilder<SouvenirCategory> builder)
        {
            builder.HasKey(x => x.Key);
        }
    }

    public class SouvenirShopConfiguration : IEntityTypeConfiguration<SouvenirShop>
    {
        public void Configure(EntityTypeBuilder<SouvenirShop> builder)
        {
            builder.HasKey(x => x.Id);

            builder.PrimitiveCollection(x => x.Images);
            builder.PrimitiveCollection(x => x.Specialties);
            builder.PrimitiveCollection(x => x.SpecialtiesAr);

            builder.HasMany(x => x.Products)
                   .WithOne(p => p.Shop)
                   .HasForeignKey(p => p.ShopId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class SouvenirProductConfiguration : IEntityTypeConfiguration<SouvenirProduct>
    {
        public void Configure(EntityTypeBuilder<SouvenirProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price).HasPrecision(18, 2);
            builder.PrimitiveCollection(x => x.Images);
        }
    }
}
