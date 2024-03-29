using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Flatify
{
    /// <summary>
    ///     Base component for buttons.
    /// </summary>
    public abstract class FlatButtonBase : FlatComponentBase
    {
        protected ElementReference _elementReference;

        /// <summary> Child content. </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        ///     The button Type (Button, Submit, Refresh)
        /// </summary>
        [Parameter] public ButtonType ButtonType { get; set; } = ButtonType.Button;

        /// <summary>
        ///     The ElementReference to bind to. Usage: @bind-Ref="myRef"
        /// </summary>
        [Parameter] public ElementReference? Ref { get; set; }

        [Parameter] public EventCallback<ElementReference> RefChanged { get; set; }

        /// <summary> Button click event. </summary>
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary> Button blur event. </summary>
        [Parameter] public EventCallback<FocusEventArgs> OnBlur { get; set; }

        /// <summary>
        ///     If true, the button will be disabled.
        /// </summary>
        [Parameter] public bool Disabled { get; set; } = false;

        /// <summary>
        ///     If true, the click event bubbles up to the containing/parent component.
        /// </summary>
        [Parameter] public bool ClickPropagation { get; set; }

        /// <summary>
        ///     If set to a URL, clicking the button will open the referenced document. Use Target to specify where
        /// </summary>
        [Parameter] public string Link { get; set; }

        /// <summary>
        ///     The target attribute specifies where to open the link, if Link is specified. Possible values: _blank | _self |
        ///     _parent | _top | <i> framename </i>
        /// </summary>
        [Parameter] public string Target { get; set; }

        /// <summary>
        ///     The value of rel attribute for web crawlers. Overrides "noopener" set by <see cref="Target" /> attribute.
        /// </summary>
        [Parameter] public string Rel { get; set; }

        /// <summary>
        ///     The size of this button.
        /// </summary>
        [Parameter] public ElementSize ElementSize { get; set; } = ElementSize.Medium;

        [CascadingParameter(Name = "ParentDisabled")] private bool ParentDisabled { get; set; }

        public string HtmlTag { get; private set; } = "button";

        public ValueTask FocusAsync()
        {
            return _elementReference.FocusAsync();
        }

        protected bool GetDisabledState()
        {
            return Disabled || ParentDisabled;
        }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            SetDefaults();
        }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            //if params change, must set default values again
            SetDefaults();
        }

        protected virtual async Task OnClickHandler(MouseEventArgs ev)
        {
            if (GetDisabledState())
                return;

            await OnClick.InvokeAsync(ev);
        }

        protected virtual async Task OnBlurHandler(FocusEventArgs ev)
        {
            if (GetDisabledState())
                return;

            await OnBlur.InvokeAsync(ev);
        }

        private void SetDefaults()
        {
            if (GetDisabledState())
            {
                HtmlTag = "button";
                Link = null;
                Target = null;
                return;
            }

            // Render an anchor element if Link property is set and is not disabled
            if (!string.IsNullOrWhiteSpace(Link))
                HtmlTag = "a";
        }

        protected string GetRel()
        {
            if (Rel is null && Target == "_blank")
                return "noopener";

            return Rel;
        }
    }
}