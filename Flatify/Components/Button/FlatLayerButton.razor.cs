using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatLayerButton
    {
        [Parameter] public BorderType Border { get; set; } = BorderType.None;
        [Parameter] public EdgeType Edge { get; set; } = EdgeType.RoundSm;
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Blue;
        [Parameter] public ButtonType Type { get; set; } = ButtonType.Button;
        [Parameter] public Variant Variant { get; set; } = Variant.Light;
        [Parameter] public RenderFragment LayerContent { get; set; }
        protected String Classname => new CssBuilder("button")
                                      //.AddClass(Variant.ToDescriptionString())
                                      .AddClass("two-layer-button")
                                      .AddClass($"style-{Color.ToDescriptionString()}")
                                      .AddClass($"edge-{Edge.ToDescriptionString()}")
                                      .AddClass("disabled", Disabled)
                                      .AddClass($"border-{Border.ToDescriptionString()}", Border != BorderType.None)
                                      .Build();
    }
}