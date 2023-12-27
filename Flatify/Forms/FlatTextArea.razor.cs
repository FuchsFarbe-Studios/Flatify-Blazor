using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatTextArea
    {
        /// <inheritdoc />
        protected override string ContainerClassname => base.ContainerClassname
                                                        + new CssBuilder()
                                                          .AddClass("is-textarea")
                                                          .Build();

        [Parameter] public int Lines { get; set; } = 1;
    }
}