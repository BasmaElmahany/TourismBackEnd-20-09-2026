using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Domain.Entities.Common;

namespace Tourism.Domain.Entities
{
    public class ItineraryDay
    {
        [Key]
        public int Id { get; set; }
        public int? Day { get; set; }
        public LocalizedText? Title { get; set; }
        public LocalizedText? Description { get; set; }

        public List<LocalizedText>? Activities { get; set; } = new();

        public List<LocalizedText>? Meals { get; set; } = new();

        public LocalizedText? Accommodation { get; set; }

        public string? ItineraryId { get; set; }
        public Itinerary? Itinerary { get; set; }
    }
}
