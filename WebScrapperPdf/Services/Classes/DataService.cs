using Infrastructuur.Dtos;
using Infrastructuur.Models;
using Microsoft.JSInterop;
using System.Reflection.Metadata;
using System;
using System.Text;
using System.Text.Json;
using WebScrapperPdf.Services.Interfaces;
using System.IO;
using System.Net.Http.Json;

namespace WebScrapperPdf.Services.Classes
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;
        
        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultDto> GetDataByTitleAsync(string title, string language)
        {
            return await JsonSerializer.DeserializeAsync<ResultDto>
             (await _httpClient.GetStreamAsync($"https://localhost:7152/api/WebScrapper/GetAllDataFromName/{title}/{language}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<byte[]> DownloadPdfFileAsync(PdfEntity pdfFile)
        {

            var pdfData =
              new StringContent(JsonSerializer.Serialize(pdfFile), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"https://localhost:7152/api/Pdf/", pdfData);

            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<List<LanguageEntity<string, string>>> GetLanguages()
        {
            return (await _httpClient.GetFromJsonAsync<List<LanguageEntity<string, string>>>("data/Languages.json")).ToList();
        }
    }
}
