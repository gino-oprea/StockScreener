using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utils
{
    public class StringToIntConverter : JsonConverter<int?>
    {
        public override int? ReadJson(JsonReader reader, Type objectType, int? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            if (reader.TokenType == JsonToken.String)
            {
                if (decimal.TryParse(reader.Value?.ToString(), System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out decimal parsed))
                    return (int)parsed;
                return null;
            }

            return Convert.ToInt32(reader.Value);
        }

        public override void WriteJson(JsonWriter writer, int? value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
