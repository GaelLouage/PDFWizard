using Infrastructuur.Models;
using Microsoft.AspNetCore.Components;
using WebScrapperPdf.Services.Interfaces;

namespace WebScrapperPdf.Pages
{
    public partial class PdfFilesComponent : ComponentBase
    {
        [Inject]
        public IDataService DataService { get; set; }
        public List<PdfFileEntity<Guid, string>> Files { get; set; } = new List<PdfFileEntity<Guid, string>>();
        protected override async Task OnInitializedAsync()
        {
            Files = (await DataService.GetAllfiles()).ToList();
        }
    }
}
