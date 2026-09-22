using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text.Json;
using Tourism.Domain.Entities;
using Tourism.Domain.Entities.Common;

namespace Tourism.Infrastructure.Persistence.Configurations
{
    public class ItineraryConfiguration : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.HasKey(x => x.Id);

            // كائنات LocalizedText الفردية كـ Owned Types مثل الفنادق
            builder.OwnsOne(x => x.Title);
            builder.OwnsOne(x => x.Description);
            builder.OwnsOne(x => x.Duration);
            builder.OwnsOne(x => x.Difficulty);
            builder.OwnsOne(x => x.Price);
            builder.OwnsOne(x => x.BestTime);
            builder.OwnsOne(x => x.GroupSize);
            builder.OwnsOne(x => x.Category);

            // تحويل قوائم الـ LocalizedText إلى JSON String مباشرة
            builder.Property(x => x.Highlights)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<List<LocalizedText>>(v, (JsonSerializerOptions?)null) ?? new List<LocalizedText>()
                   );

            builder.Property(x => x.Includes)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<List<LocalizedText>>(v, (JsonSerializerOptions?)null) ?? new List<LocalizedText>()
                   );

            builder.Property(x => x.Excludes)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<List<LocalizedText>>(v, (JsonSerializerOptions?)null) ?? new List<LocalizedText>()
                   );

            builder.Property(x => x.Image).IsRequired(false);
            builder.Property(x => x.IsFeatured).HasDefaultValue(false);

            // علاقة تفاصيل الأيام (Day by Day)
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

            builder.OwnsOne(x => x.Title);
            builder.OwnsOne(x => x.Description);
            builder.OwnsOne(x => x.Accommodation);

            // تحويل قوائم الـ LocalizedText الخاصة بالأيام إلى JSON String
            builder.Property(x => x.Activities)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<List<LocalizedText>>(v, (JsonSerializerOptions?)null) ?? new List<LocalizedText>()
                   );

            builder.Property(x => x.Meals)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<List<LocalizedText>>(v, (JsonSerializerOptions?)null) ?? new List<LocalizedText>()
                   );
        }
    }
}