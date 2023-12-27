using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics;
using System.Globalization;

namespace Flatify.Forms
{
    public partial class FlatDateInput<TDateTime>
    {
        private const string DateFormat = "yyyy-MM-dd";// Compatible with HTML 'date' inputs
        private const string DateTimeLocalFormat = "yyyy-MM-ddTHH:mm:ss";// Compatible with HTML 'datetime-local' inputs
        private const string MonthFormat = "yyyy-MM";// Compatible with HTML 'month' inputs
        private const string TimeFormat = "HH:mm:ss";
        private string _format = default!;
        private string _parsingErrorMessage = default!;
        private string _typeAttributeValue = default!;

        /// <summary>
        ///     Gets or sets the type of HTML input to be rendered.
        /// </summary>
        [Parameter] public InputDateType Type { get; set; } = InputDateType.Date;
        [Parameter] public string ParsingErrorMessage { get; set; } = string.Empty;

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            (_typeAttributeValue, _format, var formatDescription) = Type switch
            {
                InputDateType.Date => ("date", DateFormat, "date"),
                InputDateType.DateTimeLocal => ("datetime-local", DateTimeLocalFormat, "date and time"),
                InputDateType.Month => ("month", MonthFormat, "year and month"),
                InputDateType.Time => ("time", TimeFormat, "time"),
                _ => throw new InvalidOperationException($"Unsupported {nameof(InputDateType)} '{Type}'.")
            };

            _parsingErrorMessage = string.IsNullOrEmpty(ParsingErrorMessage)
                                       ? $"The {{0}} field must be a {formatDescription}."
                                       : ParsingErrorMessage;
        }

        /// <inheritdoc />
        protected override string FormatValueAsString(TDateTime value)
        {
            return value switch
            {
                DateTime dateTimeValue => dateTimeValue.Date.ToString(DateFormat, CultureInfo.InvariantCulture),
                DateTimeOffset dateTimeOffsetValue => dateTimeOffsetValue.DateTime.ToString(DateTimeLocalFormat, CultureInfo.InvariantCulture),
                DateOnly dateOnlyValue => dateOnlyValue.ToString(MonthFormat, CultureInfo.InvariantCulture),
                TimeOnly timeOnlyValue => timeOnlyValue.ToTimeSpan().ToString(TimeFormat, CultureInfo.InvariantCulture),
                _ => string.Empty// Handles null for Nullable<DateTime>, etc.
            };
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out TDateTime result, out string validationErrorMessage)
        {
            if (BindConverter.TryConvertTo<TDateTime>(value, CultureInfo.InvariantCulture, out result))
            {
                Debug.Assert(result != null);
                validationErrorMessage = null;
                return true;
            }
            validationErrorMessage = string.Format(CultureInfo.InvariantCulture, _parsingErrorMessage, DisplayName ?? FieldIdentifier.FieldName);
            return false;
        }
    }
}