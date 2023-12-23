// EpochWorlds
// Converters.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.Globalization;

namespace Flatify.Utilities
{
    public static class Converters
    {
        public static CultureInfo DefaultCulture = CultureInfo.CurrentUICulture;

        #region Date converters

        public static Converter<DateTime> IsoDate => new Converter<DateTime>
                                                     { SetFunc = SetIsoDate, GetFunc = GetIsoDate };

        public static Converter<DateTime?> NullableIsoDate => new Converter<DateTime?>
                                                              { SetFunc = SetNullableIsoDate, GetFunc = GetNullableIsoDate };

        private static string SetIsoDate(DateTime value)
        {
            return value.ToIsoDateString();
        }

        private static string SetNullableIsoDate(DateTime? value)
        {
            return value.ToIsoDateString();
        }

        private static DateTime GetIsoDate(string value)
        {
            if (DateTime.TryParse(value, out var dateTime))
                return dateTime;

            return DateTime.MinValue;
        }

        private static DateTime? GetNullableIsoDate(string value)
        {
            if (DateTime.TryParse(value, out var dateTime))
                return dateTime;

            return null;
        }

        // public static DateConverter DateFormat(string format)
        // {
        //     format ??= "yyyy-MM-dd";
        //     return new DateConverter(format);
        // }
        //
        // public static DateConverter DateFormat(string format, CultureInfo culture)
        // {
        //     return new DateConverter(format) { Culture = culture };
        // }

        #endregion

    }
}