using System.Text.Json.Serialization;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class SouvenirShopDto
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("nameAr")] public string NameAr { get; set; } = string.Empty;

        [JsonPropertyName("description")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? Description { get; set; }
        [JsonPropertyName("descriptionAr")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? DescriptionAr { get; set; }
        [JsonPropertyName("category")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? Category { get; set; }
        [JsonPropertyName("categoryAr")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? CategoryAr { get; set; }
        [JsonPropertyName("address")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? Address { get; set; }
        [JsonPropertyName("addressAr")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? AddressAr { get; set; }
        [JsonPropertyName("phone")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? Phone { get; set; }
        [JsonPropertyName("email")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? Email { get; set; }

        [JsonPropertyName("image")] public string Image { get; set; } = string.Empty;
        [JsonPropertyName("images")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public List<string>? Images { get; set; }

        [JsonPropertyName("latitude")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public double? Latitude { get; set; }
        [JsonPropertyName("longitude")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public double? Longitude { get; set; }
        [JsonPropertyName("distanceKm")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public double? DistanceKm { get; set; }
        [JsonPropertyName("rating")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public double? Rating { get; set; }
        [JsonPropertyName("reviewCount")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public int? ReviewCount { get; set; }

        [JsonPropertyName("priceRange")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? PriceRange { get; set; }
        [JsonPropertyName("openingHours")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? OpeningHours { get; set; }
        [JsonPropertyName("openingHoursAr")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public string? OpeningHoursAr { get; set; }

        [JsonPropertyName("isFeatured")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? IsFeatured { get; set; }
        [JsonPropertyName("acceptsCreditCard")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? AcceptsCreditCard { get; set; }
        [JsonPropertyName("hasDelivery")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? HasDelivery { get; set; }
        [JsonPropertyName("hasOnlineStore")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public bool? HasOnlineStore { get; set; }

        [JsonPropertyName("specialties")] public List<string> Specialties { get; set; } = new();
        [JsonPropertyName("specialtiesAr")] public List<string> SpecialtiesAr { get; set; } = new();

        [JsonPropertyName("products")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] public List<SouvenirProductDto>? Products { get; set; }
    }
}