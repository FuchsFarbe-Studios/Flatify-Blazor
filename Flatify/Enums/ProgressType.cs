// EpochWorlds
// ProgressType.cs
// FuchsFarbe Studios 2024
// matsu
// Modified: 2-2-2024
using System.ComponentModel;

namespace Flatify
{
    /// <summary>
    ///     Used in determining the display for progression on the web application.
    /// </summary>
    public enum ProgressType
    {
        [Description("loading")]
        Default,

        [Description("loading")]
        Dots,

        [Description("spinner")]
        Spinner,

        [Description("progress-bar")]
        Bar
    }
}