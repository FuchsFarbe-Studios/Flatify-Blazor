using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatYesNoField
    {
        /// <summary>
        ///     When this is set to yes, boolean values will be read as Y or N strings instead of true or false.
        /// </summary>
        [Parameter] public Boolean UseYesNo { get; set; } = false;
        [Parameter] public YesNoType YesNoType { get; set; } = YesNoType.Checkbox;

        /// <inheritdoc />
        protected override String FormatValueAsString(Boolean value)
        {
            if (UseYesNo)
                return value
                           ? "Y"
                           : "N";

            return value.ToString();
        }

        /// <inheritdoc />
        protected override Boolean TryParseValueFromString(String value, out Boolean result, out String validationErrorMessage)
        {
            if (UseYesNo)
            {
                if (value.Equals("Y") || value.Equals("y"))
                {
                    result = true;
                    validationErrorMessage = null;
                    return true;
                }
                if (value.Equals("N") || value.Equals("n"))
                {
                    result = false;
                    validationErrorMessage = null;
                    return true;
                }

                result = false;
                validationErrorMessage = null;
                return false;
            }
            if (bool.TryParse(value, out result))
            {
                validationErrorMessage = null;
                return true;
            }
            validationErrorMessage = $"The {FieldIdentifier.FieldName} field is not a valid yes/no value.";
            return false;
        }
    }
}