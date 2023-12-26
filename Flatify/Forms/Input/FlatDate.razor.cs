using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatDate
    {
        protected string LabelClassname => new CssBuilder()
                                           .AddClass("form-label")
                                           .Build();

        [Parameter] public bool Floating { get; set; } = false;

        /// <inheritdoc />
        protected override string FormatValueAsString(DateTime? value)
        {
            return value.ToString();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out DateTime? result, out string validationErrorMessage)
        {
            validationErrorMessage = null;
            if (!DateTime.TryParse(value, out var parsedValue))
            {
                validationErrorMessage = "Unable to parse date-time...";
                result = null;
                return false;
            }
            result = parsedValue;
            return false;
        }
    }
}