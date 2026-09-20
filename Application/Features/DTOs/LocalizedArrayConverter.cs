using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class LocalizedArrayConverter : JsonConverter<List<object>>
    {
        public override List<object>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray) return null;
            var list = new List<object>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray) break;
                if (reader.TokenType == JsonTokenType.String)
                    list.Add(reader.GetString() ?? string.Empty);
                else if (reader.TokenType == JsonTokenType.StartObject)
                {
                    var item = JsonSerializer.Deserialize<LocalizedTextDto>(ref reader, options);
                    if (item != null) list.Add(item);
                }
            }
            return list;
        }

        public override void Write(Utf8JsonWriter writer, List<object> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var item in value)
            {
                if (item is string s) writer.WriteStringValue(s);
                else if (item is LocalizedTextDto localized) JsonSerializer.Serialize(writer, localized, options);
                else JsonSerializer.Serialize(writer, item, options);
            }
            writer.WriteEndArray();
        }
    }
}
