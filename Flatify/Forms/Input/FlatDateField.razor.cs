using Flatify.Utilities;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Flatify.Forms
{
    public partial class FlatDateField<TDateTime>
    {
        private const string DateFormat = "yyyy-MM-dd";// Compatible with HTML 'date' inputs
        private const string DateTimeLocalFormat = "yyyy-MM-ddTHH:mm:ss";// Compatible with HTML 'datetime-local' inputs
        private const string MonthFormat = "yyyy-MM";// Compatible with HTML 'month' inputs
        private const string TimeFormat = "HH:mm:ss";

        protected string LabelClassname => new CssBuilder()
                                           .AddClass("form-label")
                                           .AddClass($"style-{Color.ToDescriptionString()}", Color == FlatColor.Default && Color != FlatColor.Inherit && Color != FlatColor.Transparent)
                                           .AddClass($"width-{Width.ToDescriptionString()}")
                                           .Build();

        [Parameter] public bool Floating { get; set; } = false;
        [Parameter] public Width Width { get; set; } = Width.Medium;

        /// <inheritdoc />
        protected override string FormatValueAsString(TDateTime value)
        {
            return value switch
            {
                DateTime dateTimeValue => BindConverter.FormatValue(dateTimeValue, DateTimeLocalFormat, CultureInfo.InvariantCulture),
                DateTimeOffset dateTimeOffsetValue => BindConverter.FormatValue(dateTimeOffsetValue, DateTimeLocalFormat, CultureInfo.InvariantCulture),
                DateOnly dateOnlyValue => BindConverter.FormatValue(dateOnlyValue, DateFormat, CultureInfo.InvariantCulture),
                TimeOnly timeOnlyValue => BindConverter.FormatValue(timeOnlyValue, TimeFormat, CultureInfo.InvariantCulture),
                _ => string.Empty// Handles null for Nullable<DateTime>, etc.
            };
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out TDateTime result, out string validationErrorMessage)
        {
            var _parsingErrorMessage = "";
            if (BindConverter.TryConvertTo(value, CultureInfo.InvariantCulture, out result))
            {
                validationErrorMessage = null;
                return true;
            }
            validationErrorMessage = string.Format(CultureInfo.InvariantCulture, _parsingErrorMessage, DisplayName ?? FieldIdentifier.FieldName);
            return false;
        }
    }
}