// Flatify
// IFlatStateHasChanged.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 19-12-2023
namespace Flatify
{

    /// <summary>
    ///     Interface to force re-rendering on components where applicable.
    /// </summary>
    public interface IFlatStateHasChanged
    {
        /// <summary>
        ///     Notifies the component that its state has changed.
        /// </summary>
        void FlatStateHasChanged();
    }
}