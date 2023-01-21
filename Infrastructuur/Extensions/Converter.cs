using Infrastructuur.Pdfs;
using PdfSharpCore.Drawing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuur.Extensions
{
    public static class Converter
    {
        public static async Task<string> GetBase64String(this Task<byte[]> file) =>
            Convert.ToBase64String(await file);
        
    }

}
