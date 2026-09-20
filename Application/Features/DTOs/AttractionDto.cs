using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class AttractionDto
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")] public LocalizedTextDto Name { get; set; } = new();
        [JsonPropertyName("description")] public LocalizedTextDto Description { get; set; } = new();
        [JsonPropertyName("imageUrl")] public string ImageUrl { get; set; } = string.Empty;
        [JsonPropertyName("imageGallery")] public List<string> ImageGallery { get; set; } = new();
        [JsonPropertyName("latitude")] public double Latitude { get; set; }
        [JsonPropertyName("longitude")] public double Longitude { get; set; }
        [JsonPropertyName("openingHours")] public LocalizedTextDto OpeningHours { get; set; } = new();
        [JsonPropertyName("ticketPrice")] public LocalizedTextDto TicketPrice { get; set; } = new();
        [JsonPropertyName("bookingUrl")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? BookingUrl { get; set; }
        [JsonPropertyName("rating")] public double Rating { get; set; }
        [JsonPropertyName("reviewCount")] public int ReviewCount { get; set; }
        [JsonPropertyName("category")] public LocalizedTextDto Category { get; set; } = new();
        [JsonPropertyName("features")] public List<LocalizedTextDto> Features { get; set; } = new();
        [JsonPropertyName("historicalPeriod")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocalizedTextDto? HistoricalPeriod { get; set; }
        [JsonPropertyName("significance")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocalizedTextDto? Significance { get; set; }
    }
}
