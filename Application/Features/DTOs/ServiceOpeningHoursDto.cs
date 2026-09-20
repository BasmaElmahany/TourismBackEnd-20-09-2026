using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class ServiceOpeningHoursDto
    {
        [JsonPropertyName("en")] public ServiceWeeklyScheduleDto En { get; set; } = new();
        [JsonPropertyName("ar")] public Dictionary<string, string> Ar { get; set; } = new();
    }
}
