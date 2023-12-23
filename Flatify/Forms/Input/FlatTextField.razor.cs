using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatTextField
    {
        protected String Classname => new CssBuilder()
                                      .AddClass(CssClass)
                                      .Build();

        /// <summary>
        ///     Maximum number of characters that the input will accept
        /// </summary>
        [Parameter] public Int32 MaxLength { get; set; } = 524288;
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <inheritdoc />
        protected override Boolean TryParseValueFromString(String value, out String result, out String validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}