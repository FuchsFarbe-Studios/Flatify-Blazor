using Flatify.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;

namespace Flatify.Components.Forms
{
    public class FlatFormComponentBase<TValue> : InputBase<TValue>
    {
        protected virtual string InputClassname => new CssBuilder()
                                                   .AddClass(FieldClass, !string.IsNullOrEmpty(FieldClass))
                                                   //.AddClass(CssClass)
                                                   .Build();
        protected virtual string LabelClassname => new CssBuilder()
                                                   .AddClass("form-label")
                                                   .AddClass("inline", Inline)
                                                   .Build();
        protected virtual string FieldClass => EditContext.FieldCssClass(FieldIdentifier);

        [Parameter] public string Label { get; set; }
        [Parameter] public string Placeholder { get; set; }
        [Parameter] public bool Required { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public bool Inline { get; set; }
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Accent;
        [Parameter] public InputType InputType { get; set; } = InputType.Text;

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
                    return InputType.Date;
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