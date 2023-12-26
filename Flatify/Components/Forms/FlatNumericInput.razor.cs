using Microsoft.AspNetCore.Components;

namespace Flatify.Components.Forms
{
    /// <summary>
    ///     Allows data binding with numerical values.
    /// </summary>
    /// <typeparam name="TData"> Type of numerical data. </typeparam>
    public partial class FlatNumericInput<TData>
    {
        /// <summary> Minimum allowed value. </summary>
        [Parameter] public int MinValue { get; set; }

        /// <summary> Maximum allowed value. </summary>
        [Parameter] public int MaxValue { get; set; }

        /// <summary>
        ///     Maximum number of characters that the input will accept
        /// </summary>
        [Parameter] public int MaxLength { get; set; } = 524288;

        /// <summary>
        ///     Maximum number of characters that the input will accept
        /// </summary>
        [Parameter] public int MinLength { get; set; } = 0;

        /// <summary> Incrementing step. </summary>
        [Parameter] public TData Step { get; set; }
    }
}