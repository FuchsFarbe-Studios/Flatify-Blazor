using Flatify.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Flatify
{
    /// <summary>
    ///     Creates a navigation link that is styled as a flat button.
    /// </summary>
    public partial class FlatLink
    {
        public string Classname => new CssBuilder()
                                   .AddClass("menu-item")
                                   .AddClass("flex-center-x", !MenuItem)
                                   .AddClass(Class)
                                   .Build();

        /// <summary>
        ///     The child content of the navigation bar.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        ///     Href link for the navigation bar.
        /// </summary>
        [Parameter] public string Link { get; set; } = "/";

        /// <summary> The link target. </summary>

        [Parameter] public string Target { get; set; } = "_self";

        /// <summary>
        ///     Should be set to true when the link is a menu or navigation bar.
        /// </summary>
        [Parameter] public bool MenuItem { get; set; } = true;

        /// <summary>
        /// How routing is matched for setting the active class.
        /// </summary>
        [Parameter] public NavLinkMatch MatchMode { get; set; } = NavLinkMatch.All;
    }
}