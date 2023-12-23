using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatTextField
    {
        protected string Classname => new CssBuilder()
                                      .AddClass(CssClass)
                                      .Build();

        /// <summary>
        ///     Maximum number of characters that the input will accept
        /// </summary>
        [Parameter] public int MaxLength { get; set; } = 524288;
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}