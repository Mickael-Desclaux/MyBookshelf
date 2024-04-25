using Microsoft.Extensions.Logging;
using MyBookshelf.Core.Data;
using MyBookshelf.Core.Model;
using MyBookshelf.Core.Repository;
using MyBookshelf.Core.Service;

namespace MyBookshelf.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.AddScoped<IRepository<Book>, Repository<Book>>();
            builder.Services.AddScoped<IBookService, BookService>();

            builder.Services.AddDbContext<AppDbContext>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
