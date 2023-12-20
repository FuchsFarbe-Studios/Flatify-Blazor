// EpochWorlds
// Extensions.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;
using System.Globalization;

namespace Flatify.Utilities
{
    public static class Extensions
    {

        public static String ToDescriptionString(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field is null)
            {
                return value.ToString().ToLower();
            }

            var attributes = Attribute.GetCustomAttributes(field, typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            return attributes is { Length: > 0 }
                       ? attributes[0].Description
                       : value.ToString().ToLower();
        }

        #region DateTime Extensions

        public static String ToIsoDateString(this DateTime self)
        {
            return $"{self.Year:D4}-{self.Month:D2}-{self.Day:D2}";
        }

        public static String? ToIsoDateString(this DateTime? self)
        {
            if (self is null)
            {
                return null;
            }

            return $"{self.Value.Year:D4}-{self.Value.Month:D2}-{self.Value.Day:D2}";
        }

        public static DateTime StartOfMonth(this DateTime self, CultureInfo culture)
        {
            var month = culture.Calendar.GetMonth(self);
            var year = culture.Calendar.GetYear(self);

            return culture.Calendar.ToDateTime(year, month, 1, 0, 0, 0, 0);
        }

        public static DateTime EndOfMonth(this DateTime self, CultureInfo culture)
        {
            var month = culture.Calendar.GetMonth(self);
            var year = culture.Calendar.GetYear(self);
            var days = culture.Calendar.GetDaysInMonth(year, month);

            return culture.Calendar.ToDateTime(year, month, days, 0, 0, 0, 0);
        }

        public static DateTime StartOfWeek(this DateTime self, DayOfWeek firstDayOfWeek)
        {
            var diff = (7 + (self.DayOfWeek - firstDayOfWeek)) % 7;
            if (self.Year == 1 && self.Month == 1 && self.Day - diff < 1)
            {
                return self.Date;
            }

            return self.AddDays(-1 * diff).Date;
        }

        #endregion

    }
}