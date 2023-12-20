// Flatify
// Palette.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 19-12-2023
using System.Text.RegularExpressions;

namespace Flatify.Themes
{
    /// <summary>
    /// Describes a color palette for theming.
    /// </summary>
    /// <remarks>For now, values must be provided as hex values.</remarks>
    public class Palette
    {
        private Dictionary<string, FlatColor> _colorsDict = new Dictionary<String, FlatColor>()
                                                            {
                                                                { "blue", new FlatColor("1cb0f6") },
                                                                { "green", new FlatColor("58cc02") },
                                                                { "yellow", new FlatColor("ffde00") },
                                                                { "orange", new FlatColor("ff9600") },
                                                                { "red", new FlatColor("ff4b4b") },
                                                                { "purple", new FlatColor("c164ff") },
                                                                { "pink", new FlatColor("ff86d0") },
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
        public string TextLight { get => new FlatColor(Text).TintHex(Text, 0.5); }
        public string TextDark { get => new FlatColor(Text).ShadeHex(Text, 0.25); }
        public string TextInverted { get => Bg; }
        public string Heading { get => Text; }
        public string Link { get => ColorsDict["accent"].Value; }
        public string LinkHover { get => ColorsDict["accent"].Tint; }
        public string LinkFocus { get => ColorsDict["accent"].Shadier; }
        public string TapHighlight { get => "transparent"; }
        public Dictionary<string, FlatColor> ColorsDict { get => AppendColorDict(); }

        private Dictionary<string, FlatColor> AppendColorDict()
        {
            _colorsDict["blue"] = new FlatColor(Blue);
            _colorsDict["green"] = new FlatColor(Green);
            _colorsDict["yellow"] = new FlatColor(Yellow);
            _colorsDict["orange"] = new FlatColor(Orange);
            _colorsDict["red"] = new FlatColor(Red);
            _colorsDict["purple"] = new FlatColor(Purple);
            _colorsDict["pink"] = new FlatColor(Pink);

            var dict = new Dictionary<String, FlatColor>();
            foreach (var colorPair in _colorsDict)
            {
                dict.Add(colorPair.Key, colorPair.Value);
            }
            dict.Add("accent", new FlatColor(_colorsDict["blue"].Value));
            dict.Add("success", new FlatColor(_colorsDict["green"].Value));
            dict.Add("info", new FlatColor(_colorsDict["blue"].Tint));
            dict.Add("warning", new FlatColor(_colorsDict["orange"].Tint));
            dict.Add("danger", new FlatColor(_colorsDict["red"].Tint));
            dict.Add("light", new FlatColor(Bg));
            dict.Add("dark", new FlatColor(Text));
            dict.Add("heading", new FlatColor(Heading));
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