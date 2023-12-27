using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatSwitchInput
    {
        /// <inheritdoc />
        protected override string LabelClassname => new CssBuilder()
                                                    .AddClass("toggle-wrapper")
                                                    .Build();
        [Parameter] public LabelDirection Direction { get; set; } = LabelDirection.Left;
    }
}