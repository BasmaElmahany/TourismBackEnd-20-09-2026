using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Domain.Entities
{
    public class VisitorInfo
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Category { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int Priority { get; set; }
    }
}
