using PdfSharpCore.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuur.Extensions
{
    public static class ExportServiceExtensions
    {
        public static XSolidBrush SetColor(this string textcolor)
        {
            return textcolor switch
            {
                "Red" => XBrushes.Red,
                "Black" => XBrushes.Black,
                "Green" => XBrushes.Green,
                "Blue" => XBrushes.Blue,
                "White" => XBrushes.White,
                _ => XBrushes.Black,
            };
        }
        public static XStringFormat PositionText(this string textPosition)
        {
            return textPosition switch
            {
                "TopLeft" => XStringFormats.TopLeft,
                "TopRight" => XStringFormats.TopRight,
                "TopCenter" => XStringFormats.TopCenter,
                "BottomLeft" => XStringFormats.BottomLeft,
                "BottomRight" => XStringFormats.BottomRight,
                _ => XStringFormats.TopLeft
            };
        }
    }
}
