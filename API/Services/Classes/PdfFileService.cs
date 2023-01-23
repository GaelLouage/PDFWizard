using API.Data;
using API.Services.Interfaces;
using Infrastructuur.Models;

namespace API.Services.Classes
{
    public class PdfFileService : IPdfFileService
    {
        private readonly PdfFileDbContext _pdfFileDbContext;

        public PdfFileService(PdfFileDbContext pdfFileDbContext)
        {
            _pdfFileDbContext = pdfFileDbContext;
        }

        public async Task<bool> AddPdfFile(PdfFileEntity<Guid, string> pdfFile) =>
            await _pdfFileDbContext.AddPdfFileAsync(pdfFile);


        public async Task<List<PdfFileEntity<Guid, string>>> GetAllPdfFiles() =>
            await _pdfFileDbContext.GetAllPdfFiles();
            
    }
}
