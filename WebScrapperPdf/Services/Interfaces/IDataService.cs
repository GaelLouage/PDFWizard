using Infrastructuur.Dtos;
using Infrastructuur.Models;

namespace WebScrapperPdf.Services.Interfaces
{
    public interface IDataService
    {
        Task<ResultDto> GetDataByTitleAsync(string title, string language);
        Task<byte[]> DownloadPdfFileAsync(PdfEntity pdfFile);
        Task<List<LanguageEntity<string, string>>> GetLanguages();
    }
}