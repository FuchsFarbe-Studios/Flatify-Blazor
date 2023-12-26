using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    /// <summary>
    ///     A flat button component.
    /// </summary>
    public partial class FlatButton
    {
        /// <summary>
        ///     Buttons border styling.
        /// </summary>
        [Parameter] public BorderType Border { get; set; } = BorderType.None;

        /// <summary> Buttons edge styling. </summary>
        [Parameter] public EdgeType Edge { get; set; } = EdgeType.Sharp;

        /// <summary> The buttons color. </summary>
        [Parameter] public FlatColor Color { get; set; } = FlatColor.Accent;

        /// <summary>
        ///     The variation in button styling.
        /// </summary>
        [Parameter] public Variant Variant { get; set; } = Variant.Light;

        protected virtual string Classname => new CssBuilder()
                                              //.AddClass(Variant.ToDescriptionString())
                                              .AddClass("button")
                                              .AddClass($"size-{Size.ToDescriptionString()}", Size != Size.Medium)
                                              .AddClass($"style-{Color.ToDescriptionString()}")
                                              .AddClass($"{Border.ToDescriptionString()}", Border != BorderType.None)
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