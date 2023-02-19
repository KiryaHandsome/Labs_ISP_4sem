using Microsoft.Extensions.DependencyInjection;
using Project.Services;

namespace Project;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddTransient<IDbService, SQLiteService>();
        builder.Services.AddSingleton<HotelService>();

       /* builder.Services.AddHttpClient<IRateService>(opt =>
            opt.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates"));*/

        var baseAddress = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5091"
                : "https://localhost:7091";

        builder.Services.AddHttpClient<IRateService, RateService>(opt =>
               opt.BaseAddress = new Uri(baseAddress));


        builder.Services.AddTransient<IRateService, RateService>();
        builder.Services.AddSingleton<CurrencyConventer>();
        return builder.Build();
    }
}
