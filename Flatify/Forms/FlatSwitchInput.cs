using Flatify.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Flatify.Forms
{
    public class FlatSwitchInput : FlatBoolInputBase
    {
        public ElementReference? Element { get; protected set; }
        /// <inheritdoc />
        protected override string LabelClassname => new CssBuilder()
                                                    .AddClass("toggle-wrapper")
                                                    .Build();
        [Parameter] public LabelDirection Direction { get; set; } = LabelDirection.Left;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var i = 0;
            // Div element
            builder.OpenElement(i, "div");
            builder.AddAttribute(i++, "class", ContainerClassname);

            // Label element
            builder.OpenElement(i++, "label");
            builder.AddAttribute(i++, "class", LabelClassname);
            if (string.IsNullOrEmpty(FieldIdentifier.FieldName))
                builder.AddAttribute(i++, "for", FieldIdentifier.FieldName);
            builder.AddContent(i++, Label);

            // Input element
            builder.OpenElement(i++, "input");
            builder.AddMultipleAttributes(i++, AdditionalAttributes);
            builder.AddAttribute(i++, "type", "checkbox");
            builder.AddAttribute(i++, "role", "switch");
            if (string.IsNullOrEmpty(FieldIdentifier.FieldName))
            {
                builder.AddAttribute(i++, "name", FieldIdentifier.FieldName);
                builder.AddAttribute(i++, "id", FieldIdentifier.FieldName);
            }
            builder.AddAttribute(i++, "checked", BindConverter.FormatValue(CurrentValue));

            // Include the "value" attribute so that when this is posted by a form, "true"
            // is included in the form fields. That's how <input type="checkbox"> works normally.
            // It sends the "on" value when the checkbox is checked, and nothing otherwise.
            builder.AddAttribute(i++, "value", bool.TrueString);
            builder.AddAttribute(i++, "placeholder", floatingPlaceholder);
            if (Disabled)
                builder.AddAttribute(i++, "disabled");
            builder.AddAttribute(i++, "onchange", EventCallback.Factory.CreateBinder<bool>(this, setter: __value => CurrentValue = __value, CurrentValue));
            builder.SetUpdatesAttributeName("checked");
            builder.AddElementReferenceCapture(i++, elementReferenceCaptureAction: __inputReference => Element = __inputReference);
            // Close input
            builder.CloseElement();
            // Span element
            builder.OpenElement(i++, "span");
            builder.AddAttribute(i++, "class", "check");
            // Close span
            builder.CloseElement();
            // Close label
            builder.CloseElement();
            // Close div
            builder.CloseElement();
        }
    }
}