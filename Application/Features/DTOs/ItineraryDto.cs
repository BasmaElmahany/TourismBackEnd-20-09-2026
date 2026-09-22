using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.DTOs
{
    public class ItineraryDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public LocalizedTextDto Title { get; set; } = new();

        [JsonPropertyName("description")]
        public LocalizedTextDto Description { get; set; } = new();

        [JsonPropertyName("duration")]
        public LocalizedTextDto Duration { get; set; } = new();

        [JsonPropertyName("difficulty")]
        public LocalizedTextDto Difficulty { get; set; } = new();

        [JsonPropertyName("price")]
        public LocalizedTextDto Price { get; set; } = new();

        [JsonPropertyName("image")]
        public string Image { get; set; } = string.Empty;

        [JsonPropertyName("highlights")]
        public List<LocalizedTextDto> Highlights { get; set; } = new();

        [JsonPropertyName("includes")]
        public List<LocalizedTextDto> Includes { get; set; } = new();

        [JsonPropertyName("excludes")]
        public List<LocalizedTextDto> Excludes { get; set; } = new();

        [JsonPropertyName("bestTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LocalizedTextDto? BestTime { get; set; }

        [JsonPropertyName("groupSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LocalizedTextDto? GroupSize { get; set; }

        [JsonPropertyName("isFeatured")]
        public bool IsFeatured { get; set; }

        [JsonPropertyName("category")]
        public LocalizedTextDto Category { get; set; } = new();

        [JsonPropertyName("dayByDay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ItineraryDayDto>? DayByDay { get; set; }
    }

 
}