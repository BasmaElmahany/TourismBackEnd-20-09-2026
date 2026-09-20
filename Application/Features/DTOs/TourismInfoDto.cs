using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class TourismInfoDto
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("title")] public LocalizedTextDto Title { get; set; } = new();
        [JsonPropertyName("climate")] public LocalizedTextDto Climate { get; set; } = new();
        [JsonPropertyName("bestTimeToVisit")] public LocalizedTextDto BestTimeToVisit { get; set; } = new();
        [JsonPropertyName("whatToWear")] public LocalizedTextDto WhatToWear { get; set; } = new();
        [JsonPropertyName("notes")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocalizedTextDto? Notes { get; set; }
        [JsonPropertyName("lastUpdated")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? LastUpdated { get; set; }
    }
}
