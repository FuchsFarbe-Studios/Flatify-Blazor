// EpochWorlds
// DrawerType.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{

    /// <summary>
    ///     Describes the desired functionality for a drawer component.
    /// </summary>
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