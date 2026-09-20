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
    public class TourismEventConfiguration : IEntityTypeConfiguration<TourismEvent>
    {
        public void Configure(EntityTypeBuilder<TourismEvent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.ContactInfo, c => c.ToJson());
        }
    }
}
