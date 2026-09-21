using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.DTOs
{
    public class TourismEventDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public LocalizedTextDto Name { get; set; } = new();

        [JsonPropertyName("description")]
        public LocalizedTextDto Description { get; set; } = new();

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;

        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("location")]
        public LocalizedTextDto Location { get; set; } = new();

        [JsonPropertyName("latitude")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Longitude { get; set; }

        [JsonPropertyName("ticketPrice")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LocalizedTextDto? TicketPrice { get; set; }

        [JsonPropertyName("isFree")]
        public bool IsFree { get; set; }

        [JsonPropertyName("category")]
        public LocalizedTextDto Category { get; set; } = new();

        [JsonPropertyName("organizer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LocalizedTextDto? Organizer { get; set; }

        [JsonPropertyName("contactInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EventContactInfoDto? ContactInfo { get; set; }
    }
}
