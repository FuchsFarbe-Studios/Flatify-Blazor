using Flatify.Utilities;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Flatify
{
    public partial class FlatSelectField<TValue>
    {
        protected string LabelClass => new CssBuilder()
                                       .AddClass("form-label")
                                       .AddClass($"size-{Size.ToDescriptionString()}")
                                       .Build();
        protected string InputClass => new CssBuilder()
                                       .AddClass($"size-{Size.ToDescriptionString()}")
                                       .AddClass($"style-{Color.ToDescriptionString()}", Color == FlatColor.Default && Color != FlatColor.Inherit && Color != FlatColor.Transparent)
                                       .Build();
        protected string ContainerClass => new CssBuilder()
                                           .AddClass(CssClass)
                                           .Build();
        [Parameter] public bool Floating { get; set; }

        /// <summary>
        ///     The style of the select field.
        /// </summary>
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Accent;

        /// <summary>
        ///     The options content of the select field.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        ///     Selected value of the select field.
        /// </summary>
        public FlatOption<TValue> SelectedOption { get; set; }

        /// <summary>
        ///     Available selections for the select option.
        /// </summary>
        public List<FlatOption<TValue>> Options { get; set; } = new List<FlatOption<TValue>>();

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
        protected override string FormatValueAsString(TValue value)
        {
            return value.ToString();
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
    }
}