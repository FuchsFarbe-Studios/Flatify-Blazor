using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatTab
    {
        protected string TabContentClassName => new CssBuilder()
                                                .AddClass("tab-panel")
                                                .AddClass("show", Tabs.SelectedContainer.TabID == TabID)
                                                .Build();
        public string ButtonClassName => new CssBuilder()
                                         .AddClass("tab-button")
                                         .AddClass("active", Tabs.SelectedContainer.TabID == TabID)
                                         .Build();
        [Parameter] public string TabID { get; set; } = Guid.NewGuid().ToString();
        [CascadingParameter] public FlatTabs Tabs { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment TabButtonContent { get; set; }
        [Parameter] public string TabButtonText { get; set; } = "Tab";
        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Tabs.AddItem(this);
        }
    }
}