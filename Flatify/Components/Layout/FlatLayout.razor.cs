using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    /// <summary>
    ///     A layout component for a flat design website.
    /// </summary>
    public partial class FlatLayout
    {
        protected string MainClassname => new CssBuilder()
                                          .AddClass($"container-{MaxWidth.ToDescriptionString()}")
                                          .AddClass($"style-{Color.ToDescriptionString()}-light", Color != FlatColor.Inherit && Color != FlatColor.Default && Color != FlatColor.Transparent)
                                          .Build();
        /// <summary>
        ///     Use to display the main site content.
        /// </summary>
        [Parameter] public RenderFragment MainContent { get; set; }

        /// <summary>
        ///     The header usually contains a navigation bar.
        /// </summary>
        [Parameter] public RenderFragment LayoutHeader { get; set; }

        /// <summary>
        ///     The footer of the website.
        /// </summary>
        [Parameter] public RenderFragment LayoutFooter { get; set; }

        /// <summary>
        ///     If the site is using a navigational sidebar.
        /// </summary>
        [Parameter] public RenderFragment LayoutSidebar { get; set; }

        /// <summary>
        ///     Maximum main content width.
        /// </summary>
        [Parameter] public MaxWidth MaxWidth { get; set; } = MaxWidth.Large;

        /// <summary>
        ///     The container style and coloring.
        /// </summary>
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Inherit;
    }
}