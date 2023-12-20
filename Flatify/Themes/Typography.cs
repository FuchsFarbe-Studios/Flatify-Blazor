// Flatify
// Typography.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 19-12-2023
namespace Flatify.Themes
{
    public class BaseTypo
    {

    }

    public class Typography
    {
        public string MaxFontSize { get; set; } = "100%";
        public string MinFontSize { get; set; } = "85%";
        public string PrimaryFontFamily { get; set; } = "Nunito, sans-serif";
        public string HeadingFontFamily { get; set; } = "Nunito, sans-serif";
        public string CodeFontFamily { get; set; } = "Fira Code, Menlo, Monaco, Consolas, Liberation Mono, Courier New, monospace";
        public string BaseLineHeight { get; set; } = "1.5";
        public string SmallLineHeight { get; set; } = "1.2";
        public string LargeLineHeight { get; set; } = "1.8";
        public string MediumFontWeight { get; set; } = "600";
        public string BoldFontWeight { get; set; } = "700";
        public string ExtraFontWeight { get; set; } = "900";
        public string BodyTextAlign { get; set; } = "initial";
        public string HeadingFontStyle { get; set; } = "normal";
        public string HeadingFontWeight { get; set; } = "bold";
        public string HeadingMarginBottom { get; set; } = "0.5em";
        public string ParagraphMarginBottom { get; set; } = "2em";
        public string LinkDecoration { get; set; } = "none";
        public string LinkDecorationHover { get; set; } = "underline 0.125em currentColor";
        public string LinkDecorationFocus { get; set; } = "none";
    }
}