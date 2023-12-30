using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatTextArea
    {
        /// <inheritdoc />
        protected override string ContainerClassname => new CssBuilder()
                                                        .AddClass("input-wrapper")
                                                        .AddClass("is-textarea")
                                                        .AddClass("floating-label")
                                                        .AddClass("w-100p")
                                                        .Build();

        [Parameter] public int Lines { get; set; } = 1;
    }
}