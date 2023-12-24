using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify.Forms
{
    public partial class FlatForm
    {
        protected virtual string Classname => new CssBuilder()
                                              .AddClass("")
                                              .AddClass(Class)
                                              .Build();
        [Parameter] public RenderFragment ChildContent { get; set; }
        public List<IFormComponent> FormComponents { get; set; } = new List<IFormComponent>();

        // Callbacks for binding submission behaviour for a form
        [Parameter] public EventCallback OnSubmit { get; set; }
        [Parameter] public EventCallback OnValidSubmit { get; set; }
        [Parameter] public EventCallback OnInvalidSubmit { get; set; }
    }
}