using Flatify.Utilities;

namespace Flatify.Forms
{
    public partial class FlatSwitch
    {
        protected virtual string Classname => new CssBuilder()
                                              .AddClass("toggle-wrapper")
                                              .AddClass($"{Size.ToDescriptionString()}")
                                              .Build();
    }
}