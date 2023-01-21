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


        [HttpGet("GetAllDataFromName/{title}")]
        public async Task<IActionResult> GetAllDataFromUrl(string title)
        {
            
            var web = new WebsiteEntity();
            web.Url = $"https://nl.wikipedia.org/wiki/" + string.Join("_" ,title);
            return Ok(await _webScrapperService.GetDataFromScrappingAsync(web));
        }
    }
}
