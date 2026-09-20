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
    public class PhotographerConfiguration : IEntityTypeConfiguration<Photographer>
    {
        public void Configure(EntityTypeBuilder<Photographer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name);
            builder.OwnsOne(x => x.Bio);
            builder.OwnsOne(x => x.Phone);
            builder.OwnsOne(x => x.Email);

            builder.Property(x => x.Social)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => string.IsNullOrEmpty(v) ? null : JsonSerializer.Deserialize<SocialLinks>(v, (JsonSerializerOptions?)null)
                   );

            builder.Property(x => x.Location)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => string.IsNullOrEmpty(v) ? null : JsonSerializer.Deserialize<LocationInfo>(v, (JsonSerializerOptions?)null)
                   );

            builder.Property(x => x.Specialties)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<List<object>>(v, (JsonSerializerOptions?)null) ?? new List<object>()
                   );
        }
    }
}
