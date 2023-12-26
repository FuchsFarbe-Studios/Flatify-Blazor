using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatNumericInput<TNumeric>
    {

        private Dictionary<string, object> inputAttributeDict = new Dictionary<string, object>();
        protected string Classname => new CssBuilder()
                                      .AddClass(CssClass)
                                      .Build();
        protected string InputClassname => new CssBuilder()
                                           .AddClass("disabled", Disabled)
                                           .AddClass(CssClass)
                                           .Build();
        protected string LabelClassname => new CssBuilder()
                                           .AddClass("form-label")
                                           .AddClass("inline", Inline)
                                           .Build();

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
        ///     Determines if control uses floating labels.
        /// </summary>
        [Parameter] public bool Floating { get; set; } = false;

        /// <summary>
        ///     Determines if this is an inline form control.
        /// </summary>
        [Parameter] public bool Inline { get; set; } = false;

        /// <summary>
        ///     The specific number type.
        /// </summary>
        [Parameter] public TNumeric NumType { get; set; }

        /// <summary>
        ///     Maximum number of characters that the input will accept
        /// </summary>
        [Parameter] public int MaxLength { get; set; } = 524288;

        /// <summary> Minimum numeric value. </summary>
        [Parameter] public decimal? Min { get; set; }

        /// <summary> Maximum numeric value. </summary>
        [Parameter] public decimal? Max { get; set; }

        /// <summary> Width of the input. </summary>
        [Parameter] public Width Width { get; set; } = Width.Medium;

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            inputAttributeDict.Add("placeholder", inputPlaceholder);
            inputAttributeDict.Add("maxlength", MaxLength);
            inputAttributeDict.Add("class", InputClassname);
            if (ReadOnly)
                inputAttributeDict.Add("readonly", "readonly");
            if (Required)
                inputAttributeDict.Add("required", "required");
            if (Disabled)
                inputAttributeDict.Add("disabled", "disabled");
            if (Min != null)
                inputAttributeDict.Add("min", Min);
            if (Max != null)
                inputAttributeDict.Add("max", Max);
            base.OnParametersSet();
        }
    }
}