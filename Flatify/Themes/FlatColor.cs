// Flatify
// FlatColor.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 19-12-2023
namespace Flatify.Themes
{
    public class FlatColor
    {
        public ColorFormat Format { get; set; } = ColorFormat.RGB;
        public string Hex { get; set; } = "#000000";
        public byte R { get; set; } = 0;
        public byte G { get; set; } = 0;
        public byte B { get; set; } = 0;
        public byte A { get; set; } = 255;

        public FlatColor(byte r, byte g, byte b, byte a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}