using ChillWathcerApp.ViewModels;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using ChillWathcerApp.Models;

namespace ChillWathcerApp.Views;

public partial class ReadingsView : ContentPage
{
	public readonly ReadingsViewModel ReadingsViewModel;
    
    public ReadingsView(ReadingsViewModel model)
	{
		InitializeComponent();
		ReadingsViewModel = model;
		BindingContext = ReadingsViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		ReadingsViewModel.GetTelemetryCommand.Execute(null);

        List<double> temps = new List<double>();
        List<double> humits = new List<double>();

        foreach (Telemetry tele in ReadingsViewModel.Telemetries)
        {
            temps.Add(tele.Temperature);
            humits.Add(tele.Humidity);
        }
        ReadingsViewModel.Series = new ISeries[]
        {
            new LineSeries<double>
            {
                Values = temps.ToArray(),
                Fill = null
            }
        };
    }
}