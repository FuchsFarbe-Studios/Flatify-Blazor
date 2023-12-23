// EpochWorlds
// BreakType.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 23-12-2023
using System.ComponentModel;

namespace Flatify
{
    /// <summary>
    ///     The type of horizontal line break to display.
    /// </summary>
    public enum BreakType
    {
        [Description("")]
        Default,

        [Description("short")]
        Short,

        [Description("dots")]
        Large
    }
}