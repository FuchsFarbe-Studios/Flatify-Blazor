// Flatify
// FlatTheme.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 19-12-2023
namespace Flatify.Themes
{

	/// <summary>
	/// Theme settings for the provider.
	/// </summary>
	public class FlatTheme
	{
		/// <summary>
		/// Gets or sets the palette for the light theme.
		/// </summary>
		public Palette Palette { get; set; } = new Palette();


		/// <summary>
		/// Gets or sets the typography for the theme.
		/// </summary>
		public Typography Typography { get; set; } = new Typography();
		
		/// <summary>
		/// Theme icons as svgs.
		/// </summary>
		public ThemeIcons Icons { get; set; } = new ThemeIcons();

		/// <summary>
		/// Design items.
		/// </summary>
		public ThemeDesign Design { get; set; } = new ThemeDesign();
	}
}