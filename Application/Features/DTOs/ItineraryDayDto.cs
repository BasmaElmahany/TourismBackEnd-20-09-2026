using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.DTOs
{
    public class ItineraryDayDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("day")]
        public int Day { get; set; }

        [JsonPropertyName("title")]
        public LocalizedTextDto Title { get; set; } = new();

        [JsonPropertyName("description")]
        public LocalizedTextDto Description { get; set; } = new();

        [JsonPropertyName("activities")]
        public List<LocalizedTextDto> Activities { get; set; } = new();

        [JsonPropertyName("meals")]
        public List<LocalizedTextDto> Meals { get; set; } = new();

        [JsonPropertyName("accommodation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LocalizedTextDto? Accommodation { get; set; }
    }
}
