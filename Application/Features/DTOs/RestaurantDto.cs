using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class RestaurantDto
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")] public LocalizedTextDto Name { get; set; } = new();
        [JsonPropertyName("description")] public LocalizedTextDto Description { get; set; } = new();
        [JsonPropertyName("imageUrl")] public string ImageUrl { get; set; } = string.Empty;
        [JsonPropertyName("imageGallery")] public List<string> ImageGallery { get; set; } = new();
        [JsonPropertyName("latitude")] public double Latitude { get; set; }
        [JsonPropertyName("longitude")] public double Longitude { get; set; }
        [JsonPropertyName("rating")] public double Rating { get; set; }
        [JsonPropertyName("reviewCount")] public int ReviewCount { get; set; }
        [JsonPropertyName("cuisineType")] public LocalizedTextDto CuisineType { get; set; } = new();
        [JsonPropertyName("priceRange")] public LocalizedTextDto PriceRange { get; set; } = new();
        [JsonPropertyName("openingHours")] public LocalizedTextDto OpeningHours { get; set; } = new();
        [JsonPropertyName("specialties")] public List<LocalizedTextDto> Specialties { get; set; } = new();
        [JsonPropertyName("center")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocalizedTextDto? Center { get; set; }
        [JsonPropertyName("menuUrl")][JsonConverter(typeof(LocalizedTextOrStringConverter))][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public object? MenuUrl { get; set; }
        [JsonPropertyName("contactInfo")] public RestaurantContactInfoDto ContactInfo { get; set; } = new();
        [JsonPropertyName("features")] public List<LocalizedTextDto> Features { get; set; } = new();
    }
}
