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
    public class ItineraryConfiguration : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.EstimatedCost).HasPrecision(18, 2);

            builder.PrimitiveCollection(x => x.Highlights);
            builder.PrimitiveCollection(x => x.IncludedServices);
            builder.PrimitiveCollection(x => x.ExcludedServices);

            builder.HasMany(x => x.DayByDay)
                   .WithOne(d => d.Itinerary)
                   .HasForeignKey(d => d.ItineraryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ItineraryDayConfiguration : IEntityTypeConfiguration<ItineraryDay>
    {
        public void Configure(EntityTypeBuilder<ItineraryDay> builder)
        {
            builder.HasKey(x => x.Id);

            builder.PrimitiveCollection(x => x.Activities);
            builder.PrimitiveCollection(x => x.Meals);
        }
    }
}
