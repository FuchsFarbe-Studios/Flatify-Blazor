using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public partial class AccordionItem
    {
        private bool isContentVisible = false;
        protected string Classname => new CssBuilder("accordion-collapse")
                                      .AddClass("show", isContentVisible)
                                      .AddClass(Class)
                                      .Build();
        [Parameter] public RenderFragment Content { get; set; }
        [Parameter] public RenderFragment TitleContent { get; set; }
        [Parameter] public string ID { get; set; } = Guid.NewGuid().ToString();

        [CascadingParameter] public FlatAccordion Accordion { get; set; } = null!;

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            Accordion.AddItem(this);
        }

        public void ToggleContentVisibility()
        {
            isContentVisible = !isContentVisible;
        }
    }
}