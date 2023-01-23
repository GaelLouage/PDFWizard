using API.Data;
using API.Services.Classes;
using API.Services.Interfaces;
using Infrastructuur.WebScrapper;

namespace API.Bootstrapper
{
    public static class BootstrapService
    {
        public static IServiceCollection AddWebScrapperServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<WebScrapper>()
                .AddSingleton<PdfFileDbContext>()
                .AddScoped<IExportService, ExportService>()
                .AddScoped<IPdfFileService, PdfFileService>()
                .AddScoped<IWebScrapperService, WebScrapperService>();
        }
    }
}
