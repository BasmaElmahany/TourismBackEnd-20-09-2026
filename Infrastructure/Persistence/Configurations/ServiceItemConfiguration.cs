using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Domain.Entities;
using System.Text.Json;

namespace Tourism.Infrastructure.Persistence.Configurations
{
    public class ServiceItemConfiguration : IEntityTypeConfiguration<ServiceItem>
    {
        public void Configure(EntityTypeBuilder<ServiceItem> builder)
        {
            builder.HasKey(x => x.Id);

            // تحويل الـ OpeningHours (التي تحوي Dictionaries لجدول مواعيد الأيام) إلى JSON
            builder.Property(x => x.OpeningHours)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => string.IsNullOrEmpty(v) ? null : JsonSerializer.Deserialize<ServiceOpeningHours>(v, (JsonSerializerOptions?)null)
                   );

            builder.PrimitiveCollection(x => x.Features);
            builder.PrimitiveCollection(x => x.FeaturesAr);
        }
    }
}
