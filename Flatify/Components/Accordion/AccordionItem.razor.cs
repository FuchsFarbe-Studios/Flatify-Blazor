using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class AccordionItem
    {
        private bool isContentVisible = false;
        protected string Classname => new CssBuilder("accordion-collapse")
                                      .AddClass("show", isContentVisible)
                                      .Build();
        [Parameter] public RenderFragment Content { get; set; }
        [Parameter] public RenderFragment TitleContent { get; set; }
        [Parameter] public string ID { get; set; } = Guid.NewGuid().ToString();
        public void ToggleContentVisibility()
        {
            isContentVisible = !isContentVisible;
        }
    }
}