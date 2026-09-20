using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Domain.Entities;
using System.Text.Json;
using Tourism.Domain.Entities.Common;

namespace Tourism.Infrastructure.Persistence.Configurations
{
    public class AttractionConfiguration : IEntityTypeConfiguration<Attraction>
    {
        public void Configure(EntityTypeBuilder<Attraction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name);
            builder.OwnsOne(x => x.Description);
            builder.OwnsOne(x => x.OpeningHours);
            builder.OwnsOne(x => x.TicketPrice);
            builder.OwnsOne(x => x.Category);
            builder.OwnsOne(x => x.HistoricalPeriod);
            builder.OwnsOne(x => x.Significance);

            builder.Property(x => x.Features)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<List<LocalizedText>>(v, (JsonSerializerOptions?)null) ?? new List<LocalizedText>()
                   );

            builder.PrimitiveCollection(x => x.ImageGallery);
        }
    }
}
