using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    /// <summary>
    ///     Creates a block-quote element with citations, styling, and icons.
    /// </summary>
    public partial class FlatQuote
    {
        protected string Classname => new CssBuilder()
                                      .AddClass("large", IsLarge)
                                      .AddClass($"style-{Color.ToDescriptionString()}", Color != FlatColor.Inherit || Color != FlatColor.Default || Color != FlatColor.Transparent)
                                      .AddClass("no-icon", !UseIcon)
                                      .AddClass(Class)
                                      .Build();

        /// <summary>
        ///     The main content of the block quote.
        /// </summary>
        [Parameter] public RenderFragment QuoteContent { get; set; }

        /// <summary>
        ///     The citation of the block quote.
        /// </summary>
        [Parameter] public string Citation { get; set; }

        /// <summary>
        ///     Determines if the block quote is styled large.
        /// </summary>
        [Parameter] public bool IsLarge { get; set; }

        /// <summary>
        ///     Determines if the block quote is styled with an icon.
        /// </summary>
        [Parameter] public bool UseIcon { get; set; }

        /// <summary>
        ///     Color to apply to the quote.
        /// </summary>
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Default;
    }
}