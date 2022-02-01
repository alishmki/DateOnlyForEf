using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DateOnlyForEf
{
    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public TimeOnlyConverter() : base(
                d => d.ToTimeSpan(),
                d => TimeOnly.FromTimeSpan(d))
        { }
    }
}
