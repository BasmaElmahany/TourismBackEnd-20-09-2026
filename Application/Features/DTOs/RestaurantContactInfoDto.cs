using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class RestaurantContactInfoDto
    {
        [JsonPropertyName("phone")] public LocalizedTextDto Phone { get; set; } = new();
        [JsonPropertyName("email")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? Email { get; set; }
    }
}
