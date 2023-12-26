using Microsoft.AspNetCore.Components;

namespace Flatify.Components.Forms
{
    public partial class FlatTextArea
    {
        [Parameter] public int Lines { get; set; } = 1;
    }
}