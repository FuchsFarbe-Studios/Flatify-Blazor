using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Flatify
{
    /// <summary>
    /// Base component for buttons.
    /// </summary>
    public abstract class FlatButtonBase : FlatComponentBase
    {
        protected ElementReference _elementReference;

        /// <summary>
        ///     The button Type (Button, Submit, Refresh)
        /// </summary>
        [Parameter] public ButtonType ButtonType { get; set; }

        /// <summary> Button click event. </summary>
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        ///     If true, the button will be disabled.
        /// </summary>
        [Parameter] public Boolean Disabled { get; set; }

        /// <summary>
        ///     If set to a URL, clicking the button will open the referenced document. Use Target to specify where
        /// </summary>
        [Parameter] public String Link { get; set; }

        /// <summary>
        ///     The target attribute specifies where to open the link, if Link is specified. Possible values: _blank | _self |
        ///     _parent | _top | <i> framename </i>
        /// </summary>
        [Parameter] public String Target { get; set; }

        /// <summary>
        ///     The value of rel attribute for web crawlers. Overrides "noopener" set by <see cref="Target" /> attribute.
        /// </summary>
        [Parameter] public String Rel { get; set; }

        [CascadingParameter(Name = "ParentDisabled")] private Boolean ParentDisabled { get; set; }

        public String HtmlTag { get; private set; }

        public ValueTask FocusAsync()
        {
            return _elementReference.FocusAsync();
        }

        protected Boolean GetDisabledState()
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

        protected String GetRel()
        {
            if (Rel is null && Target == "_blank")
                return "noopener";

            return Rel;
        }
    }
}