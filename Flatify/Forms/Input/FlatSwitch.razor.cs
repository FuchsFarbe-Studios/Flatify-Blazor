using Flatify.Utilities;

namespace Flatify.Forms
{
    public partial class FlatSwitch
    {
        protected virtual string Classname => new CssBuilder()
                                              .AddClass("toggle-wrapper")
                                              .AddClass($"{Size.ToDescriptionString()}")
                                              .AddClass($"style-{Color.ToDescriptionString()}", Color == FlatColor.Default && Color != FlatColor.Inherit && Color != FlatColor.Transparent)
                                              .Build();
    }
}