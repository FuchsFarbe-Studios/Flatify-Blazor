// EpochWorlds
// MaxWidth.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum MaxWidth
    {
        [Description("lg")]
        Large,

        [Description("md")]
        Medium,

        [Description("sm")]
        Small,

        [Description("xl")]
        ExtraLarge,

        [Description("xxl")]
        ExtraExtraLarge,

        [Description("xs")]
        ExtraSmall,

        [Description("false")]
        False
    }
}