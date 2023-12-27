using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatField
    {
        protected string containerClassname => new CssBuilder()
                                               .AddClass("input-wrapper")
                                               .Build();
        [Parameter] public RenderFragment LabelFragment { get; set; }
        [Parameter] public RenderFragment InputFragment { get; set; }
        [Parameter] public RenderFragment HelpFragment { get; set; }
        [Parameter] public RenderFragment ValidationFragment { get; set; }
    }
}