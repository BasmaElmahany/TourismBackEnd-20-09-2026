using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class SouvenirCategoryDto
    {
        [JsonPropertyName("key")] public string Key { get; set; } = string.Empty;
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("nameAr")] public string NameAr { get; set; } = string.Empty;
        [JsonPropertyName("icon")] public string Icon { get; set; } = string.Empty;
        [JsonPropertyName("description")] public string Description { get; set; } = string.Empty;
        [JsonPropertyName("descriptionAr")] public string DescriptionAr { get; set; } = string.Empty;
    }
}
