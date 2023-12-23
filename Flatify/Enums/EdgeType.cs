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
        /// <summary>
        ///     Usually does nothing, used for defaulting.
        /// </summary>
        None,

        /// <summary> Creates a sharp edge. </summary>
        [Description("sharp")]
        Sharp,

        /// <summary>
        ///     Slightly rounds the edges of the border.
        /// </summary>
        [Description("round-xs")]
        RoundXs,

        /// <summary>
        ///     Slightly rounds the edges of the border.
        /// </summary>
        [Description("round-sm")]
        RoundSm,

        /// <summary>
        ///     Moderately rounds the edges of the border.
        /// </summary>
        [Description("round-md")]
        RoundMd,

        /// <summary>
        ///     Intensely rounds the edges of the border.
        /// </summary>
        [Description("round-lg")]
        RoundLg,

        /// <summary>
        ///     Creates a triangle edge.
        /// </summary>
        [Description("triangle")]
        Triangle,

        /// <summary>
        ///     Rounds the edges of the border in an oval.
        /// </summary>
        [Description("oval")]
        Oval,

        /// <summary>
        ///     Rounds the edges of the border near-completely.
        /// </summary>
        [Description("circle")]
        Circle
    }
}