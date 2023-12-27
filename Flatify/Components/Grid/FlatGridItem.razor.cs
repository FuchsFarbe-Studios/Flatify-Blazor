using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatGridItem
    {
        protected string Classname => new CssBuilder()
                                      .AddClass($"{Span.ToDescriptionString()}")
                                      .AddClass(Class)
                                      .Build();
        [CascadingParameter] private FlatGrid Grid { get; set; }
        [Parameter] public GridCols Span { get; set; } = GridCols.Default;
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}