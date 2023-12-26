using Flatify.Utilities;

namespace Flatify.Forms
{
    public partial class FlatBoolField
    {
        protected virtual string Classname => new CssBuilder()
            .Build();

        /// <inheritdoc />
        protected override string FormatValueAsString(bool value)
        {
            return value.ToString();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out bool result, out string validationErrorMessage)
        {
            if (bool.TryParse(value, out result))
            {
                validationErrorMessage = null;
                return true;
            }
            validationErrorMessage = $"The {FieldIdentifier.FieldName} field is not a valid boolean value.";
            return false;
        }
    }
}