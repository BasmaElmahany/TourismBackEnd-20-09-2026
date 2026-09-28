using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Domain.Entities.Common;

namespace Tourism.Domain.Entities
{
    public class Hotel
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public LocalizedText Name { get; set; } = new();
        public LocalizedText? Description { get; set; } = new();
        public string ImageUrl { get; set; } = string.Empty;
        public List<string> ImageGallery { get; set; } = new();

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public double? Rating { get; set; }
        public int? ReviewCount { get; set; }

        public LocalizedText? PriceRange { get; set; } = new();
        public List<LocalizedText>? Amenities { get; set; } = new();
        public List<LocalizedText>? RoomTypes { get; set; } = new();

        public HotelContactInfo? ContactInfo { get; set; } = new();
        public decimal? StarRating { get; set; }
    }
}
