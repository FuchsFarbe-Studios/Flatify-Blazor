using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatCard
    {
        protected virtual string Classname => new CssBuilder()
                                              .AddClass("card")
                                              .AddClass($"edge-{Edge.ToDescriptionString()}", Edge != EdgeType.None)
                                              .AddClass($"{CardElementSize.ToDescriptionString()}", CardElementSize != ElementSize.Medium)
                                              .AddClass(Class)
                                              .Build();
        protected string Stylename => $"max-width: {MaxWidth}px;";

        // Card Fragments
        /// <summary>
        ///     Badges that overlay the card image should go within this fragment.
        /// </summary>
        [Parameter] public RenderFragment Badges { get; set; }

        /// <summary>
        ///     Forms the body of the card information.
        /// </summary>
        [Parameter] public RenderFragment CardContent { get; set; }

        /// <summary>
        ///     Place buttons such as share and like within this fragment.
        /// </summary>
        [Parameter] public RenderFragment CardButtons { get; set; }

        /// <summary>
        ///     Put links such as 'read more' or 'buy now' within this fragment.
        /// </summary>
        [Parameter] public RenderFragment CardLinks { get; set; }

        // Card Properties
        /// <summary>
        ///     Heading text for the card.
        /// </summary>
        [Parameter] public string HeadingText { get; set; }

        /// <summary>
        ///     Maximum width for a card. Defaults to 320px.
        /// </summary>
        [Parameter] public int MaxWidth { get; set; } = 320;

        /// <summary>
        ///     Image source for the card.
        /// </summary>
        [Parameter] public string Img { get; set; }

        /// <summary>
        ///     Alt text for the card image.
        /// </summary>
        [Parameter] public string Alt { get; set; }

        /// <summary>
        ///     Size of the general text within the card.
        /// </summary>
        [Parameter] public ElementSize CardElementSize { get; set; } = ElementSize.Medium;

        /// <summary> The edges of a card. </summary>
        [Parameter] public EdgeType Edge { get; set; } = EdgeType.None;
    }
}