// EpochWorlds
// FlatItemsControlBase.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using Microsoft.AspNetCore.Components;

namespace Flatify
{
    public abstract class FlatItemsControlBase<TChildComponent> : FlatComponentBase where TChildComponent : FlatComponentBase
    {

        internal Boolean _moveNext = true;
        private Int32 _selectedIndexField = -1;

        /// <summary> Collection of T </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary> Selected Item's index </summary>
        [Parameter] public Int32 SelectedIndex
        {
            get => _selectedIndexField;
            set
            {
                if (SelectedIndex == value)
                    return;

                _moveNext = value >= _selectedIndexField;
                LastContainer = _selectedIndexField >= 0
                                    ? SelectedContainer
                                    : null;
                _selectedIndexField = value;
                SelectionChanged();
                StateHasChanged();
                SelectedIndexChanged.InvokeAsync(value);
            }
        }

        [Parameter] public EventCallback<Int32> SelectedIndexChanged { get; set; }

        /// <summary>
        ///     Gets the Selected TChildComponent
        /// </summary>
        public TChildComponent LastContainer { get; private set; }

        /// <summary>
        ///     Items - will be ignored when ItemsSource is not null
        /// </summary>
        public List<TChildComponent> Items { get; } = new List<TChildComponent>();

        /// <summary>
        ///     Gets the Selected TChildComponent
        /// </summary>
        public TChildComponent SelectedContainer => SelectedIndex >= 0 && Items.Count > SelectedIndex
                                                        ? Items[SelectedIndex]
                                                        : null;

        /// <inheritdoc />
        protected override Task OnAfterRenderAsync(Boolean firstRender)
        {
            if (firstRender)
                if (Items.Count > 0 && SelectedIndex < 0)
                    MoveTo(0);

            return base.OnAfterRenderAsync(firstRender);
        }

        /// <summary> Move to Previous Item </summary>
        public void Previous()
        {
            _moveNext = false;

            if (SelectedIndex > 0)
                SelectedIndex--;
            else
                SelectedIndex = Items.Count - 1;
        }

        /// <summary> Move to Next Item </summary>
        public void Next()
        {
            _moveNext = true;

            if (SelectedIndex < Items.Count - 1)
                SelectedIndex++;
            else
                SelectedIndex = 0;
        }

        /// <summary>
        ///     Move to Item at desired index
        /// </summary>
        public void MoveTo(Int32 index)
        {
            if (SelectedIndex != index)
            {
                _moveNext = index >= SelectedIndex;
                SelectedIndex = index;
            }
        }

        protected virtual void SelectionChanged() {}

        public virtual void AddItem(TChildComponent item) {}
    }
}