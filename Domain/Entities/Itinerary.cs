using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Domain.Entities
{
    public class Itinerary
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string Difficulty { get; set; } = string.Empty;
        public decimal EstimatedCost { get; set; }
        public string Category { get; set; } = string.Empty;

        public List<string> Highlights { get; set; } = new();
        public List<ItineraryDay> DayByDay { get; set; } = new();
        public List<string> IncludedServices { get; set; } = new();
        public List<string> ExcludedServices { get; set; } = new();
    }
}
