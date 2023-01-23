using Infrastructuur.Models;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace API.Data
{
    public class PdfFileDbContext
    {
        private string file = Path.Combine(Directory.GetCurrentDirectory() + @"\Data\pdfFile.json");
        public async Task<List<PdfFileEntity<Guid, string>>>? GetAllPdfFiles() => JsonConvert.DeserializeObject<List<PdfFileEntity<Guid, string>>>(await File.ReadAllTextAsync(file));
        // add pizza by id
        public async Task<bool> AddPdfFileAsync(PdfFileEntity<Guid, string> pdfFile)
        {
            var oldCount = (await GetAllPdfFiles()).Count();
      
            
                var pdfFiles = await GetAllPdfFiles();

                pdfFiles.Add(pdfFile);
                var updatePizzafile = JsonConvert.SerializeObject(pdfFiles);
                File.WriteAllText(file, updatePizzafile);
                return (await GetAllPdfFiles()).Count() > oldCount;
        
        }
    }
}
