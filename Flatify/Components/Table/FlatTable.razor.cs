using Flatify.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    /// <summary>
    ///     Used to represent tabular data.
    /// </summary>
    public partial class FlatTable
    {
        protected string Classname => new CssBuilder()
                                      .AddClass("bordered", Bordered)
                                      .AddClass("horizontal", Horizontal)
                                      .AddClass("striped", Striped)
                                      .AddClass(Class)
                                      .Build();
        /// <summary>
        ///     Where the <tr /> and <td /> tags go
        /// </summary>
        [Parameter] public RenderFragment TableData { get; set; }

        /// <summary>
        ///     Where the <th /> tags go
        /// </summary>
        [Parameter] public RenderFragment TableHeaders { get; set; }

        /// <summary>
        ///     Sets table styling to bordered.
        /// </summary>
        [Parameter] public bool Bordered { get; set; } = true;

        /// <summary>
        ///     Sets the table to be horizontal.
        /// </summary>
        [Parameter] public bool Horizontal { get; set; }

        /// <summary>
        ///     Sets table styling to be striped.
        /// </summary>
        [Parameter] public bool Striped { get; set; }

        /// <summary>
        ///     The table caption text.
        /// </summary>
        [Parameter] public string CaptionText { get; set; }
    }
}