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
    public class TourismInfoConfiguration : IEntityTypeConfiguration<TourismInfo>
    {
        public void Configure(EntityTypeBuilder<TourismInfo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Title);
            builder.OwnsOne(x => x.Climate);
            builder.OwnsOne(x => x.BestTimeToVisit);
            builder.OwnsOne(x => x.WhatToWear);
            builder.OwnsOne(x => x.Notes);
        }
    }

    public class VisitorInfoConfiguration : IEntityTypeConfiguration<VisitorInfo>
    {
        public void Configure(EntityTypeBuilder<VisitorInfo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }

    public class BookingRequestConfiguration : IEntityTypeConfiguration<BookingRequest>
    {
        public void Configure(EntityTypeBuilder<BookingRequest> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }

    public class ContactMessageConfiguration : IEntityTypeConfiguration<ContactMessage>
    {
        public void Configure(EntityTypeBuilder<ContactMessage> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }

    public class NewsletterSubscriptionConfiguration : IEntityTypeConfiguration<NewsletterSubscription>
    {
        public void Configure(EntityTypeBuilder<NewsletterSubscription> builder)
        {
            builder.HasKey(x => x.Email);
            builder.PrimitiveCollection(x => x.Preferences);
        }
    }
}
