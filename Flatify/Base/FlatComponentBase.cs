// Flatify
// FlatBase.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 19-12-2023
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Flatify
{
    /// <summary>
    ///     FlatifyCSS base component.
    /// </summary>
    public abstract class FlatComponentBase : ComponentBase, IFlatStateHasChanged
    {
        private ILogger _logger;
        [Inject] private ILoggerFactory LoggerFactory { get; set; } = null!;
        protected ILogger Logger => _logger ??= LoggerFactory.CreateLogger(GetType());

        /// <summary>
        ///     Custom classes to be applied to the component. Separated by a space.
        /// </summary>
        [Parameter] public string Class { get; set; }

        /// <summary>
        ///     User styles, applied on top of the component's own classes and styles.
        /// </summary>
        [Parameter]
        public string Style { get; set; }

        /// <summary>
        ///     Use Tag to attach any user data object to the component for your convenience.
        /// </summary>
        [Parameter]
        public object Tag { get; set; }

        /// <summary>
        ///     UserAttributes carries all attributes you add to the component that don't match any of its parameters. They will be
        ///     splatted onto the underlying HTML tag.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> UserAttributes { get; set; } = new Dictionary<string, object>();

        /// <inheritdoc />
        public void FlatStateHasChanged()
        {
            StateHasChanged();
        }
    }

}