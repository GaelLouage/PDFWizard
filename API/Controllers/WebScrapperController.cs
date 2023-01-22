using API.Services.Interfaces;
using Infrastructuur.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebScrapperController : ControllerBase
    {
        private readonly IWebScrapperService _webScrapperService;

        public WebScrapperController(IWebScrapperService webScrapperService)
        {
            _webScrapperService = webScrapperService;
        }


        [HttpGet("GetAllDataFromName/{title}/{language}")]
        public async Task<IActionResult> GetAllDataFromUrl(string title, string language)
        {
            
            var web = new WebsiteEntity();
            web.Language = language ?? "en";
            web.Url = $"https://{language}.wikipedia.org/wiki/" + string.Join("_" ,title);
            return Ok(await _webScrapperService.GetDataFromScrappingAsync(web));
        }
    }
}
