using Infrastructuur.Dtos;
using Infrastructuur.Extensions;
using Infrastructuur.Models;
using Infrastructuur.Pdfs;
using Microsoft.AspNetCore.Components;
using WebScrapperPdf.Services.Interfaces;

namespace WebScrapperPdf.Components
{
    public partial class TableComponent : ComponentBase
    {
        private PdfContent<string, string> pdf = new PdfContent<string, string>();
        [Inject]
        public IDataService DataService { get; set; }
        [Parameter]
        public Dictionary<string, string>? Items { get; set; } = new Dictionary<string, string>();

        [Parameter]
        public string TheKey { get; set; }
        [Parameter]
        public  string TablePageIndex { get; set; }
        public string GetHtmlNode() => Items.FirstOrDefault(x => x.Key.Contains(TheKey)).Key is not null ?
                    Items.FirstOrDefault(x => x.Key.Contains(TheKey)).Key.Split('-')[0] : "";

        private string TableContent = "table-content-hide";
        private bool tableIsClicked = false;
        public void DisplayTable()
        {
            tableIsClicked = !tableIsClicked;
            if (tableIsClicked)
            {
                TableContent = "table-content-show";
            }
            else
            {
                TableContent = "table-content-hide";
            }
        }
        public async Task AddItemAsync(KeyValuePair<string, string> item)
        {
            if (item.Key.StartsWith("img"))
            {
                Pdf.File.Images.Add(new PdfContent<string, string> { Key = item.Key, Value = item.Value });
            }
            else if (item.Key.StartsWith("a"))
            {
                Pdf.File.Hrefs.Add(new PdfContent<string, string> { Key = item.Key, Value = item.Value });
            }
            else
            {
                Pdf.File.Content.Add(new PdfContent<string, string> { Key = item.Key, Value = item.Value });
            }
          
            Pdf.File.TheFileBase64 = await DataService.DownloadPdfFileAsync(Pdf.File).GetBase64String();
        }
     
        public async Task RemoveAsync(KeyValuePair<string, string> item)
        {
            pdf = new PdfContent<string, string> { Key = item.Key, Value = item.Value };
            if (item.Key.StartsWith("img"))
            {
                RemovePdfContents(Pdf.File.Images);
                //Pdf.File.Images.Remove(Pdf.File.Images.FirstOrDefault(k => k.Key == pdf.Key));
            }
            else if (item.Key.StartsWith("a"))
            {
                RemovePdfContents(Pdf.File.Hrefs);
            }
            else
            {
                RemovePdfContents(Pdf.File.Content);
            }
            Pdf.File.TheFileBase64 = await DataService.DownloadPdfFileAsync(Pdf.File).GetBase64String();
        }
        private void RemovePdfContents(List<PdfContent<string,string>> PdfConent)
        {
            for (int i = 0; i < PdfConent.Count; i++)
            {
                if (PdfConent[i].Key == pdf.Key)
                {
                    PdfConent.RemoveAt(i);
                }
            }
        }
    }
}
