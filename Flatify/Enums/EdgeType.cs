// EpochWorlds
// EdgeType.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 23-12-2023
using System.ComponentModel;

namespace Flatify
{
    /// <summary>
    ///     Used to determine the roundness of border edges.
    /// </summary>
    public enum EdgeType
    {
        /// <summary> Creates a sharp edge. </summary>
        [Description("sharp")]
        Sharp,

        /// <summary>
        ///     Slightly rounds the edges of the border.
        /// </summary>
        [Description("round-sm")]
        Round,

        /// <summary>
        ///     Rounds the edges of the border near-completely.
        /// </summary>
        [Description("circle")]
        Circle
    }
}