using Infrastructuur.Dtos;
using Infrastructuur.Models;

namespace API.Services.Interfaces
{
    public interface IWebScrapperService
    {
        Task<ResultDto> GetDataFromScrappingAsync(WebsiteEntity website);
    }
}