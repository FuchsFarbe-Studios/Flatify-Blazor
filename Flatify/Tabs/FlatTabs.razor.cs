namespace Flatify
{
    public partial class FlatTabs
    {
        /// <inheritdoc />
        public override void AddItem(FlatTab item)
        {
            Items.Add(item);
            if (Items.Count == 1)
            {
                ActivatePage(item);
            }
        }
        private void ActivatePage(FlatTab tab)
        {
            SelectedIndex = Items.IndexOf(tab);
        }
    }
}