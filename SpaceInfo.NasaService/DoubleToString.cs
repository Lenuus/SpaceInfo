using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpaceInfo.NasaService
{
   

    namespace SpaceInfo.NasaService.Converters
    {
        public class DoubleToString : JsonConverter<double>
        {
            public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TryGetDouble(out double value))
                {
                    return value;
                }
                else
                {
                    throw new JsonException();
                }
            }

            public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString("F2"));
            }
        }
    }

}
