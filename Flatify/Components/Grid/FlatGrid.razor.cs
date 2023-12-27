using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatGrid
    {
        protected string Classname => new CssBuilder()
                                      .AddClass("container-fluid")
                                      .AddClass("text-center")
                                      .AddClass(Class)
                                      .Build();
        protected string RowClassname => new CssBuilder()
                                         .AddClass("row")
                                         .AddClass($"{Cols.ToDescriptionString()}")
                                         .Build();

        [Parameter] public RowCols Cols { get; set; } = RowCols.Cols3;
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}