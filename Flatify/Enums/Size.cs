// EpochWorlds
// Size.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum Size
    {
        [Description("size-xs")] ExtraSmall,
        [Description("size-sm")] Small,
        [Description("size-md")] Medium,
        [Description("size-lg")] Large,
        [Description("size-2x")] Huge,
        [Description("size-3x")] Gigantic,
        [Description("size-4x")] Heroic,
        [Description("size-5x")] Titanic
    }
}