// EpochWorlds
// YesNoType.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 23-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum YesNoType
    {
        [Description("select")]
        SelectList,

        [Description("checkbox")]
        Checkbox,

        [Description("radio")]
        Radio,

        [Description("toggle")]
        Switch
    }
}