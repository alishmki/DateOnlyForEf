using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DateOnlyForEf
{
    public class TimeOnlyConverterJson : JsonConverter<TimeOnly>
    {
        private readonly string _serializationFormat;

        public TimeOnlyConverterJson() : this(null)
        {
        }

        public TimeOnlyConverterJson(string? serializationFormat)
        {
            _serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
        }

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeOnly.ParseExact(value!, _serializationFormat, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(_serializationFormat));
    }
}
