// EpochWorlds
// InputState.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 23-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum InputState
    {
        [Description("")]
        None,

        [Description("valid")]
        Valid,

        [Description("warning")]
        Warning,

        [Description("error")]
        Error
    }
}