using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class TourGuideDto
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")] public LocalizedTextDto Name { get; set; } = new();
        [JsonPropertyName("bio")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocalizedTextDto? Bio { get; set; }
        [JsonPropertyName("languages")][JsonConverter(typeof(LocalizedArrayConverter))] public List<object> Languages { get; set; } = new();
        [JsonPropertyName("imageUrl")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? ImageUrl { get; set; }
        [JsonPropertyName("phone")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocalizedTextDto? Phone { get; set; }
        [JsonPropertyName("email")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocalizedTextDto? Email { get; set; }
        [JsonPropertyName("social")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public SocialLinksDto? Social { get; set; }
        [JsonPropertyName("location")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocationInfoDto? Location { get; set; }
        [JsonPropertyName("rating")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public double? Rating { get; set; }
    }
}
