using Flatify.Utilities;

namespace Flatify
{
    public partial class FlatAccordion
    {
        protected string Classname => new CssBuilder("accordion")
                                      .AddClass(Class)
                                      .Build();
    }
}