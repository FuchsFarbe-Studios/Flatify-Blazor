using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatTypo
    {
        protected string Classname => new CssBuilder()
                                      .AddClass($"color-{Color.ToDescriptionString()}", Color != FlatColor.Inherit && Color != FlatColor.Default && Color != FlatColor.Transparent)
                                      .AddClass(Size.ToDescriptionString(), Size != TextSize.Medium)
                                      .AddClass("inline", Inline)
                                      .Build();
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary> The text to display. </summary>
        [Parameter] public string Text { get; set; }

        /// <summary> The typo to use. </summary>
        [Parameter] public Typo Typo { get; set; } = Typo.Body1;

        /// <summary>
        ///     Color/styling to apply to the typo.
        /// </summary>
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Inherit;

        /// <summary> Size of the element. </summary>
        [Parameter] public TextSize Size { get; set; } = TextSize.Medium;

        /// <summary>
        ///     If this typo is inline, it will not create a new paragraph when used as a child of another element.
        /// </summary>
        [Parameter] public bool Inline { get; set; } = false;
    }
}