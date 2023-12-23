// EpochWorlds
// AlignItems.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
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