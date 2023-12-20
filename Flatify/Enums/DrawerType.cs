// EpochWorlds
// DrawerType.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum DrawerType
    {
        [Description("temporary")]
        Temporary,

        [Description("responsive")]
        Responsive,

        [Description("persistent")]
        Persistent,

        [Description("mini")]
        Mini
    }
}