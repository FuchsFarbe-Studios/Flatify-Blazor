// EpochWorlds
// Variant.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
    /// <summary>
    ///     Button and other container appearance modifiers.
    /// </summary>
    public enum Variant
    {
        [Description("")] Default,

        /// <summary>
        ///     Will appear like a link or text-button.
        /// </summary>
        [Description("link-button")] Text,

        /// <summary>
        ///     Creates a filled button based on accent color.
        /// </summary>
        [Description("bordered")] Border,

        /// <summary>
        ///     Generates a lightly outlined container or button.
        /// </summary>
        [Description("outlined")] Outline
    }
}