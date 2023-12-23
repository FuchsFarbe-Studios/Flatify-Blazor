using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Flatify
{
    public class FlatElement : FlatComponentBase
    {
        /// <summary> Child content </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        ///     The HTML element that will be rendered in the root by the component
        /// </summary>
        [Parameter] public String HtmlTag { get; set; } = "span";

        /// <summary>
        ///     The ElementReference to bind to. Usage: @bind-Ref="myRef"
        /// </summary>
        [Parameter] public ElementReference? Ref { get; set; }

        [Parameter] public EventCallback<ElementReference> RefChanged { get; set; }

        [Parameter] public Boolean ClickPropagation { get; set; } = false;

        /// <summary>
        ///     Calling StateHasChanged to refresh the component's state
        /// </summary>
        public void Refresh()
        {
            StateHasChanged();
        }

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            //Open
            builder.OpenElement(0, HtmlTag);

            //splatted attributes
            foreach (var attribute in UserAttributes)
            {
                // checking if the value is null, we can get rid of null event handlers
                // for example `@onmouseenter=@(IsOpen ? HandleEnter : null)`
                // this is a powerful feature that in normal HTML elements doesn't work, because
                // Blazor adds always the attribute value and creates an EventCallback
                if (attribute.Value != null)
                    builder.AddAttribute(1, attribute.Key, attribute.Value);
            }
            //Class
            builder.AddAttribute(2, "class", Class);
            //Style
            builder.AddAttribute(3, "style", Style);

            // StopPropagation
            // the order matters. This has to be before content is added
            if (HtmlTag == "button" && ClickPropagation == false)
                builder.AddEventStopPropagationAttribute(5, "onclick", true);

            //Reference capture
            if (Ref != null)
            {
                builder.AddElementReferenceCapture(6, elementReferenceCaptureAction: async capturedRef =>
                {
                    Ref = capturedRef;
                    await RefChanged.InvokeAsync(Ref.Value);
                });
            }

            //Content
            builder.AddContent(10, ChildContent);

            //Close
            builder.CloseElement();
        }
    }
}