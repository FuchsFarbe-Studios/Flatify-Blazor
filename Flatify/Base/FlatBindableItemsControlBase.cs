// EpochWorlds
// FlatBindableItemsControlBase.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public abstract class FlatBindableItemsControlBase<TChildComponent, TData> : FlatItemsControlBase<TChildComponent>
        where TChildComponent : FlatComponentBase
    {
        /// <summary>
        ///     Items Collection - For data-binding usage
        /// </summary>
        [Parameter] public IEnumerable<TData>? ItemsSource { get; set; }

        /// <summary>
        ///     Template for each Item in ItemsSource collection
        /// </summary>
        [Parameter] public RenderFragment<TData> ItemTemplate { get; set; }

        /// <summary>
        ///     Gets the Selected Item from ItemsSource, or Selected TChildComponent, when it's null
        /// </summary>
        public object SelectedItem => ItemsSource == null
                                          ? Items[SelectedIndex]
                                          : ItemsSource.ElementAtOrDefault(SelectedIndex);
    }
}