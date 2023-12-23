// Flatify
// Palette.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 19-12-2023
namespace Flatify.Themes
{
    /// <summary>
    /// Describes a color palette for theming.
    /// </summary>
    /// <remarks>For now, values must be provided as hex values.</remarks>
    public class Palette
    {
        private Dictionary<String, FlatThemeColor> _colorsDict = new Dictionary<String, FlatThemeColor>
                                                                 {
                                                                     { "blue", new FlatThemeColor("1cb0f6") },
                                                                     { "green", new FlatThemeColor("58cc02") },
                                                                     { "yellow", new FlatThemeColor("ffde00") },
                                                                     { "orange", new FlatThemeColor("ff9600") },
                                                                     { "red", new FlatThemeColor("ff4b4b") },
                                                                     { "purple", new FlatThemeColor("c164ff") },
                                                                     { "pink", new FlatThemeColor("ff86d0") }
                                                                 };

        public string Blue { get; set; } = "1cb0f6";
        public string Green { get; set; } = "58cc02";
        public string Yellow { get; set; } = "ffde00";
        public string Orange { get; set; } = "ff9600";
        public string Red { get; set; } = "ff4b4b";
        public string Purple { get; set; } = "c164ff";
        public string Pink { get; set; } = "ff86d0";
        public string Bg { get; set; } = "ffffff";
        public string BgDark { get; set; } = "f1f4f7";
        public string BgDarker { get; set; } = "ced9e3";
        public string BgDarkest { get; set; } = "809cb6";
        public string Text { get; set; } = "2e4051";
        public String TextLight => new FlatThemeColor(Text).TintHex(Text, 0.5);
        public String TextDark => new FlatThemeColor(Text).ShadeHex(Text, 0.25);
        public string TextInverted { get => Bg; }
        public string Heading { get => Text; }
        public string Link { get => ColorsDict["accent"].Value; }
        public string LinkHover { get => ColorsDict["accent"].Tint; }
        public string LinkFocus { get => ColorsDict["accent"].Shadier; }
        public string TapHighlight { get => "transparent"; }
        public Dictionary<String, FlatThemeColor> ColorsDict => AppendColorDict();

        private Dictionary<String, FlatThemeColor> AppendColorDict()
        {
            _colorsDict["blue"] = new FlatThemeColor(Blue);
            _colorsDict["green"] = new FlatThemeColor(Green);
            _colorsDict["yellow"] = new FlatThemeColor(Yellow);
            _colorsDict["orange"] = new FlatThemeColor(Orange);
            _colorsDict["red"] = new FlatThemeColor(Red);
            _colorsDict["purple"] = new FlatThemeColor(Purple);
            _colorsDict["pink"] = new FlatThemeColor(Pink);

            var dict = new Dictionary<String, FlatThemeColor>();
            foreach (var colorPair in _colorsDict)
            {
                dict.Add(colorPair.Key, colorPair.Value);
            }
            dict.Add("accent", new FlatThemeColor(_colorsDict["blue"].Value));
            dict.Add("success", new FlatThemeColor(_colorsDict["green"].Value));
            dict.Add("info", new FlatThemeColor(_colorsDict["blue"].Tint));
            dict.Add("warning", new FlatThemeColor(_colorsDict["orange"].Tint));
            dict.Add("danger", new FlatThemeColor(_colorsDict["red"].Tint));
            dict.Add("light", new FlatThemeColor(Bg));
            dict.Add("dark", new FlatThemeColor(Text));
            dict.Add("heading", new FlatThemeColor(Heading));
            return dict;
        }

        // Converts hex to RGB
        private byte[] HexToRgb(string hex)
        {
            byte[] rgb = new byte[3];
            rgb[0] = Convert.ToByte(hex.Substring(0, 2), 16);
            rgb[1] = Convert.ToByte(hex.Substring(2, 2), 16);
            rgb[2] = Convert.ToByte(hex.Substring(4, 2), 16);
            return rgb;
        }
    }
}