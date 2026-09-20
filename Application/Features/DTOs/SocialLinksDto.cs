using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class SocialLinksDto
    {
        [JsonPropertyName("facebook")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Facebook { get; set; }

        [JsonPropertyName("instagram")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Instagram { get; set; }

        [JsonPropertyName("twitter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Twitter { get; set; }

        [JsonPropertyName("tiktok")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Tiktok { get; set; }

        [JsonPropertyName("youtube")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Youtube { get; set; }
    }
}
