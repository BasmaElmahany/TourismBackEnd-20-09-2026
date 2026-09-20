using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class HotelContactInfoDto
    {
        [JsonPropertyName("phone")] public LocalizedTextDto Phone { get; set; } = new();
        [JsonPropertyName("email")] public LocalizedTextDto Email { get; set; } = new();
        [JsonPropertyName("website")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public LocalizedTextDto? Website { get; set; }
    }
}
