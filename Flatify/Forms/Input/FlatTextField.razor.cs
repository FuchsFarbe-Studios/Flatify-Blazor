using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatTextField
    {
        private int _lineCount = 1;
        protected string Classname => new CssBuilder()
                                      .AddClass("input-wrapper")
                                      .AddClass("floating-label", Floating)
                                      .AddClass("is-textarea", isArea)
                                      .AddClass(CssClass)
                                      .Build();

        protected string InputClassname => new CssBuilder()
                                           .AddClass("disabled", Disabled)
                                           .AddClass(CssClass)
                                           .Build();

        protected string LabelClassname => new CssBuilder()
                                           .AddClass("form-label", Inline)
                                           .AddClass("inline", Inline)
                                           .Build();
        protected bool isArea => LineCount > 1;

        protected string inputPlaceholder
        {
            get
            {
                if (string.IsNullOrEmpty(_placeholder) && Floating)
                    return Label;

                return Placeholder;
            }
        }

        /// <summary>
        /// Maximum number of characters that the input will accept
        /// </summary>
        [Parameter] public int MaxLength { get; set; } = 524288;

        /// <summary>
        ///     Makes the labels in-line with the input
        /// </summary>
        [Parameter] public bool Inline { get; set; } = false;

        /// <summary>
        ///     Makes the input floating.
        /// </summary>
        [Parameter] public bool Floating { get; set; } = false;

        [Parameter] public int LineCount
        {
            get => _lineCount;
            set => _lineCount = value > 1
                                    ? value
                                    : 1;
        }


        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}