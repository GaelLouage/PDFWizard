using Infrastructuur.Models;

namespace API.Services.Interfaces
{
    public interface IExportService
    {
        Task<byte[]> CreatePDF(PdfEntity pdfEntity);
    }
}
