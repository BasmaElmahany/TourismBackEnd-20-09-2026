using System.Reflection;
using DTourism.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tourism.Domain.Entities;

namespace Tourism.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Attraction> Attractions => Set<Attraction>();
        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<ServiceItem> Services => Set<ServiceItem>();
        public DbSet<TourGuide> TourGuides => Set<TourGuide>();
        public DbSet<Photographer> Photographers => Set<Photographer>();
        public DbSet<BlogPost> BlogPosts => Set<BlogPost>();
        public DbSet<SouvenirCategory> SouvenirCategories => Set<SouvenirCategory>();
        public DbSet<SouvenirShop> SouvenirShops => Set<SouvenirShop>();
        public DbSet<SouvenirProduct> SouvenirProducts => Set<SouvenirProduct>();
        public DbSet<TourismEvent> Events => Set<TourismEvent>();
        public DbSet<Itinerary> Itineraries => Set<Itinerary>();
        public DbSet<ItineraryDay> ItineraryDays => Set<ItineraryDay>();
        public DbSet<TourismInfo> TourismInfos => Set<TourismInfo>();
        public DbSet<VisitorInfo> VisitorInfos => Set<VisitorInfo>();
        public DbSet<BookingRequest> Bookings => Set<BookingRequest>();
        public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();
        public DbSet<NewsletterSubscription> NewsletterSubscriptions => Set<NewsletterSubscription>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // يطبق تلقائياً جميع كلاسات IEntityTypeConfiguration الموجودة في الـ Infrastructure
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}