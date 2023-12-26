using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatField
    {
        protected string Classname => new CssBuilder()
                                      .AddClass("input-wrapper")
                                      .AddClass("floating-label", Floating)
                                      .AddClass("is-textarea", IsArea)
                                      .AddClass($"width-{Width.ToDescriptionString()}")
                                      .AddClass(Class)
                                      .Build();
        [Parameter] public Width Width { get; set; } = Width.Medium;
        [Parameter] public bool IsArea { get; set; }
        [Parameter] public bool Floating { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}