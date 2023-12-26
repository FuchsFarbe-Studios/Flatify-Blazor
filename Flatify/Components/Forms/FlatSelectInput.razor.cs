using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Flatify.Components.Forms
{
    public partial class FlatSelectInput<TValue>
    {
        private readonly bool _isMultipleSelect;

        public FlatSelectInput()
        {
            _isMultipleSelect = typeof(TValue).IsArray;
        }

        /// <summary>
        ///     Selected value of the select field.
        /// </summary>
        public FlatOption<TValue> SelectedOption { get; set; }

        /// <summary>
        ///     Available selections for the select option.
        /// </summary>
        public List<FlatOption<TValue>> Options { get; set; } = new List<FlatOption<TValue>>();

        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Options.Any())
            {
                SelectedOption = Options.First();
            }
        }

        protected void OnChange(ChangeEventArgs e)
        {
            var value = e.Value;
            SelectedOption = Options.FirstOrDefault(x => x.Equals(value));
            if (SelectedOption != null)
            {
                Value = SelectedOption.Value;
            }
        }

        public void Add(FlatOption<TValue> flatOption)
        {
            Options.Add(flatOption);
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            validationErrorMessage = "";
            result = default;
            if (BindConverter.TryConvertTo<TValue>(value, CultureInfo.InvariantCulture, out result))
            {
                validationErrorMessage = null;
                return true;
            }
            validationErrorMessage = string.Format(CultureInfo.InvariantCulture, validationErrorMessage, DisplayName ?? FieldIdentifier.FieldName);
            return false;
        }

        /// <inheritdoc />
        protected override string? FormatValueAsString(TValue? value)
        {
            // We special-case bool values because BindConverter reserves bool conversion for conditional attributes.
            if (typeof(TValue) == typeof(bool))
            {
                return (bool)(object)value!
                           ? "true"
                           : "false";
            }
            if (typeof(TValue) == typeof(bool?))
            {
                return value is not null && (bool)(object)value
                           ? "true"
                           : "false";
            }

            return base.FormatValueAsString(value);
        }

        private void SetCurrentValueAsStringArray(string?[]? value)
        {
            CurrentValue = BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out var result)
                               ? result
                               : default;
        }
    }
}