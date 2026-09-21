using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.DTOs
{
    public class CreateTourismEventDto
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public LocalizedTextDto Name { get; set; } = new();

        [JsonPropertyName("description")]
        public LocalizedTextDto Description { get; set; } = new();

        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("location")]
        public LocalizedTextDto Location { get; set; } = new();

        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        [JsonPropertyName("ticketPrice")]
        public LocalizedTextDto? TicketPrice { get; set; }

        [JsonPropertyName("isFree")]
        public bool IsFree { get; set; } = false;

        [JsonPropertyName("category")]
        public LocalizedTextDto Category { get; set; } = new();

        [JsonPropertyName("organizer")]
        public LocalizedTextDto? Organizer { get; set; }

        [JsonPropertyName("contactInfo")]
        public EventContactInfoDto? ContactInfo { get; set; }
    }
}
