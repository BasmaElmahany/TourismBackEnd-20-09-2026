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
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name);
            builder.OwnsOne(x => x.Description);
            builder.OwnsOne(x => x.PriceRange);

            // تحويل ContactInfo المتداخل إلى JSON String مباشرة
            builder.Property(x => x.ContactInfo)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<HotelContactInfo>(v, (JsonSerializerOptions?)null) ?? new HotelContactInfo()
                   );

            // تحويل قوائم الـ LocalizedText إلى JSON String
            builder.Property(x => x.Amenities)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<List<LocalizedText>>(v, (JsonSerializerOptions?)null) ?? new List<LocalizedText>()
                   );

            builder.Property(x => x.RoomTypes)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<List<LocalizedText>>(v, (JsonSerializerOptions?)null) ?? new List<LocalizedText>()
                   );

            builder.PrimitiveCollection(x => x.ImageGallery);
        }
    }
}
