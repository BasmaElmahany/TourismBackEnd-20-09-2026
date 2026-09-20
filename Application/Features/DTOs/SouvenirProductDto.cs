using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class SouvenirProductDto
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("nameAr")] public string NameAr { get; set; } = string.Empty;
        [JsonPropertyName("description")] public string Description { get; set; } = string.Empty;
        [JsonPropertyName("descriptionAr")] public string DescriptionAr { get; set; } = string.Empty;
        [JsonPropertyName("category")] public string Category { get; set; } = string.Empty;
        [JsonPropertyName("categoryAr")] public string CategoryAr { get; set; } = string.Empty;
        [JsonPropertyName("price")] public decimal Price { get; set; }
        [JsonPropertyName("currency")] public string Currency { get; set; } = string.Empty;
        [JsonPropertyName("image")] public string Image { get; set; } = string.Empty;
        [JsonPropertyName("images")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public List<string>? Images { get; set; }
        [JsonPropertyName("inStock")] public bool InStock { get; set; }
        [JsonPropertyName("handmade")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? Handmade { get; set; }
        [JsonPropertyName("material")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? Material { get; set; }
        [JsonPropertyName("materialAr")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? MaterialAr { get; set; }
        [JsonPropertyName("origin")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? Origin { get; set; }
        [JsonPropertyName("originAr")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? OriginAr { get; set; }
    }
}
