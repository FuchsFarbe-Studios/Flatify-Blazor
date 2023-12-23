// EpochWorlds
// FlatColor.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{

    public enum FlatColor
    {
        Default,

        [Description("blue")]
        Blue,

        [Description("green")]
        Green,

        [Description("yellow")]
        Yellow,

        [Description("orange")]
        Orange,

        [Description("red")]
        Red,

        [Description("purple")]
        Purple,

        [Description("pink")]
        Pink,

        [Description("accent")]
        Accent,

        [Description("info")]
        Info,

        [Description("success")]
        Success,

        [Description("warning")]
        Warning,

        [Description("error")]
        Error,

        [Description("dark")]
        Dark,

        [Description("transparent")]
        Transparent,

        [Description("inherit")]
        Inherit
    }
}