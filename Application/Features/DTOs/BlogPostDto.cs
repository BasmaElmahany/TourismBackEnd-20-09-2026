using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class BlogPostDto
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("title")] public LocalizedTextDto Title { get; set; } = new();
        [JsonPropertyName("content")] public LocalizedTextDto Content { get; set; } = new();
        [JsonPropertyName("excerpt")] public LocalizedTextDto Excerpt { get; set; } = new();
        [JsonPropertyName("imageUrl")][JsonConverter(typeof(LocalizedTextOrStringConverter))] public object ImageUrl { get; set; } = string.Empty;
        [JsonPropertyName("author")] public LocalizedTextDto Author { get; set; } = new();
        [JsonPropertyName("publishDate")] public DateTime PublishDate { get; set; }
        [JsonPropertyName("category")] public LocalizedTextDto Category { get; set; } = new();
        [JsonPropertyName("tags")] public List<List<object>> Tags { get; set; } = new();
        [JsonPropertyName("readTime")] public int ReadTime { get; set; }
        [JsonPropertyName("featured")] public bool Featured { get; set; }
    }
}
