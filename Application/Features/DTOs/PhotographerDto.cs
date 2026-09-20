
using System.Text.Json.Serialization;


namespace Tourism.Application.Features.Authentication.DTOs
{
    public class PhotographerDto
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")] public LocalizedTextDto Name { get; set; } = new();
        [JsonPropertyName("bio")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocalizedTextDto? Bio { get; set; }
        [JsonPropertyName("specialties")][JsonConverter(typeof(LocalizedArrayConverter))][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public List<object>? Specialties { get; set; }
        [JsonPropertyName("imageUrl")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? ImageUrl { get; set; }
        [JsonPropertyName("phone")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocalizedTextDto? Phone { get; set; }
        [JsonPropertyName("email")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocalizedTextDto? Email { get; set; }
        [JsonPropertyName("social")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public SocialLinksDto? Social { get; set; }
        [JsonPropertyName("location")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocationInfoDto? Location { get; set; }
        [JsonPropertyName("rating")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public double? Rating { get; set; }
    }
}
