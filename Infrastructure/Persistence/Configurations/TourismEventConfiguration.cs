using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tourism.Domain.Entities;

namespace Tourism.Infrastructure.Persistence.Configurations
{
    public class TourismEventConfiguration : IEntityTypeConfiguration<TourismEvent>
    {
        public void Configure(EntityTypeBuilder<TourismEvent> builder)
        {
            builder.HasKey(x => x.Id);

            // كائنات LocalizedText الفردية كـ Owned Types
            builder.OwnsOne(x => x.Name);
            builder.OwnsOne(x => x.Description);
            builder.OwnsOne(x => x.Location);
            builder.OwnsOne(x => x.TicketPrice);
            builder.OwnsOne(x => x.Category);
            builder.OwnsOne(x => x.Organizer);

            // الحقول الأساسية
            builder.Property(x => x.ImageUrl).IsRequired(false);
            builder.Property(x => x.IsFree).HasDefaultValue(false);
            builder.Property(x => x.Latitude).IsRequired(false);
            builder.Property(x => x.Longitude).IsRequired(false);

            // تحويل ContactInfo إلى JSON String
            builder.Property(x => x.ContactInfo)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => string.IsNullOrEmpty(v) ? null : JsonSerializer.Deserialize<EventContactInfo>(v, (JsonSerializerOptions?)null)
                   );
        }
    }
}
