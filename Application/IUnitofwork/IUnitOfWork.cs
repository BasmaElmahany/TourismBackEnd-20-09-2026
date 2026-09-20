

using Tourism.Domain.Entities;

namespace Tourism.Application.IUnitofwork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Attraction> Attractions { get; }
        IRepository<Hotel> Hotels { get; }
        IRepository<Restaurant> Restaurants { get; }
        IRepository<ServiceItem> Services { get; }
        IRepository<TourGuide> TourGuides { get; }
        IRepository<Photographer> Photographers { get; }
        IRepository<BlogPost> BlogPosts { get; }
        IRepository<SouvenirCategory> SouvenirCategories { get; }
        IRepository<SouvenirShop> SouvenirShops { get; }
        IRepository<SouvenirProduct> SouvenirProducts { get; }
        IRepository<TourismEvent> Events { get; }
        IRepository<Itinerary> Itineraries { get; }
        IRepository<TourismInfo> TourismInfos { get; }
        IRepository<VisitorInfo> VisitorInfos { get; }
        IRepository<BookingRequest> Bookings { get; }
        IRepository<ContactMessage> ContactMessages { get; }
        IRepository<NewsletterSubscription> NewsletterSubscriptions { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
