using Flatify.Utilities;

namespace Flatify.Components.Forms
{
    public partial class FlatSwitchInput
    {
        /// <inheritdoc />
        protected override string LabelClassname => new CssBuilder()
                                                    .AddClass("toggle-wrapper")
                                                    .Build();
    }
}