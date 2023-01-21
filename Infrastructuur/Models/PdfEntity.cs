using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuur.Models
{
    public class PdfEntity
    {
        public List<PdfContent<string, string>>? Images { get; set; } = new List<PdfContent<string, string>>();
        public List<PdfContent<string, string>>? Content { get; set; } = new List<PdfContent<string, string>>();
        public List<PdfContent<string, string>>? Hrefs { get; set; } = new List<PdfContent<string, string>>();
        public string? TheFileBase64 { get; set; }
    }
}
