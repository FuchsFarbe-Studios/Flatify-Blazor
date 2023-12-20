// EpochWorlds
// Variant.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum Variant
    {
        [Description("text")]
        Text,

        [Description("filled")]
        Filled,

        [Description("outlined")]
        Outlined
    }
}