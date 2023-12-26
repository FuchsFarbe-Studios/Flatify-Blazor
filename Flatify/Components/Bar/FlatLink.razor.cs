using Flatify.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Logging;

namespace Flatify
{
    /// <summary>
    ///     Creates a navigation link that is styled as a flat button.
    /// </summary>
    public partial class FlatLink : IDisposable
    {
        public string Classname => new CssBuilder()
                                   .AddClass("menu-item", MenuItem)
                                   .AddClass("flex-center-x", !MenuItem)
                                   .AddClass("active", IsActive)
                                   .AddClass(Class)
                                   .Build();

        [Inject] public NavigationManager Nav { get; set; }

        private bool IsActive => IsActiveUri();
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

        /// <inheritdoc />
        public void Dispose()
        {
            Nav.LocationChanged -= ChangeState;
        }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            Nav.LocationChanged += ChangeState;
        }

        private void ChangeState(object sender, LocationChangedEventArgs e)
        {
            StateHasChanged();
        }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            UserAttributes.Add("class", "menu-item");
            UserAttributes.Add("href", Link);
            await base.OnInitializedAsync();
        }

        // Test relative uri for active state
        public bool IsActiveUri()
        {
            var relUri = Nav.Uri.Replace(Nav.BaseUri, "/");
            Logger.LogInformation("Relative URI: {0}", relUri);
            return relUri.StartsWith(Link);
        }
    }
}