using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Domain.Entities
{
    public class BookingRequest
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; } = string.Empty;
        public string ItemId { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Guests { get; set; }
        public string? SpecialRequests { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
