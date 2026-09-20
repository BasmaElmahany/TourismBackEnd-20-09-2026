using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class LocalizedTextOrStringConverter : JsonConverter<object>
    {
        public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String) return reader.GetString();
            if (reader.TokenType == JsonTokenType.StartObject)
                return JsonSerializer.Deserialize<LocalizedTextDto>(ref reader, options);
            return null;
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value is string str) writer.WriteStringValue(str);
            else if (value is LocalizedTextDto localized) JsonSerializer.Serialize(writer, localized, options);
            else JsonSerializer.Serialize(writer, value, options);
        }
    }
}
