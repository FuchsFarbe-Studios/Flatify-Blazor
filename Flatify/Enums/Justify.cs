// EpochWorlds
// Justify.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum Justify
    {
        [Description("start")]
        FlexStart,

        [Description("center")]
        Center,

        [Description("end")]
        FlexEnd,

        [Description("space-between")]
        SpaceBetween,

        [Description("space-around")]
        SpaceAround,

        [Description("space-evenly")]
        SpaceEvenly
    }
}