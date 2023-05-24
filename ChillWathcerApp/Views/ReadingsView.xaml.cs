using ChillWathcerApp.ViewModels;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using ChillWathcerApp.Models;
using System.Collections.ObjectModel;

namespace ChillWathcerApp.Views;

public partial class ReadingsView : ContentPage
{
    public readonly ReadingsViewModel readingsViewModel;

    public ReadingsView(ReadingsViewModel model)
    {
        InitializeComponent();
        readingsViewModel = model;
        BindingContext = readingsViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        readingsViewModel.GetTelemetryCommand.Execute(null);
        readingsViewModel.UpdateChartCommand.Execute(null);
    }

    private void TimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        readingsViewModel.UpdateChartCommand.Execute(null);
    }
}