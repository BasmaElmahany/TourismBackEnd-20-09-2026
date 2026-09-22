using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Domain.Entities.Common;

namespace Tourism.Domain.Entities
{
    public class TourismEvent
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public LocalizedText? Name { get; set; } 
        public LocalizedText? Description { get; set; } 
        public string ImageUrl { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LocalizedText? Location { get; set; } 

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public LocalizedText? TicketPrice { get; set; } 
        public bool IsFree { get; set; }
        public LocalizedText? Category { get; set; } 
        public LocalizedText? Organizer { get; set; }

        public EventContactInfo? ContactInfo { get; set; }
    }
}
