using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatButtonGroup
    {
        private string Stylename => Style + $" width: {MaxWidth}px;";

        protected virtual string Classname => new CssBuilder()
                                              .AddClass("button-group")
                                              .AddClass("vertical", Vertical)
                                              .AddClass($"width-{Width.ToDescriptionString()}")
                                              .AddClass(Class)
                                              .Build();
        [Parameter] public int MaxWidth { get; set; } = 250;
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public bool Vertical { get; set; }
        [Parameter] public Width Width { get; set; } = Width.Medium;
    }
}