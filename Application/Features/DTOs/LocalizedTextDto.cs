using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class LocalizedTextDto
    {
        [JsonPropertyName("en")]
        public string En { get; set; } = string.Empty;

        [JsonPropertyName("ar")]
        public string Ar { get; set; } = string.Empty;
    }
}
