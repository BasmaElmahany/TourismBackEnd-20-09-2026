using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Domain.Entities
{
    public class SouvenirShop
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DescriptionAr { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
        public string CategoryAr { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string AddressAr { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }

        public string Image { get; set; } = string.Empty;
        public List<string>? Images { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? DistanceKm { get; set; }
        public double? Rating { get; set; }
        public int? ReviewCount { get; set; }

        public string PriceRange { get; set; } = string.Empty;
        public string OpeningHours { get; set; } = string.Empty;
        public string OpeningHoursAr { get; set; } = string.Empty;

        public bool? IsFeatured { get; set; }
        public bool? AcceptsCreditCard { get; set; }
        public bool? HasDelivery { get; set; }
        public bool? HasOnlineStore { get; set; }

        public List<string> Specialties { get; set; } = new();
        public List<string> SpecialtiesAr { get; set; } = new();

        public List<SouvenirProduct> Products { get; set; } = new();
    }
}
