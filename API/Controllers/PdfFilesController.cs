using API.Services.Interfaces;
using Infrastructuur.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfFilesController : ControllerBase
    {
        private readonly IPdfFileService _pdfFileService;

        public PdfFilesController(IPdfFileService pdfFileService)
        {
            _pdfFileService = pdfFileService;
        }

        [HttpGet("PdfFiles")]
        public async Task<IActionResult> GetAllPdfFiles()
        {
            return Ok(await _pdfFileService.GetAllPdfFiles());
        }

        [HttpPost("AddPdfFile")]
        public async Task<IActionResult> AddPdfFile([FromBody]PdfFileEntity<Guid,string> pdfFile)
        {
            return Ok(await _pdfFileService?.AddPdfFile(pdfFile));
        }
    }
}
