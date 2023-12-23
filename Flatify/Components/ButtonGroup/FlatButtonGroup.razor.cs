using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatButtonGroup
    {
        protected virtual string Classname => new CssBuilder()
                                              .AddClass("button-group")
                                              .AddClass("vertical", Vertical)
                                              .AddClass($"width-{Width.ToDescriptionString()}")
                                              .AddClass(Class)
                                              .Build();
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public bool Vertical { get; set; }
        [Parameter] public Width Width { get; set; } = Width.Medium;
    }
}