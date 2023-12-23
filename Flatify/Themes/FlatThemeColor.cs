// Flatify
// FlatColor.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 19-12-2023
using System.Text.RegularExpressions;

namespace Flatify.Themes
{
    public class FlatThemeColor
    {
        private Double _shadeStrength = 0.15;
        private Double _tintStrength = 0.15;
        private string _value;


        public FlatThemeColor(String hex, Double lightenStrength = 0.15D, Double darkenStrength = 0.1D)
        {
            TintStrength = lightenStrength;
            ShadeStrength = darkenStrength;

            if (ValidateHex(hex))
                Value = hex;
            else
                Value = "000000";

            R = HexToRgb(Value)[0];
            G = HexToRgb(Value)[1];
            B = HexToRgb(Value)[2];
        }


        public FlatThemeColor(Int32 r, Int32 g, Int32 b)
        {
            Value = RgbToHex(new byte[] { (byte)r, (byte)g, (byte)b });
            R = r;
            G = g;
            B = b;
        }

        public FlatThemeColor(Int32 r, Int32 g, Int32 b, Int32 a = 255)
        {
            Value = RgbaToHex(new byte[] { (byte)r, (byte)g, (byte)b, (byte)a });
            R = r;
            G = g;
            B = b;
            A = a;
        }
        public string Value { get => _value; set => _value = value; }
        public String Tint => TintHex(Value, TintStrength);
        public String Shade => ShadeHex(Value, ShadeStrength);
        public String Shadier => ShadeHex(Value, ShadeStrength + ShadeStrength / 2);

        public Double TintStrength
        {
            get
            {
                if (_tintStrength > 1)
                    return 1;
                if (_tintStrength < 0)
                    return 0;

                return _tintStrength;
            }
            protected set => _tintStrength = value;
        }

        public Double ShadeStrength
        {
            get
            {
                if (_shadeStrength > 1)
                    return 1;
                if (_shadeStrength < 0)
                    return 0;

                return _shadeStrength;
            }
            protected set => _shadeStrength = value;
        }

        public int R { get; set; } = 0;
        public int G { get; set; } = 0;
        public int B { get; set; } = 0;
        public int A { get; set; } = 255;

        // Converts rbg to hex
        private string RgbToHex(byte[] rgb)
        {
            return String.Format("{0:X2}{1:X2}{2:X2}", rgb[0], rgb[1], rgb[2]);
        }

        // Converts rgba to hex
        private string RgbaToHex(byte[] rgba)
        {
            return String.Format("{0:X2}{1:X2}{2:X2}{3:X2}", rgba[0], rgba[1], rgba[2], rgba[3]);
        }

        // Converts hex to rgba
        private byte[] HexToRgba(string hex)
        {
            byte[] rgba = new byte[4];
            rgba[0] = Convert.ToByte(hex.Substring(0, 2), 16);
            rgba[1] = Convert.ToByte(hex.Substring(2, 2), 16);
            rgba[2] = Convert.ToByte(hex.Substring(4, 2), 16);
            rgba[3] = Convert.ToByte(hex.Substring(6, 2), 16);
            return rgba;
        }

        // Converts hex to rgb
        private byte[] HexToRgb(string hex)
        {
            byte[] rgb = new byte[3];
            rgb[0] = Convert.ToByte(hex.Substring(0, 2), 16);
            rgb[1] = Convert.ToByte(hex.Substring(2, 2), 16);
            rgb[2] = Convert.ToByte(hex.Substring(4, 2), 16);
            return rgb;
        }

        // Converts alpha hex to rgba
        private byte[] AlphaHexToRgba(string hex)
        {
            byte[] rgba = new byte[4];
            rgba[0] = Convert.ToByte(hex.Substring(0, 2), 16);
            rgba[1] = Convert.ToByte(hex.Substring(2, 2), 16);
            rgba[2] = Convert.ToByte(hex.Substring(4, 2), 16);
            rgba[3] = Convert.ToByte(hex.Substring(6, 2), 16);
            return rgba;
        }

        // Inverts hex color
        public string InvertHex(string hex)
        {
            byte[] rgb = HexToRgb(hex);
            rgb[0] = (byte)(255 - rgb[0]);
            rgb[1] = (byte)(255 - rgb[1]);
            rgb[2] = (byte)(255 - rgb[2]);
            return String.Format("{0:X2}{1:X2}{2:X2}", rgb[0], rgb[1], rgb[2]);
        }

        // Shades hex color by percentage
        public string ShadeHex(string hex, double percent)
        {
            byte[] rgb = HexToRgb(hex);
            rgb[0] = (byte)(rgb[0] * percent);
            rgb[1] = (byte)(rgb[1] * percent);
            rgb[2] = (byte)(rgb[2] * percent);
            return String.Format("{0:X2}{1:X2}{2:X2}", rgb[0], rgb[1], rgb[2]);
        }

        // Tints hex color by percentage
        public string TintHex(string hex, double percent)
        {
            byte[] rgb = HexToRgb(hex);
            rgb[0] = (byte)(rgb[0] + (255 - rgb[0]) * percent);
            rgb[1] = (byte)(rgb[1] + (255 - rgb[1]) * percent);
            rgb[2] = (byte)(rgb[2] + (255 - rgb[2]) * percent);
            return String.Format("{0:X2}{1:X2}{2:X2}", rgb[0], rgb[1], rgb[2]);
        }

        // Validates hex color
        private bool ValidateHex(string hex)
        {
            Regex regex = new Regex(@"^[a-fA-F0-9]{6}$");
            return regex.IsMatch(hex);
        }
    }
}