// EpochWorlds
// Position.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum Position
    {
        [Description("bottom")]
        Bottom,

        [Description("center")]
        Center,

        [Description("top")]
        Top,

        [Description("left")]
        Left,

        [Description("right")]
        Right,

        [Description("start")]
        Start,

        [Description("end")]
        End
    }
}