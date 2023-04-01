using API.Services.Interfaces;
using HtmlAgilityPack;
using Infrastructuur.Dtos;
using Infrastructuur.Models;
using Infrastructuur.WebScrapper;

namespace API.Services.Classes
{
    public class WebScrapperService : IWebScrapperService
    {
        private readonly WebScrapper _webScrapper;

        public WebScrapperService(WebScrapper webScrapper)
        {
            _webScrapper = webScrapper;
        }
        public async Task<ResultDto> GetDataFromScrappingAsync(WebsiteEntity website)
        {
            var result = new ResultDto();
            if (string.IsNullOrEmpty(website.Url))
            {
                result.Errors.Add($"No url found with name {website.Url}");
                return result;
            }
            var data = new List<Dictionary<string, string>>();

            foreach (var htmlNode in HtmlTag.htmlNodes) 
            {
                website.TagName = htmlNode;
                data.Add(await _webScrapper.GetByTagNameAsync(website));
            }
            // place all the data from nodes inside the result dictionary
            result.Data = data.SelectMany(d => d)
                .GroupBy(d => d.Key)
                .ToDictionary(d => d.Key, d => d.First().Value);
            return result;
        }
    }
}
