using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Domain.Entities.Common;

namespace Tourism.Domain.Entities
{
    public class Photographer
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public LocalizedText Name { get; set; } = new();
        public LocalizedText? Bio { get; set; }
        public List<object>? Specialties { get; set; }
        public string? ImageUrl { get; set; }
        public LocalizedText? Phone { get; set; }
        public LocalizedText? Email { get; set; }
        public SocialLinks? Social { get; set; }
        public LocationInfo? Location { get; set; }
        public double? Rating { get; set; }
    }
}
