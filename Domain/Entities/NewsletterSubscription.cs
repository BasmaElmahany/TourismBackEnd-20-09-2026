
using System.ComponentModel.DataAnnotations;


namespace Tourism.Domain.Entities
{
    public class NewsletterSubscription
    {
        [Key]
        public string Email { get; set; } = string.Empty;
        public List<string> Preferences { get; set; } = new();
        public DateTime SubscribeDate { get; set; } = DateTime.UtcNow;
    }
}
