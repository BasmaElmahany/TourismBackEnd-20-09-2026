using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Domain.Entities
{
    public class ItineraryDay
    {
        [Key]
        public int Id { get; set; }
        public int Day { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<string> Activities { get; set; } = new();
        public List<string> Meals { get; set; } = new();
        public string? Accommodation { get; set; }

        public string ItineraryId { get; set; } = string.Empty;
        public Itinerary? Itinerary { get; set; }
    }
}
