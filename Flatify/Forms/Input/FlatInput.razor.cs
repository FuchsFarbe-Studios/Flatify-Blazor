using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatInput
    {

        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}