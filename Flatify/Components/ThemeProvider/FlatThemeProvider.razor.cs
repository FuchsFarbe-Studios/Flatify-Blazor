// Flatify
// FlatTheme.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 19-12-2023

using Flatify.Themes;
using Flatify.Utilities;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace Flatify
{
    public partial class FlatThemeProvider
    {
        private const string PREFIX = "--flatify__";
        private const string PALETTE = "palette";
        private const string TYPOGRAPHY = "-typo";
        private FlatTheme _theme;

        [Parameter] public FlatTheme Theme
        {
            get => _theme;
            set
            {
                ThemeChanged.InvokeAsync(this);
                _theme = value;
            }
        }

        [Parameter] public EventCallback ThemeChanged { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            Theme ??= new FlatTheme
                      {
                          Palette = new Palette(),
                          Typography = new Typography()
                      };
        }

        // Builds root theme
        private string BuildTheme()
        {
            Theme ??= new FlatTheme();
            var themeRoot = new StringBuilder();
            themeRoot.AppendLine("<style>");
            themeRoot.Append(":root");
            themeRoot.AppendLine("{");
            GenerateTheme(themeRoot);
            themeRoot.AppendLine("}");
            themeRoot.AppendLine("</style>");

            return themeRoot.ToString();
        }

        private void GenerateTheme(StringBuilder theme)
        {
            GenerateThemeTypography(theme);
            GenerateThemeLayout(theme);
            GenerateThemeColors(theme);
        }

        private void GenerateThemeLayout(StringBuilder theme)
        {
            // *** Design
            theme.AppendLine($"{PREFIX}border-width: " + Theme.Design.BorderWidth + " !default;");
            theme.AppendLine($"{PREFIX}border-radius: " + Theme.Design.BorderRadius + " !default;");
            theme.AppendLine($"{PREFIX}hover-brightness: " + Theme.Design.HoverBrightness + " !default;");
            theme.AppendLine($"{PREFIX}backdrop-opacity: " + Theme.Design.BackdropOpacity + " !default;");

            // Icons
            foreach (FlatIconType e in Enum.GetValues(typeof(FlatIconType)))
            {
                var iconName = e.ToDescriptionString().ToLower();
                theme.AppendLine($"{PREFIX}-{iconName}: " + Theme.Icons.IconDict[e] + ";");
            }

            // Motion
            theme.AppendLine($"{PREFIX}simple-transition: " + "0.15s ease-in-out !default;");
            theme.AppendLine($"{PREFIX}long-transition: " + "1s ease-in-out !default;");
            theme.AppendLine($"{PREFIX}bouncing-transition: " + "0.35s cubic-bezier(0.59, -0.39, 0.36, 1.38) !default;");
        }

        private void GenerateThemeTypography(StringBuilder theme)
        {
            theme.AppendLine($"{PREFIX}max-font-size: " + Theme.Typography.MaxFontSize + ";");
            theme.AppendLine($"{PREFIX}min-font-size: " + Theme.Typography.MinFontSize + ";");
            theme.AppendLine($"{PREFIX}primary-font-family: " + Theme.Typography.PrimaryFontFamily + ";");
            theme.AppendLine($"{PREFIX}heading-font-family: " + Theme.Typography.HeadingFontFamily + ";");
            theme.AppendLine($"{PREFIX}code-font-family: " + Theme.Typography.CodeFontFamily + ";");
            theme.AppendLine($"{PREFIX}base-line-height: " + Theme.Typography.BaseLineHeight + ";");
            theme.AppendLine($"{PREFIX}small-line-height: " + Theme.Typography.SmallLineHeight + ";");
            theme.AppendLine($"{PREFIX}large-line-height: " + Theme.Typography.LargeLineHeight + ";");
            theme.AppendLine($"{PREFIX}md-font-weight: " + Theme.Typography.MediumFontWeight + ";");
            theme.AppendLine($"{PREFIX}bold-font-weight: " + Theme.Typography.BoldFontWeight + ";");
            theme.AppendLine($"{PREFIX}extra-font-weight: " + Theme.Typography.ExtraFontWeight + ";");
            theme.AppendLine($"{PREFIX}body-font-style: " + Theme.Typography.BodyTextAlign + ";");
            theme.AppendLine($"{PREFIX}heading-font-style: " + Theme.Typography.HeadingFontStyle + ";");
            theme.AppendLine($"{PREFIX}heading-font-weight: " + Theme.Typography.HeadingFontWeight + ";");
            theme.AppendLine($"{PREFIX}heading-mb: " + Theme.Typography.HeadingMarginBottom + ";");
            theme.AppendLine($"{PREFIX}paragraph-mb: " + Theme.Typography.ParagraphMarginBottom + ";");
            theme.AppendLine($"{PREFIX}link-decoration: " + Theme.Typography.LinkDecoration + ";");
            theme.AppendLine($"{PREFIX}link-decoration-hover: " + Theme.Typography.LinkDecorationHover + ";");
            theme.AppendLine($"{PREFIX}link-decoration-focus: " + Theme.Typography.LinkDecorationFocus + ";");
        }

        private void GenerateThemeColors(StringBuilder theme)
        {
            theme.AppendLine($"{PREFIX}bg-color: #" + Theme.Palette.Bg + ";");
            theme.AppendLine($"{PREFIX}bg-color-dark: #" + Theme.Palette.BgDark + ";");
            theme.AppendLine($"{PREFIX}bg-color-darker: #" + Theme.Palette.BgDarker + ";");
            theme.AppendLine($"{PREFIX}bg-color-darkest: #" + Theme.Palette.BgDarkest + ";");

            theme.AppendLine($"{PREFIX}txt-color: #" + Theme.Palette.Text + ";");
            theme.AppendLine($"{PREFIX}txt-color-light: #" + Theme.Palette.TextLight + ";");
            theme.AppendLine($"{PREFIX}txt-color-dark: #" + Theme.Palette.TextDark + ";");
            theme.AppendLine($"{PREFIX}txt-color-inverted: #" + Theme.Palette.TextInverted + ";");
            theme.AppendLine($"{PREFIX}heading-color: #" + Theme.Palette.Heading + ";");
            foreach (var color in Theme.Palette.ColorsDict.Keys)
            {
                theme.AppendLine($"{PREFIX}color-{color}-light: #" + Theme.Palette.ColorsDict[color].Tint + ";");
                theme.AppendLine($"{PREFIX}color-{color}-primary: #" + Theme.Palette.ColorsDict[color].Value + ";");
                theme.AppendLine($"{PREFIX}color-{color}-dark: #" + Theme.Palette.ColorsDict[color].Shade + ";");
                theme.AppendLine($"{PREFIX}color-{color}-darker: #" + Theme.Palette.ColorsDict[color].Shadier + ";");
            }

            theme.AppendLine($"{PREFIX}tap-highlight-color: " + Theme.Palette.TapHighlight + ";");
            theme.AppendLine($"{PREFIX}link-color: #" + Theme.Palette.Link + ";");
            theme.AppendLine($"{PREFIX}link-color__hover: #" + Theme.Palette.LinkHover + ";");
            theme.AppendLine($"{PREFIX}link-color__focus: #" + Theme.Palette.LinkFocus + ";");

        }
    }
}