using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    /// <summary>
    ///     Allows binding text data.
    /// </summary>
    public partial class FlatTextInput
    {
        /// <summary>
        ///     Maximum number of characters that the input will accept
        /// </summary>
        [Parameter] public int MaxLength { get; set; } = 524288;
        /// <summary>
        ///     Maximum number of characters that the input will accept
        /// </summary>
        [Parameter] public int MinLength { get; set; } = 0;

        /// <inheritdoc />
        public override void FlatStateHasChanged()
        {
            StateHasChanged();
        }
    }
}