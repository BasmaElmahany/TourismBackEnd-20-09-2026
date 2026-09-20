using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities;
using Tourism.Infrastructure.Persistence;
using Tourism.Infrastructure.Repositories;

namespace Tourism.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Attractions = new Repository<Attraction>(_context);
            Hotels = new Repository<Hotel>(_context);
            Restaurants = new Repository<Restaurant>(_context);
            Services = new Repository<ServiceItem>(_context);
            TourGuides = new Repository<TourGuide>(_context);
            Photographers = new Repository<Photographer>(_context);
            BlogPosts = new Repository<BlogPost>(_context);
            SouvenirCategories = new Repository<SouvenirCategory>(_context);
            SouvenirShops = new Repository<SouvenirShop>(_context);
            SouvenirProducts = new Repository<SouvenirProduct>(_context);
            Events = new Repository<TourismEvent>(_context);
            Itineraries = new Repository<Itinerary>(_context);
            TourismInfos = new Repository<TourismInfo>(_context);
            VisitorInfos = new Repository<VisitorInfo>(_context);
            Bookings = new Repository<BookingRequest>(_context);
            ContactMessages = new Repository<ContactMessage>(_context);
            NewsletterSubscriptions = new Repository<NewsletterSubscription>(_context);
        }

        public IRepository<Attraction> Attractions { get; }
        public IRepository<Hotel> Hotels { get; }
        public IRepository<Restaurant> Restaurants { get; }
        public IRepository<ServiceItem> Services { get; }
        public IRepository<TourGuide> TourGuides { get; }
        public IRepository<Photographer> Photographers { get; }
        public IRepository<BlogPost> BlogPosts { get; }
        public IRepository<SouvenirCategory> SouvenirCategories { get; }
        public IRepository<SouvenirShop> SouvenirShops { get; }
        public IRepository<SouvenirProduct> SouvenirProducts { get; }
        public IRepository<TourismEvent> Events { get; }
        public IRepository<Itinerary> Itineraries { get; }
        public IRepository<TourismInfo> TourismInfos { get; }
        public IRepository<VisitorInfo> VisitorInfos { get; }
        public IRepository<BookingRequest> Bookings { get; }
        public IRepository<ContactMessage> ContactMessages { get; }
        public IRepository<NewsletterSubscription> NewsletterSubscriptions { get; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}