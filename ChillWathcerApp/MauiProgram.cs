using Microsoft.Extensions.Logging;
using ChillWathcerApp.Services;
using ChillWathcerApp.Views;
using ChillWathcerApp.ViewModels;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace ChillWathcerApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseSkiaSharp(true)
			.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<APIService>();
		builder.Services.AddTransient<ReadingsView>();
        builder.Services.AddTransient<ReadingsViewModel>();
        builder.Services.AddTransient<ControlsView>();
        builder.Services.AddTransient<ControlViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
