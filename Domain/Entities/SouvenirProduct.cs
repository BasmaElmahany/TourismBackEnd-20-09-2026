using System.ComponentModel.DataAnnotations;

namespace Tourism.Domain.Entities
{
    public class SouvenirProduct
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string ShopId { get; set; } = string.Empty;
        public SouvenirShop? Shop { get; set; }

        public string Name { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? DescriptionAr { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
        public string CategoryAr { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public string Currency { get; set; } = "EGP";

        public string Image { get; set; } = string.Empty;
        public List<string>? Images { get; set; }

        public bool? InStock { get; set; }
        public bool? Handmade { get; set; }
        public string? Material { get; set; }
        public string? MaterialAr { get; set; }
        public string? Origin { get; set; }
        public string? OriginAr { get; set; }
    }
}
