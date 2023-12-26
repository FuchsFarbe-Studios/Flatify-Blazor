using Flatify.Utilities;

namespace Flatify.Forms
{
    public partial class FlatSwitchInput
    {
        /// <inheritdoc />
        protected override string LabelClassname => new CssBuilder()
                                                    .AddClass("toggle-wrapper")
                                                    .Build();
    }
}