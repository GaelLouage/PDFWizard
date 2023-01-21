using API.Services.Interfaces;
using Infrastructuur.Extensions;
using Infrastructuur.Models;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.Annotations;
using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace API.Services.Classes
{
    public class ExportService : IExportService
    {
        public async Task<byte[]> CreatePDF(PdfEntity pdfEntity)
        {
            try
            {
                if (pdfEntity == null)
                {
                    return new byte[0];
                }
                //Create PDF Document
                PdfDocument document = new PdfDocument();
                //You will have to add Page in PDF Document
                PdfPage page = document.AddPage();

                //For drawing in PDF Page you will nedd XGraphics Object
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XTextFormatter tf = new XTextFormatter(gfx);

                //PdfPage page2 = document.AddPage();
                await PrintImages(pdfEntity, gfx).ConfigureAwait(false);
                PrintPageContent(pdfEntity, gfx, tf);

                return SaveDocumentInstream(document);
            }
            catch
            {
                // something went wrong
                return null;
            }
        }
        private static byte[] SaveDocumentInstream(PdfDocument document)
        {
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            return stream.ToArray();
        }
        private void PrintPageContent(PdfEntity pdfEntity, XGraphics gfx, XTextFormatter tf)
        {
            if (pdfEntity.Content != null)
            {
                foreach (var node in pdfEntity.Content)
                {
                    var fontText = new XFont(node.FontFamily, node.FontSize * 16, node.FontStyle);
                    XRect rect = new XRect(node.PosX, node.PosY, node.Width, node.Height);
                    gfx.DrawRectangle(node.RectangleColor.SetColor(), rect);
                    tf.DrawString(node.Value.ToString(), fontText, node.BrushTextColor.SetColor(), rect, XStringFormats.TopLeft);
                }
            }
        }
        private static async Task PrintImages(PdfEntity pdfEntity, XGraphics gfx)
        {
            if (pdfEntity.Images != null)
            {
                foreach (var image in pdfEntity.Images)
                {
                    var imgS = image.Value.Replace("src://", "https://");
                    using (var client = new HttpClient())
                    {
                        using (var response = await client.GetAsync(imgS))
                        {
                            byte[] imageBytes =
                                await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                            var memoStream = new MemoryStream(imageBytes);
                            XImage img = XImage.FromStream(() => memoStream);
                            gfx.DrawImage(img, image.PosX, image.PosY);
                        }
                    }
                }
            }
        }
  
    }
}
