using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Domain.Entities.Common;

namespace Tourism.Domain.Entities
{
    public class Itinerary
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public LocalizedText? Title { get; set; }
        public LocalizedText? Description { get; set; }
       

        public LocalizedText? Duration { get; set; }

        public LocalizedText? Difficulty { get; set; }

        public LocalizedText? Price { get; set; }

        public string? Image { get; set; }

        public List<LocalizedText>? Highlights { get; set; } = new();

        public List<LocalizedText>? Includes { get; set; } = new();

        public List<LocalizedText>? Excludes { get; set; } = new();

        public LocalizedText? BestTime { get; set; }

        public LocalizedText? GroupSize { get; set; }

        public bool? IsFeatured { get; set; } = false;

        public LocalizedText? Category { get; set; }

        // تفاصيل الأيام الاختيارية (Day by Day)
        public List<ItineraryDay>? DayByDay { get; set; } = new();
    }
}
