// EpochWorlds
// ButtonType.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
    /// <summary>
    ///     Describes how a button should behave.
    /// </summary>
    public enum ButtonType
    {
        [Description("button")]
        Button,

        [Description("submit")]
        Submit,

        [Description("reset")]
        Refresh
    }

}