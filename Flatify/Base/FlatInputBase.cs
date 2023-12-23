using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Flatify
{
    public class FlatInputBase<T> : InputBase<T>
    {
        /// <summary>
        ///     If true, the input element will be required.
        /// </summary>
        [Parameter] public Boolean Required { get; set; }

        /// <summary>
        ///     If true, the input element will be disabled.
        /// </summary>
        [Parameter] public Boolean Disabled { get; set; }

        /// <summary>
        ///     Determines disabled state.
        /// </summary>
        [CascadingParameter(Name = "ParentDisabled")] private Boolean ParentDisabled { get; set; }

        /// <summary>
        ///     If true, the input will be read-only.
        /// </summary>
        [Parameter] public Boolean ReadOnly { get; set; }

        /// <summary>
        ///     Determines readonly state.
        /// </summary>
        [CascadingParameter(Name = "ParentReadOnly")] private Boolean ParentReadOnly { get; set; }

        /// <summary>
        ///     The HelperText will be displayed below the text field.
        /// </summary>
        [Parameter] public String HelperText { get; set; }

        /// <summary>
        ///     Error text that displays when internal parsing fails.
        /// </summary>
        [Parameter] public String ParsingErrorText { get; set; } = "The entered value could not be validated.";

        /// <summary>
        ///     Displayed when successfully parsed value is still an invalid value.
        /// </summary>
        [Parameter] public String InvalidErrorText { get; set; } = "The entered value is invalid!";

        /// <summary>
        ///     Displayed when the input is required and no value is provided.
        /// </summary>
        [Parameter] public String RequiredErrorText { get; set; } = "This field is required!";

        /// <summary>
        ///     The short hint displayed in the input before the user enters a value.
        /// </summary>
        [Parameter] public String Placeholder { get; set; }

        /// <summary>
        ///     If string has value the label text will be displayed in the input, and scaled down at the top if the input has
        ///     value.
        /// </summary>
        [Parameter] public String Label { get; set; }

        /// <summary>
        ///     Hints at the type of data that might be entered by the user while editing the input
        /// </summary>
        [Parameter] public InputType InputMode { get; set; } = InputType.Text;

        public IReadOnlyDictionary<String, Object> UserAttributes => AdditionalAttributes;
        protected Boolean GetDisabledState()
        {
            return Disabled || ParentDisabled;
        }
        protected Boolean GetReadOnlyState()
        {
            return ReadOnly || ParentReadOnly;
        }

        /// <summary>
        ///     Derived classes need to override this if they can be something other than text
        /// </summary>
        internal virtual InputType GetInputType() { return InputType.Text; }

        /// <inheritdoc />
        protected override Boolean TryParseValueFromString(String value, out T result, out String validationErrorMessage)
        {
            if (typeof(T) == typeof(String))
            {
                result = value != null
                             ? (T)(Object)value
                             : default;
                validationErrorMessage = null;
                return true;
            }

            if (typeof(T) == typeof(Int32))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (T)(Object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
                validationErrorMessage = "The chosen value is not a valid number.";
                return false;
            }

            if (typeof(T) == typeof(Double))
            {
                if (double.TryParse(value, out var resultDouble))
                {
                    result = (T)(Object)resultDouble;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
                validationErrorMessage = "The chosen value is not a valid number.";
                return false;
            }

            if (typeof(T) == typeof(Decimal))
            {
                if (decimal.TryParse(value, out var resultDecimal))
                {
                    result = (T)(Object)resultDecimal;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
                validationErrorMessage = "The chosen value is not a valid number.";
                return false;
            }

            if (typeof(T) == typeof(Single))
            {
                if (float.TryParse(value, out var resultFloat))
                {
                    result = (T)(Object)resultFloat;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
                validationErrorMessage = "The chosen value is not a valid number.";
                return false;
            }

            if (typeof(T) == typeof(Int64))
            {
                if (long.TryParse(value, out var resultLong))
                {
                    result = (T)(Object)resultLong;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
                validationErrorMessage = "The chosen value is not a valid number.";
                return false;
            }

            if (typeof(T) == typeof(Int16))
            {
                if (short.TryParse(value, out var resultShort))
                {
                    result = (T)(Object)resultShort;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
            }

            // All else fails
            result = default;
            validationErrorMessage = $"The selected type {typeof(T)} is not supported by the FlatInput component.";
            return false;
        }
    }
}