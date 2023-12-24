using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatTypo
    {
        protected string Classname => new CssBuilder()
                                      .AddClass($"style-{Color.ToDescriptionString()}", Color != FlatColor.Inherit && Color != FlatColor.Default && Color != FlatColor.Transparent)
                                      .AddClass(Size.ToDescriptionString(), Size != TextSize.Medium)
                                      .AddClass("inline", Inline)
                                      .Build();
        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public string Text { get; set; }
        [Parameter] public Typo Typo { get; set; } = Typo.Body1;
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Inherit;
        [Parameter] public TextSize Size { get; set; } = TextSize.Medium;
        [Parameter] public bool Inline { get; set; } = false;
    }
}