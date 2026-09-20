using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Domain.Entities
{
    public class ContactMessage
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string PreferredContactMethod { get; set; } = "email";

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
