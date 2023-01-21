using API.Services.Classes;
using API.Services.Interfaces;
using Infrastructuur.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly IExportService _exportService;
        public PdfController(IExportService exportService)
        {
            _exportService = exportService;
        }
        [HttpPost]
        public async Task<IActionResult> PostPdfFile(PdfEntity pdfFile)
        {
            Response.Headers.Add("Content-Disposition", "attachment; filename=.pdf");
            return File(await _exportService.CreatePDF(pdfFile), "application/pdf");
        }
    }
}
