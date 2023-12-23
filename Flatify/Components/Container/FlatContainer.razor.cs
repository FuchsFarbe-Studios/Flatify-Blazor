using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatContainer
    {
        protected string Classname => new CssBuilder($"container-{MaxWidth.ToDescriptionString()}")
                                      .AddClass(Class)
                                      .Build();
        /// <summary>
        ///     Determine the max-width of the container. The container width grows with the size of the screen. Set to false to
        ///     disable maxWidth.
        /// </summary>
        [Parameter] public MaxWidth MaxWidth { get; set; } = MaxWidth.Large;
        /// <summary>
        ///     Child content of component.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}