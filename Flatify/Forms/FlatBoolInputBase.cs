using System.Diagnostics.CodeAnalysis;

namespace Flatify.Forms
{
    public class FlatBoolInputBase : FlatFormComponentBase<bool>
    {

        /// <inheritdoc />
        protected override string FormatValueAsString(bool value)
        {
            return value.ToString();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, out bool result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            throw new NotSupportedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");
        }
    }
}