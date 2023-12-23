using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatNavBar
    {
        protected string Classname => new CssBuilder()
                                      .AddClass("menu-items-wrapper")
                                      .AddClass("navbar")
                                      .AddClass(Size.ToDescriptionString(), Size != Size.Medium)
                                      .AddClass($"style-{Color.ToDescriptionString()}")
                                      .AddClass(Class)
                                      .Build();

        /// <summary>
        ///     Whether to use branding for the navigation bar.
        /// </summary>
        [Parameter] public bool UseBranding { get; set; } = false;

        /// <summary>
        ///     Image source for your logo.
        /// </summary>
        [Parameter] public string Logo { get; set; }

        /// <summary>
        ///     The link the logo links back to.
        /// </summary>
        [Parameter] public string BrandLink { get; set; } = "#";

        /// <summary>
        ///     The name of your brand.
        /// </summary>
        [Parameter] public string BrandName { get; set; } = "#";

        /// <summary>
        ///     Color for the navigation bar.
        /// </summary>
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Accent;

        /// <summary>
        ///     Size for the navigation bar.
        /// </summary>
        [Parameter] public Size Size { get; set; } = Size.Medium;


        /// <summary>
        ///     Logo content for the navigation bar.
        /// </summary>
        [Parameter] public RenderFragment LogoContent { get; set; }

        /// <summary>
        ///     Left navigation content for the navigation bar.
        /// </summary>
        [Parameter] public RenderFragment LeftBar { get; set; }

        /// <summary>
        ///     Right navigation content for the navigation bar.
        /// </summary>
        [Parameter] public RenderFragment RightBar { get; set; }
    }
}