using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatYesNoField
    {
        private string yesValue => UseYesNo
                                       ? "Y"
                                       : "true";
        private string noValue => UseYesNo
                                      ? "N"
                                      : "false";

        protected virtual string Classname => new CssBuilder()
                                              .AddClass($"{YesNoType.ToDescriptionString()}-wrapper")
                                              .AddClass($"{Size.ToDescriptionString()}")
                                              .Build();
        /// <summary>
        ///     When this is set to yes, boolean values will be read as Y or N strings instead of true or false.
        /// </summary>
        [Parameter] public bool UseYesNo { get; set; } = false;
        [Parameter] public YesNoType YesNoType { get; set; } = YesNoType.Checkbox;
        [Parameter] public string ItemName { get; set; }

        /// <inheritdoc />
        protected override string FormatValueAsString(bool value)
        {
            if (UseYesNo)
                return value
                           ? "Y"
                           : "N";

            return value.ToString();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out bool result, out string validationErrorMessage)
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