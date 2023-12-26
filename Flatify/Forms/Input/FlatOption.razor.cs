using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatOption<TValue>
    {
        [CascadingParameter] public FlatSelectField<TValue> FlatSelect { get; set; }
        [Parameter] public TValue Value { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        /// <inheritdoc />
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (FlatSelect != null)
                FlatSelect.Add(this);
        }
    }
}