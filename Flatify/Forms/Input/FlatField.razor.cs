using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatField
    {
        protected string Classname => new CssBuilder()
                                      .AddClass("input-wrapper")
                                      .AddClass("floating-label", Floating)
                                      .AddClass("is-textarea", IsArea)
                                      .AddClass(Class)
                                      .Build();
        [Parameter] public bool IsArea { get; set; }
        [Parameter] public bool Floating { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}