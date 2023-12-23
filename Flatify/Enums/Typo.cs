// EpochWorlds
// Typo.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.ComponentModel;

namespace Flatify
{
    public enum Typo
    {
        [Description("inherit")]
        Default,

        [Description("h1")]
        Heading1,

        [Description("h2")]
        Heading2,

        [Description("h3")]
        Heading3,

        [Description("h4")]
        Heading4,

        [Description("h5")]
        Heading5,

        [Description("h6")]
        Heading6,

        [Description("subtitle1")]
        Subtitle1,

        [Description("subtitle2")]
        Subtitle2,

        [Description("body1")]
        Body1,

        [Description("body2")]
        Body2,

        [Description("button")]
        Button,

        [Description("caption")]
        Caption,

        [Description("overline")]
        Overline
    }
}