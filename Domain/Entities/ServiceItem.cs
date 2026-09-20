using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Domain.Entities
{
    public class ServiceItem
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string TypeAr { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string DescriptionAr { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string AddressAr { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Image { get; set; } = string.Empty;

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? DistanceKm { get; set; }
        public double? Rating { get; set; }

        public bool? Is24h { get; set; }
        public bool? IsEmergency { get; set; }
        public bool? IsFeatured { get; set; }

        public List<string>? Features { get; set; }
        public List<string>? FeaturesAr { get; set; }
        public int? CommentsCount { get; set; }

        public string? Specialty { get; set; }
        public string? SpecialtyAr { get; set; }

        public ServiceOpeningHours? OpeningHours { get; set; }
        public bool? HasDelivery { get; set; }
        public bool? AcceptsInsurance { get; set; }
    }
}
