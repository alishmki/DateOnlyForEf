using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DateOnlyForEf
{
    public class NullableTimeOnlyConverter : ValueConverter<TimeOnly?, TimeSpan?>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public NullableTimeOnlyConverter() : base(
            d => d == null
                ? null
                : new TimeSpan?(d.Value.ToTimeSpan()),
            d => d == null
                ? null
                : new TimeOnly?(TimeOnly.FromTimeSpan(d.Value)))
        { }
    }
}
