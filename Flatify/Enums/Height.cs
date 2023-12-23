// EpochWorlds
// Height.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 23-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum Height
    {
        [Description("10p")]
        ExtraSmall,

        [Description("25p")]
        Small,

        [Description("50p")]
        Medium,

        [Description("75p")]
        Large,

        [Description("100p")]
        ExtraLarge
    }
}