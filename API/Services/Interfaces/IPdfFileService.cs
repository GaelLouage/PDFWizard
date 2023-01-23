using Infrastructuur.Models;

namespace API.Services.Interfaces
{
    public interface IPdfFileService
    {
        Task<bool> AddPdfFile(PdfFileEntity<Guid, string> pdfFile);
        Task<List<PdfFileEntity<Guid,string>>> GetAllPdfFiles();
    }
}
