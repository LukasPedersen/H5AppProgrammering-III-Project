using ChillWathcerApp.Models;
using ChillWathcerApp.Services;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using Microsoft.Maui.Controls.Internals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace ChillWathcerApp.ViewModels
{
    public partial class ReadingsViewModel : ViewModel
    {
        private readonly APIService _service;

        public ReadingsViewModel(APIService apiService)
        {
            Title = "Readings";
            _service = apiService;
        }

        [ObservableProperty]
        private TimeSpan selectedFromTime = new TimeSpan((DateTime.Now.Hour - 1), DateTime.Now.Minute, DateTime.Now.Second);

        [ObservableProperty]
        private TimeSpan selectedToTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        public ObservableCollection<Telemetry> Telemetries { get; set; } = new();

        #region Charts

        [ObservableProperty]
        private ISeries[] _series =
        {
            new LineSeries<DateTimePoint>
            {
                Name = "Temp",
                Values = new DateTimePoint[]
                {
                    new DateTimePoint(DateTime.Now.AddMinutes(-4), 1),
                    new DateTimePoint(DateTime.Now.AddMinutes(-3), 2),
                    new DateTimePoint(DateTime.Now.AddMinutes(-2), 4),
                    new DateTimePoint((DateTime.Now.AddMinutes(-1)), 1),
                    new DateTimePoint(DateTime.Now, 2)
                }
            }
        };

        [ObservableProperty]
        private Axis[] _yAxes =
        {
            new Axis
            {
                Name = "Temp",
                NamePaint = new SolidColorPaint (SKColors.White),
                LabelsPaint = new SolidColorPaint (SKColors.White),
            }
        };

        [ObservableProperty]
        private Axis[] _xAxes =
        {
            new Axis
            {
                Name = "Time",
                NamePaint = new SolidColorPaint (SKColors.White),
                LabelsPaint = new SolidColorPaint (SKColors.White),
            }
        };



        #endregion

        [RelayCommand]
        private async Task GetTelemetry()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var telemetry = await _service.GetReadings(SelectedFromTime, SelectedToTime);

                if (Telemetries.Count != 0)
                    Telemetries.Clear();

                foreach (var telemet in telemetry)
                    Telemetries.Add(telemet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get Telemetries: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsRefreshing = false;
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task UpdateChart()
        {
            GetTelemetryCommand.Execute(null);
            List<DateTimePoint> temps = new();
            List<DateTimePoint> humit = new();
            foreach (Telemetry tele in Telemetries)
            {
                temps.Add(new DateTimePoint
                {
                    DateTime = tele.Time,
                    Value = tele.Temperature
                });
                humit.Add(new DateTimePoint
                {
                    DateTime = tele.Time,
                    Value = tele.Humidity
                });
            }

            Series[0].Values = temps;

            XAxes[0].MinLimit = XAxes[0].MaxLimit = null;
            YAxes[0].MinLimit = YAxes[0].MaxLimit = null;
        }
    }
}
