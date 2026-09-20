using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class ServiceItemDto
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("nameAr")] public string NameAr { get; set; } = string.Empty;
        [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;
        [JsonPropertyName("typeAr")] public string TypeAr { get; set; } = string.Empty;
        [JsonPropertyName("description")] public string Description { get; set; } = string.Empty;
        [JsonPropertyName("descriptionAr")] public string DescriptionAr { get; set; } = string.Empty;
        [JsonPropertyName("address")] public string Address { get; set; } = string.Empty;
        [JsonPropertyName("addressAr")] public string AddressAr { get; set; } = string.Empty;
        [JsonPropertyName("phone")] public string Phone { get; set; } = string.Empty;
        [JsonPropertyName("email")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? Email { get; set; }
        [JsonPropertyName("image")] public string Image { get; set; } = string.Empty;
        [JsonPropertyName("latitude")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public double? Latitude { get; set; }
        [JsonPropertyName("longitude")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public double? Longitude { get; set; }
        [JsonPropertyName("distanceKm")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public double? DistanceKm { get; set; }
        [JsonPropertyName("rating")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public double? Rating { get; set; }
        [JsonPropertyName("is24h")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? Is24h { get; set; }
        [JsonPropertyName("isEmergency")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? IsEmergency { get; set; }
        [JsonPropertyName("isFeatured")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? IsFeatured { get; set; }
        [JsonPropertyName("features")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public List<string>? Features { get; set; }
        [JsonPropertyName("featuresAr")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public List<string>? FeaturesAr { get; set; }
        [JsonPropertyName("commentsCount")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public int? CommentsCount { get; set; }
        [JsonPropertyName("specialty")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? Specialty { get; set; }
        [JsonPropertyName("specialtyAr")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? SpecialtyAr { get; set; }
        [JsonPropertyName("openingHours")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public ServiceOpeningHoursDto? OpeningHours { get; set; }
        [JsonPropertyName("hasDelivery")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? HasDelivery { get; set; }
        [JsonPropertyName("acceptsInsurance")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? AcceptsInsurance { get; set; }
    }
}
