using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatAccordion
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        protected string Classname => new CssBuilder("accordion")
                                      .AddClass(Class)
                                      .Build();
    }
}