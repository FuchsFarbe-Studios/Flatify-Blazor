namespace Flatify
{
    public partial class FlatTabs
    {
        /// <inheritdoc />
        public override void AddItem(FlatTab item)
        {
            Items.Add(item);
            if (Items.Count == 1)
                ActivateTab(item);
            StateHasChanged();
        }

        private void ActivateTab(FlatTab tab)
        {
            SelectedIndex = Items.IndexOf(tab);
        }
    }
}