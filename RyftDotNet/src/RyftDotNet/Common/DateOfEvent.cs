using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Common
{
    [JsonConverter(typeof(DateOfEventJsonConverter))]
    public sealed class DateOfEvent : IEquatable<DateOfEvent>
    {
        public int Year { get; }

        public int Month { get; }

        public int Day { get; }

        public DateOfEvent(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public bool Equals(DateOfEvent? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Year == other.Year
                   && Month == other.Month
                   && Day == other.Day);

        public override bool Equals(object? obj)
            => obj is DateOfEvent other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Year, Month, Day).GetHashCode();
    }
}
