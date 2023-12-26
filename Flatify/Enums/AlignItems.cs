// EpochWorlds
// AlignItems.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
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

    /// <summary>
    ///     Flexbox align-items property.
    /// </summary>
    public enum AlignItems
    {
        [Description("baseline")]
        Baseline,

        [Description("center")]
        Center,

        [Description("start")]
        Start,

        [Description("end")]
        End,

        [Description("stretch")]
        Stretch
    }
}