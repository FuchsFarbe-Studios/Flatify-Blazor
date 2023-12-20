// EpochWorlds
// Extensions.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

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
    }
}