using PdfSharpCore.Drawing;

namespace Infrastructuur.Models
{
    public class PdfContent<Tkey, Tvalue>  : SkewContent
    {
        public Tkey Key { get; set; }
        public Tvalue Value { get; set; }
        public double PosX { get; set; } = 0;
        public double PosY { get; set; } = 0;
        public double Width { get; set; } = 500; 
        public double Height { get; set; } = 250;
        public string RectangleColor { get; set; } = "White";
        //public string StringFormat { get; set; }
        public string FontFamily { get; set; } = "Verdana";
        public string XStringFormats { get; set; }
        public double FontSize { get; set; } = 0.7;
        public double RotateTransForm { get; set; } = 0;
        public string BrushTextColor { get; set; } = "Black";
        public XFontStyle FontStyle { get; set; } = XFontStyle.Regular;
        public bool IsClicked { get; set; } = false;
    }
    public class SkewContent
    {
        public double ShearX { get; set; } = 0;
        public double ShearY { get; set; } = 0;
        public double CenterX { get; set; } = 0;
        public double CenterY { get; set; } = 0;
    }
}
