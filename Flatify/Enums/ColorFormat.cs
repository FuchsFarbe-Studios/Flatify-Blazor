// Flatify
// ColorFormat.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 19-12-2023
namespace Flatify
{

    public enum ColorFormat
    {
        /// <summary>
        ///     Output will be starting with a # and include r,g and b but no alpha values. Example #ab2a3d
        /// </summary>
        Hex,

        /// <summary>
        ///     Output will be starting with a # and include r,g and b and alpha values. Example #ab2a3dff
        /// </summary>
        HexA,

        /// <summary>
        ///     Will output css like output for value. Example rgb(12,15,40)
        /// </summary>
        RGB,

        /// <summary>
        ///     Will output css like output for value with alpha. Example rgba(12,15,40,0.42)
        /// </summary>
        RGBA
    }
}