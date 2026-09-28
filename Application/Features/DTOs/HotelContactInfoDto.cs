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
        [JsonPropertyName("phone")] public string? Phone { get; set; } 
        [JsonPropertyName("email")] public string? Email { get; set; } 
        [JsonPropertyName("website")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? Website { get; set; }
    }
}
