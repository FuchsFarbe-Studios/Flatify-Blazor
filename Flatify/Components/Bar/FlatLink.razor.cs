using Flatify.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Flatify
{
    public partial class FlatLink
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        ///     Href link for the navigation bar.
        /// </summary>
        [Parameter] public string Link { get; set; } = "/";

        [Parameter] public string Target { get; set; } = "_self";

        /// <summary>
        ///     How routing is matched for setting the active class.
        /// </summary>
        [Parameter] public NavLinkMatch MatchMode { get; set; } = NavLinkMatch.All;

        public string Classname => new CssBuilder()
                                   .AddClass("menu-item")
                                   .Build();
    }
}