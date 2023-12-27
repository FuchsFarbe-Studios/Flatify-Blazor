using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    /// <summary>
    ///     A flat button component.
    /// </summary>
    public partial class FlatButton
    {
        /// <summary> Buttons edge styling. </summary>
        [Parameter] public EdgeType Edge { get; set; } = EdgeType.Sharp;

        /// <summary> Buttons edge styling. </summary>
        [Parameter] public ElementWidth Width { get; set; } = ElementWidth.Medium;

        /// <summary> The buttons color. </summary>
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Accent;

        /// <summary>
        ///     The variation in button styling.
        /// </summary>
        [Parameter] public Variant Variant { get; set; } = Variant.Default;

        protected virtual string Classname => new CssBuilder()
                                              //.AddClass(Variant.ToDescriptionString())
                                              .AddClass("button", string.IsNullOrEmpty(Link))
                                              .AddClass($"{ElementSize.ToDescriptionString()}", ElementSize != ElementSize.Medium)
                                              .AddClass($"{Variant.ToDescriptionString()}")
                                              .AddClass($"style-{Color.ToDescriptionString()}", string.IsNullOrEmpty(Link))
                                              .AddClass($"color-{Color.ToDescriptionString()}", !string.IsNullOrEmpty(Link))
                                              .AddClass("link-button", !string.IsNullOrEmpty(Link))
                                              .AddClass($"width-{Width.ToDescriptionString()}")
                                              .AddClass($"edge-{Edge.ToDescriptionString()}")
                                              .AddClass("disabled", Disabled)
                                              .AddClass(Class)
                                              .Build();

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (!UserAttributes.TryAdd("type", ButtonType.ToDescriptionString()))
                UserAttributes["type"] = "button";
            UserAttributes.TryAdd("href", Link);
            UserAttributes.TryAdd("target", Target);
            UserAttributes.TryAdd("rel", GetRel());
            UserAttributes.TryAdd("disabled", GetDisabledState());
        }
    }
}