using API.Services.Interfaces;
using Infrastructuur.Extensions;
using Infrastructuur.Models;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.Annotations;
using SixLabors.ImageSharp;
using System;
using System.Diagnostics;
using System.Drawing;
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
                    gfx.RotateTransform(node.RotateTransForm);
                    gfx.SkewAtTransform(node.ShearX, node.ShearY, node.CenterX, node.CenterY);
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
                                /*The ConfigureAwait(false) method is used to tell the compiler not to resume execution on the captured context when the awaited task completes.
                                When an async method is called, the current context (e.g. the current thread or synchronization context) is captured, and the method continues execution on a different context, 
                                such as a thread pool thread. When the awaited task completes and the method resumes execution, it resumes on the captured context, if that context is still available.*/
                                await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                            var memoStream = new MemoryStream(imageBytes);
                            //draw rounded image 
                         
                            XImage img = XImage.FromStream(() => memoStream);
                            var rect = new XRect(image.PosX, image.PosY, image.Width, image.Height);
                            gfx.RotateTransform(image.RotateTransForm);
                            gfx.SkewAtTransform(image.ShearX, image.ShearY,image.CenterX,image.CenterY);
                            gfx.DrawImage(img, image.PosX, image.PosY,image.Width,image.Height);
                        }
                    }
                }
            }
        }
  
    }
}
