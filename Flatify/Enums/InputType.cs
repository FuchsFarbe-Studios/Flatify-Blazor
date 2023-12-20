// EpochWorlds
// InputType.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum InputType
    {
        [Description("text")]
        Text,

        [Description("password")]
        Password,

        [Description("email")]
        Email,

        [Description("hidden")]
        Hidden,

        [Description("number")]
        Number,

        [Description("search")]
        Search,

        [Description("tel")]
        Telephone,

        [Description("url")]
        Url,

        [Description("color")]
        Color,

        [Description("date")]
        Date,

        [Description("datetime-local")]
        DateTimeLocal,

        [Description("month")]
        Month,

        [Description("time")]
        Time,

        [Description("week")]
        Week


    }
}