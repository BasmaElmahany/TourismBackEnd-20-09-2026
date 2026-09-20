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
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Title);
            builder.OwnsOne(x => x.Content);
            builder.OwnsOne(x => x.Excerpt);
            builder.OwnsOne(x => x.Author);
            builder.OwnsOne(x => x.Category);

            // Tags مصفوفة متداخلة (Nested Array) تحوي كائنات
            builder.Property(x => x.Tags)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<List<List<object>>>(v, (JsonSerializerOptions?)null) ?? new List<List<object>>()
                   );
        }
    }
}
