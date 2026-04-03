using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utils
{
    public class StringToDecimalConverter : JsonConverter<decimal?>
    {
        public override decimal? ReadJson(JsonReader reader, Type objectType, decimal? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            if (reader.TokenType == JsonToken.String)
                return decimal.TryParse(reader.Value?.ToString(), System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out decimal result) ? result : null;

            return Convert.ToDecimal(reader.Value);
        }

        public override void WriteJson(JsonWriter writer, decimal? value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
