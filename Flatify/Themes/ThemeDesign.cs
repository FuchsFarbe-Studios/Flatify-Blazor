// Flatify
// FlatTheme.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 19-12-2023
namespace Flatify.Themes
{
	/// <summary>
	/// Design items for the theme.
	/// </summary>
	public class ThemeDesign
	{
		/// <summary>
		/// The width of the border.
		/// </summary>
		public string BorderWidth { get; set; } = "max(2px, 0.18em)";

		/// <summary>
		/// The radius of the border.
		/// </summary>
		public string BorderRadius { get; set; } = "1em";

		/// <summary>
		/// Brightness setting on hover.
		/// </summary>
		public string HoverBrightness { get; set; } = "95%";

		/// <summary>
		/// Opacity for a backdrop.
		/// </summary>
		public string BackdropOpacity { get; set; } = "0.35";
	}
}