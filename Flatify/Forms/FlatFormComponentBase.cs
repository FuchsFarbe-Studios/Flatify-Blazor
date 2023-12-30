using Flatify.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;

namespace Flatify.Forms
{
    public class FlatFormComponentBase<TValue> : InputBase<TValue>, IFlatStateHasChanged
    {
        private bool _disabled;
        protected string floatingPlaceholder => Floating
                                                    ? Placeholder ?? Label
                                                    : Placeholder;

        protected virtual string ContainerClassname => new CssBuilder()
                                                       .AddClass("input-wrapper")
                                                       .AddClass("floating-label")
                                                       .AddClass($"{Size.ToDescriptionString()}")
                                                       .Build();
        protected virtual string InputClassname => new CssBuilder()
                                                   .AddClass($"style-{Color.ToDescriptionString()}", Color != FlatColor.Default && Color != FlatColor.Transparent && Color != FlatColor.Inherit)
                                                   //.AddClass("disabled", Disabled)
                                                   .Build();
        protected virtual string LabelClassname => new CssBuilder()
                                                   .AddClass("form-label")
                                                   .AddClass($"color-{Color.ToDescriptionString()}", Color != FlatColor.Default && Color != FlatColor.Transparent && Color != FlatColor.Inherit)
                                                   .Build();
        protected virtual string FieldClass => EditContext.FieldCssClass(FieldIdentifier);

        [Parameter] public EventCallback<FocusEventArgs> OnBlur { get; set; }

        /// <summary>
        ///     Gets or sets the label of the input.
        /// </summary>
        [Parameter] public string Label { get; set; }

        /// <summary>
        ///     Appears below form controls as a useful guide.
        /// </summary>
        [Parameter] public string HelpText { get; set; }

        /// <summary>
        ///     Provides placeholder text for certain inputs.
        /// </summary>
        [Parameter] public string Placeholder { get; set; }

        /// <summary>
        ///     Gets or sets the required attribute of the input.
        /// </summary>
        [Parameter] public bool Required { get; set; }

        /// <summary>
        ///     Determines if this input is disabled.
        /// </summary>
        [Parameter] public bool Disabled
        {
            get => _disabled;
            set
            {
                if (_disabled != value)
                {
                    _disabled = value;
                    StateHasChanged();
                }
            }
        }

        /// <summary>
        ///     Floating inputs float labels above the input.
        /// </summary>
        [Parameter] public bool Floating { get; set; }

        /// <summary>
        ///     Determines if the input is inline with its label.
        /// </summary>
        [Parameter] public bool Inline { get; set; } = true;

        /// <summary>
        ///     Color styling of this input component.
        /// </summary>
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Default;

        /// <summary>
        ///     Type of input to display on the screen.
        /// </summary>
        [Parameter] public InputType InputType { get; set; } = InputType.Text;

        /// <summary>
        ///     The size of the input element.
        /// </summary>
        [Parameter] public ElementSize Size { get; set; } = ElementSize.Medium;

        /// <inheritdoc />
        public virtual void FlatStateHasChanged()
        {
            StateHasChanged();
        }

        /// <summary>
        ///     Gets the input type based on the the value type.
        /// </summary>
        /// <param name="value"> Value of the type. </param>
        /// <typeparam name="TValue">
        ///     The type to query against.
        /// </typeparam>
        /// <returns>
        ///     <see cref="InputType" />
        /// </returns>
        protected virtual InputType GetInputType<TValue>(TValue value)
        {
            switch (value)
            {
                case int or float or double or decimal:
                    return InputType.Number;
                case bool b:
                    return InputType.Checkbox;
                case string s:
                    return InputType.Text;
                case char c:
                    return InputType.Text;
                case DateTime d:
                    return InputType.Date;
                case DateOnly dt:
                    return InputType.Date;
                case TimeSpan ts:
                    return InputType.Time;
                case DateTimeOffset dto:
                    return InputType.DateTimeLocal;
                case Color color:
                    return InputType.Color;
                case object o:
                    return InputType.Text;
                default:
                    return InputType.Text;
            }
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, [UnscopedRef] out TValue result, [UnscopedRef] out string validationErrorMessage)
        {
            result = BindConverter.TryConvertTo(value, CultureInfo.CurrentCulture, out TValue parsedValue)
                         ? parsedValue
                         : default;
            validationErrorMessage = "Could not parse the given value.";
            return true;
        }
    }
}