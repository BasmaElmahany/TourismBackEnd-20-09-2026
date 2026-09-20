using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class SouvenirShopDto
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("nameAr")] public string NameAr { get; set; } = string.Empty;
        [JsonPropertyName("description")] public string Description { get; set; } = string.Empty;
        [JsonPropertyName("descriptionAr")] public string DescriptionAr { get; set; } = string.Empty;
        [JsonPropertyName("category")] public string Category { get; set; } = string.Empty;
        [JsonPropertyName("categoryAr")] public string CategoryAr { get; set; } = string.Empty;
        [JsonPropertyName("address")] public string Address { get; set; } = string.Empty;
        [JsonPropertyName("addressAr")] public string AddressAr { get; set; } = string.Empty;
        [JsonPropertyName("phone")] public string Phone { get; set; } = string.Empty;
        [JsonPropertyName("email")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? Email { get; set; }
        [JsonPropertyName("image")] public string Image { get; set; } = string.Empty;
        [JsonPropertyName("images")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public List<string>? Images { get; set; }
        [JsonPropertyName("latitude")] public double Latitude { get; set; }
        [JsonPropertyName("longitude")] public double Longitude { get; set; }
        [JsonPropertyName("distanceKm")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public double? DistanceKm { get; set; }
        [JsonPropertyName("rating")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public double? Rating { get; set; }
        [JsonPropertyName("reviewCount")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public int? ReviewCount { get; set; }
        [JsonPropertyName("priceRange")] public string PriceRange { get; set; } = string.Empty;
        [JsonPropertyName("openingHours")] public string OpeningHours { get; set; } = string.Empty;
        [JsonPropertyName("openingHoursAr")] public string OpeningHoursAr { get; set; } = string.Empty;
        [JsonPropertyName("isFeatured")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? IsFeatured { get; set; }
        [JsonPropertyName("acceptsCreditCard")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? AcceptsCreditCard { get; set; }
        [JsonPropertyName("hasDelivery")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? HasDelivery { get; set; }
        [JsonPropertyName("hasOnlineStore")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? HasOnlineStore { get; set; }
        [JsonPropertyName("specialties")] public List<string> Specialties { get; set; } = new();
        [JsonPropertyName("specialtiesAr")] public List<string> SpecialtiesAr { get; set; } = new();
        [JsonPropertyName("products")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public List<SouvenirProductDto>? Products { get; set; }
    }
}
