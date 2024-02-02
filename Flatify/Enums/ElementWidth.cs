// EpochWorlds
// Width.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum ElementWidth
    {
        [Description("")]
        Default,

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