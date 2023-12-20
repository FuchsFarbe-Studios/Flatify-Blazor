// EpochWorlds
// TextSize.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum TextSize
    {
        [Description("text-xs")] ExtraSmall,
        [Description("text-sm")] Small,
        [Description("text-md")] Medium,
        [Description("text-lg")] Large,
        [Description("text-2x")] Huge,
        [Description("text-3x")] Gigantic,
        [Description("text-4x")] Heroic,
        [Description("text-5x")] Titanic
    }
}