using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class FlatTab
    {
        protected string TabContentClassName => new CssBuilder()
                                                .AddClass("tab-panel")
                                                .AddClass("show", Tabs.SelectedContainer.TabID == TabID)
                                                .AddClass(Class)
                                                .Build();
        public string ButtonClassName => new CssBuilder()
                                         .AddClass("tab-button")
                                         .AddClass("active", Tabs.SelectedContainer.TabID == TabID)
                                         .AddClass(Class)
                                         .Build();
        [CascadingParameter] public FlatTabs Tabs { get; set; } = null!;
        [Parameter] public string TabButtonText { get; set; } = "Tab";
        [Parameter] public string TabID { get; set; } = Guid.NewGuid().ToString();
        [Parameter] public RenderFragment TabContent { get; set; }
        [Parameter] public RenderFragment TabButtonContent { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            //base.OnParametersSet();
            if (Tabs != null)
                Tabs.AddItem(this);
        }
    }
}