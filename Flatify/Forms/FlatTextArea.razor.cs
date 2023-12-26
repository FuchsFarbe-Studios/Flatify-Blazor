using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatTextArea
    {
        [Parameter] public int Lines { get; set; } = 1;
    }
}