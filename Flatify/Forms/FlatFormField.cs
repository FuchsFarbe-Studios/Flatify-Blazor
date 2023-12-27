using Flatify.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Flatify.Forms
{
    public class FlatFormField : FlatComponentBase
    {
        protected string Classname => new CssBuilder()
                                      .AddClass("input-wrapper")
                                      .AddClass(Class)
                                      .Build();


        /// <summary>
        ///     Child content form the form field
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary> Where help text goes. </summary>
        [Parameter] public RenderFragment HelpContent { get; set; }


        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var i = 0;
            builder.OpenElement(i, "div");

            builder.AddMultipleAttributes(i++, UserAttributes);

            //Class
            builder.AddAttribute(i++, "class", Class);
            //Style
            builder.AddAttribute(i++, "style", Style);

            //Content
            builder.AddContent(i++, ChildContent);
            builder.AddContent(i++, HelpContent);

            //Close
            builder.CloseElement();
        }
    }
}