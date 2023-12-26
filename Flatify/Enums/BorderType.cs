// EpochWorlds
// BorderType.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 23-12-2023
using System.ComponentModel;

namespace Flatify
{
    /// <summary>
    ///     Border type for components.
    /// </summary>
    public enum BorderType
    {
        None,

        [Description("bordered")]
        Bordered,

        [Description("outline")]
        Outlined
    }
}