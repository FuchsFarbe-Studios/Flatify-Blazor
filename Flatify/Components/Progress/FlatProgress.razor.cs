using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    /// <summary>
    ///     Creates a spinner or progress bar.
    /// </summary>
    public partial class FlatProgress
    {
        protected string SpinnerClassName => new CssBuilder()
                                             .AddClass($"{Type.ToDescriptionString()}", Type != ProgressType.Bar)
                                             .AddClass("loading", Type == ProgressType.Bar)
                                             .AddClass($"color-{Color.ToDescriptionString()}", !Fill && !(Color == FlatColor.Transparent || Color == FlatColor.Default || Color == FlatColor.Inherit))
                                             .AddClass($"style-{Color.ToDescriptionString()}", Fill && !(Color == FlatColor.Transparent || Color == FlatColor.Default || Color == FlatColor.Inherit))
                                             .AddClass($"size-{ElementSize.ToDescriptionString()}")
                                             .Build();
        /// <summary>
        ///     The type of progress bar to display.
        /// </summary>
        [Parameter] public ProgressType Type { get; set; } = ProgressType.Default;

        /// <summary>
        ///     The size of the progress element.
        /// </summary>
        [Parameter] public ElementSize ElementSize { get; set; } = ElementSize.Medium;

        /// <summary>
        ///     The color of the progress element.
        /// </summary>
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Dark;

        /// <summary>
        ///     Determines if the spinner is a filled spinner.
        /// </summary>
        [Parameter] public bool Fill { get; set; }

        [Parameter] public float ProgressValue { get; set; }
        [Parameter] public float ProgressMinValue { get; set; }
        [Parameter] public float ProgressMaxValue { get; set; } = 100;

        protected float ProgressPercent
        {
            get
            {
                var val = 0f;
                if (ProgressValue > 0)
                {
                    val = ProgressValue / ProgressMaxValue * 100;
                }
                return val;
            }
        }
    }

}