using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Flatify
{
    public class FlatInputBase<T> : InputBase<T>
    {
        protected string _id = Guid.NewGuid().ToString();
        protected string _label = "";
        protected string _placeholder = "";

        /// <summary>
        ///     Unique identifier for this input field.
        /// </summary>
        [Parameter] public string Id
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        ///     If true, the input element will be required.
        /// </summary>
        [Parameter] public bool Required { get; set; }

        /// <summary>
        ///     If true, the input element will be disabled.
        /// </summary>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        ///     Determines disabled state.
        /// </summary>
        [CascadingParameter(Name = "ParentDisabled")] private bool ParentDisabled { get; set; }

        /// <summary>
        ///     If true, the input will be read-only.
        /// </summary>
        [Parameter] public bool ReadOnly { get; set; }

        /// <summary>
        ///     Determines readonly state.
        /// </summary>
        [CascadingParameter(Name = "ParentReadOnly")] private bool ParentReadOnly { get; set; }

        /// <summary>
        ///     The HelperText will be displayed below the text field.
        /// </summary>
        [Parameter] public string HelperText { get; set; }

        /// <summary>
        ///     Error text that displays when internal parsing fails.
        /// </summary>
        [Parameter] public string ParsingErrorText { get; set; } = "The entered value could not be validated.";

        /// <summary>
        ///     Displayed when successfully parsed value is still an invalid value.
        /// </summary>
        [Parameter] public string InvalidErrorText { get; set; } = "The entered value is invalid!";

        /// <summary>
        ///     Displayed when the input is required and no value is provided.
        /// </summary>
        [Parameter] public string RequiredErrorText { get; set; } = "This field is required!";

        /// <summary>
        ///     The short hint displayed in the input before the user enters a value.
        /// </summary>
        [Parameter] public virtual string Placeholder
        {
            get => _placeholder;
            set => _placeholder = value;
        }

        /// <summary>
        ///     If string has value the label text will be displayed in the input, and scaled down at the top if the input has
        ///     value.
        /// </summary>
        [Parameter] public string Label
        {
            get => _label;
            set => _label = value;
        }

        /// <summary>
        ///     Determines the size of the control on screen.
        /// </summary>
        [Parameter] public Size Size { get; set; } = Size.Medium;

        /// <summary>
        ///     Hints at the type of data that might be entered by the user while editing the input
        /// </summary>
        [Parameter] public InputType InputMode { get; set; } = InputType.Text;

        public IReadOnlyDictionary<string, object> UserAttributes => AdditionalAttributes;
        protected bool GetDisabledState()
        {
            return Disabled || ParentDisabled;
        }

        protected bool GetReadOnlyState()
        {
            return ReadOnly || ParentReadOnly;
        }

        /// <summary>
        ///     Derived classes need to override this if they can be something other than text
        /// </summary>
        internal virtual InputType GetInputType() { return InputType.Text; }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            if (typeof(T) == typeof(string))
            {
                result = value != null
                             ? (T)(object)value
                             : default;
                validationErrorMessage = null;
                return true;
            }

            if (typeof(T) == typeof(int))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (T)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
                validationErrorMessage = "The chosen value is not a valid number.";
                return false;
            }

            if (typeof(T) == typeof(double))
            {
                if (double.TryParse(value, out var resultDouble))
                {
                    result = (T)(object)resultDouble;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
                validationErrorMessage = "The chosen value is not a valid number.";
                return false;
            }

            if (typeof(T) == typeof(decimal))
            {
                if (decimal.TryParse(value, out var resultDecimal))
                {
                    result = (T)(object)resultDecimal;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
                validationErrorMessage = "The chosen value is not a valid number.";
                return false;
            }

            if (typeof(T) == typeof(float))
            {
                if (float.TryParse(value, out var resultFloat))
                {
                    result = (T)(object)resultFloat;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
                validationErrorMessage = "The chosen value is not a valid number.";
                return false;
            }

            if (typeof(T) == typeof(long))
            {
                if (long.TryParse(value, out var resultLong))
                {
                    result = (T)(object)resultLong;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
                validationErrorMessage = "The chosen value is not a valid number.";
                return false;
            }

            if (typeof(T) == typeof(short))
            {
                if (short.TryParse(value, out var resultShort))
                {
                    result = (T)(object)resultShort;
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