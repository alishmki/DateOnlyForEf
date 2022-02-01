using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DateOnlyForEf
{
    public class DateOnlyConverterJson : JsonConverter<DateOnly>
    {
        private readonly string _serializationFormat;

        public DateOnlyConverterJson() : this(null)
        { }

        public DateOnlyConverterJson(string? serializationFormat)
        {
            _serializationFormat = serializationFormat ?? "yyyy-MM-dd";
        }

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.ParseExact(value!, _serializationFormat, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(_serializationFormat));
    }
}
