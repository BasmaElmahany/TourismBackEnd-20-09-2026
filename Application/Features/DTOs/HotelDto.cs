using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class HotelDto
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
        [JsonPropertyName("priceRange")] public LocalizedTextDto PriceRange { get; set; } = new();
        [JsonPropertyName("amenities")] public List<LocalizedTextDto> Amenities { get; set; } = new();
        [JsonPropertyName("roomTypes")] public List<LocalizedTextDto> RoomTypes { get; set; } = new();
        [JsonPropertyName("contactInfo")] public HotelContactInfoDto ContactInfo { get; set; } = new();
        [JsonPropertyName("starRating")] public decimal StarRating { get; set; }
    }
}
