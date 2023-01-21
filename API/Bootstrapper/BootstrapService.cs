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
                .AddScoped<IExportService, ExportService>()
                .AddScoped<IWebScrapperService, WebScrapperService>();
        }
    }
}
