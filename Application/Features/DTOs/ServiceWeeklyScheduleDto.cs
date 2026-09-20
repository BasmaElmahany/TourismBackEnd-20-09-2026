using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class ServiceWeeklyScheduleDto
    {
        [JsonPropertyName("monday")] public string Monday { get; set; } = string.Empty;
        [JsonPropertyName("tuesday")] public string Tuesday { get; set; } = string.Empty;
        [JsonPropertyName("wednesday")] public string Wednesday { get; set; } = string.Empty;
        [JsonPropertyName("thursday")] public string Thursday { get; set; } = string.Empty;
        [JsonPropertyName("friday")] public string Friday { get; set; } = string.Empty;
        [JsonPropertyName("saturday")] public string Saturday { get; set; } = string.Empty;
        [JsonPropertyName("sunday")] public string Sunday { get; set; } = string.Empty;
    }
}
