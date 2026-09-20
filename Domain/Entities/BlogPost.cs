using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Domain.Entities.Common;

namespace Tourism.Domain.Entities
{
    public class BlogPost
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public LocalizedText Title { get; set; } = new();
        public LocalizedText Content { get; set; } = new();
        public LocalizedText Excerpt { get; set; } = new();
        public string ImageUrl { get; set; } = string.Empty;
        public LocalizedText Author { get; set; } = new();
        public DateTime PublishDate { get; set; }
        public LocalizedText Category { get; set; } = new();
        public List<List<object>> Tags { get; set; } = new();
        public int ReadTime { get; set; }
        public bool Featured { get; set; }
    }
}
