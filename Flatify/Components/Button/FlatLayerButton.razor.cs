using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatLayerButton
    {
        protected string Classname => new CssBuilder()
                                      .AddClass("button")
                                      //.AddClass(Variant.ToDescriptionString())
                                      .AddClass("two-layer-button")
                                      .AddClass($"style-{Color.ToDescriptionString()}")
                                      .AddClass($"edge-{Edge.ToDescriptionString()}")
                                      .AddClass("disabled", Disabled)
                                      .AddClass($"size-{ElementSize.ToDescriptionString()}", ElementSize != ElementSize.Medium)
                                      .AddClass($"{Border.ToDescriptionString()}", Border != BorderType.None)
                                      .AddClass(Class)
                                      .Build();

        [Parameter] public BorderType Border { get; set; } = BorderType.None;
        [Parameter] public EdgeType Edge { get; set; } = EdgeType.RoundSm;
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Blue;
        [Parameter] public ButtonType Type { get; set; } = ButtonType.Button;
        [Parameter] public Variant Variant { get; set; } = Variant.Outline;
        [Parameter] public RenderFragment LayerContent { get; set; }
    }
}