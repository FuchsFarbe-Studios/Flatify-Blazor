using Microsoft.AspNetCore.Components;

namespace Flatify.Components.Forms
{
    public partial class FlatOption<TValue>
    {
        [CascadingParameter] public FlatSelectInput<TValue> FlatSelect { get; set; }
        [Parameter] public TValue Value { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            if (FlatSelect != null)
                FlatSelect.Add(this);
        }
    }
}