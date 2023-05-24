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
using LiveChartsCore.Measure;

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
        private ISeries[] _seriesTH =
        {
            new LineSeries<DateTimePoint>
            {
                Name = "Humit",
                Values = new DateTimePoint[]
                {
                    new DateTimePoint(DateTime.Now.AddMinutes(-60), 43),
                    new DateTimePoint(DateTime.Now.AddMinutes(-59), 46),
                    new DateTimePoint(DateTime.Now.AddMinutes(-58), 48),
                    new DateTimePoint(DateTime.Now.AddMinutes(-57), 43),
                    new DateTimePoint(DateTime.Now.AddMinutes(-56), 40),
                    new DateTimePoint(DateTime.Now.AddMinutes(-55), 59),
                    new DateTimePoint(DateTime.Now.AddMinutes(-54), 68),
                    new DateTimePoint(DateTime.Now.AddMinutes(-53), 70),
                    new DateTimePoint(DateTime.Now.AddMinutes(-52), 62),
                    new DateTimePoint(DateTime.Now.AddMinutes(-51), 58),
                    new DateTimePoint(DateTime.Now.AddMinutes(-50), 60),
                    new DateTimePoint(DateTime.Now.AddMinutes(-49), 60),
                    new DateTimePoint(DateTime.Now.AddMinutes(-48), 58),
                    new DateTimePoint(DateTime.Now.AddMinutes(-47), 60),
                    new DateTimePoint(DateTime.Now.AddMinutes(-46), 44),
                    new DateTimePoint(DateTime.Now.AddMinutes(-45), 40),
                    new DateTimePoint(DateTime.Now.AddMinutes(-44), 42),
                    new DateTimePoint(DateTime.Now.AddMinutes(-43), 48),
                    new DateTimePoint(DateTime.Now.AddMinutes(-42), 50),
                    new DateTimePoint(DateTime.Now.AddMinutes(-41), 42),
                    new DateTimePoint(DateTime.Now.AddMinutes(-40), 58),
                    new DateTimePoint(DateTime.Now.AddMinutes(-30), 62),
                    new DateTimePoint(DateTime.Now.AddMinutes(-29), 78),
                    new DateTimePoint(DateTime.Now.AddMinutes(-28), 62),
                    new DateTimePoint(DateTime.Now.AddMinutes(-27), 70),
                    new DateTimePoint(DateTime.Now.AddMinutes(-26), 64),
                    new DateTimePoint(DateTime.Now.AddMinutes(-25), 68),
                    new DateTimePoint(DateTime.Now.AddMinutes(-24), 70),
                    new DateTimePoint(DateTime.Now.AddMinutes(-23), 75),
                    new DateTimePoint(DateTime.Now.AddMinutes(-22), 80),
                    new DateTimePoint(DateTime.Now.AddMinutes(-21), 73),
                    new DateTimePoint(DateTime.Now.AddMinutes(-20), 64),
                    new DateTimePoint(DateTime.Now.AddMinutes(-19), 75),
                    new DateTimePoint(DateTime.Now.AddMinutes(-18), 58),
                    new DateTimePoint(DateTime.Now.AddMinutes(-17), 52),
                    new DateTimePoint(DateTime.Now.AddMinutes(-16), 59),
                    new DateTimePoint(DateTime.Now.AddMinutes(-15), 72),
                    new DateTimePoint(DateTime.Now.AddMinutes(-14), 78),
                    new DateTimePoint(DateTime.Now.AddMinutes(-13), 77),
                    new DateTimePoint(DateTime.Now.AddMinutes(-12), 69),
                    new DateTimePoint(DateTime.Now.AddMinutes(-11), 64),
                    new DateTimePoint(DateTime.Now.AddMinutes(-10), 72),
                    new DateTimePoint(DateTime.Now.AddMinutes(-9), 71),
                    new DateTimePoint(DateTime.Now.AddMinutes(-8), 70),
                    new DateTimePoint(DateTime.Now.AddMinutes(-7), 74),
                    new DateTimePoint(DateTime.Now.AddMinutes(-6), 62),
                    new DateTimePoint(DateTime.Now.AddMinutes(-5), 68),
                    new DateTimePoint(DateTime.Now.AddMinutes(-4), 64),
                    new DateTimePoint(DateTime.Now.AddMinutes(-3), 68),
                    new DateTimePoint(DateTime.Now.AddMinutes(-2), 70),
                    new DateTimePoint((DateTime.Now.AddMinutes(-1)), 72),
                    new DateTimePoint(DateTime.Now, 60)
                }
            },

            new LineSeries<DateTimePoint>
            {
                Name = "Temp",
                Values = new DateTimePoint[]
                {
                    new DateTimePoint(DateTime.Now.AddMinutes(-60), 16),
                    new DateTimePoint(DateTime.Now.AddMinutes(-59), 17),
                    new DateTimePoint(DateTime.Now.AddMinutes(-58), 18),
                    new DateTimePoint(DateTime.Now.AddMinutes(-57), 22),
                    new DateTimePoint(DateTime.Now.AddMinutes(-56), 20),
                    new DateTimePoint(DateTime.Now.AddMinutes(-55), 21),
                    new DateTimePoint(DateTime.Now.AddMinutes(-54), 24),
                    new DateTimePoint(DateTime.Now.AddMinutes(-53), 23),
                    new DateTimePoint(DateTime.Now.AddMinutes(-52), 24),
                    new DateTimePoint(DateTime.Now.AddMinutes(-51), 25),
                    new DateTimePoint(DateTime.Now.AddMinutes(-50), 26),
                    new DateTimePoint(DateTime.Now.AddMinutes(-49), 23),
                    new DateTimePoint(DateTime.Now.AddMinutes(-48), 22),
                    new DateTimePoint(DateTime.Now.AddMinutes(-47), 21),
                    new DateTimePoint(DateTime.Now.AddMinutes(-46), 20),
                    new DateTimePoint(DateTime.Now.AddMinutes(-45), 18),
                    new DateTimePoint(DateTime.Now.AddMinutes(-44), 22),
                    new DateTimePoint(DateTime.Now.AddMinutes(-43), 24),
                    new DateTimePoint(DateTime.Now.AddMinutes(-42), 22),
                    new DateTimePoint(DateTime.Now.AddMinutes(-41), 28),
                    new DateTimePoint(DateTime.Now.AddMinutes(-40), 18),
                    new DateTimePoint(DateTime.Now.AddMinutes(-30), 25),
                    new DateTimePoint(DateTime.Now.AddMinutes(-29), 24),
                    new DateTimePoint(DateTime.Now.AddMinutes(-28), 23),
                    new DateTimePoint(DateTime.Now.AddMinutes(-27), 23),
                    new DateTimePoint(DateTime.Now.AddMinutes(-26), 24),
                    new DateTimePoint(DateTime.Now.AddMinutes(-25), 28),
                    new DateTimePoint(DateTime.Now.AddMinutes(-24), 19),
                    new DateTimePoint(DateTime.Now.AddMinutes(-23), 18),
                    new DateTimePoint(DateTime.Now.AddMinutes(-22), 20),
                    new DateTimePoint(DateTime.Now.AddMinutes(-21), 22),
                    new DateTimePoint(DateTime.Now.AddMinutes(-20), 21),
                    new DateTimePoint(DateTime.Now.AddMinutes(-19), 18),
                    new DateTimePoint(DateTime.Now.AddMinutes(-18), 20),
                    new DateTimePoint(DateTime.Now.AddMinutes(-17), 22),
                    new DateTimePoint(DateTime.Now.AddMinutes(-16), 24),
                    new DateTimePoint(DateTime.Now.AddMinutes(-15), 28),
                    new DateTimePoint(DateTime.Now.AddMinutes(-14), 26),
                    new DateTimePoint(DateTime.Now.AddMinutes(-13), 28),
                    new DateTimePoint(DateTime.Now.AddMinutes(-12), 25),
                    new DateTimePoint(DateTime.Now.AddMinutes(-11), 23),
                    new DateTimePoint(DateTime.Now.AddMinutes(-10), 21),
                    new DateTimePoint(DateTime.Now.AddMinutes(-9), 22),
                    new DateTimePoint(DateTime.Now.AddMinutes(-8), 23),
                    new DateTimePoint(DateTime.Now.AddMinutes(-7), 24),
                    new DateTimePoint(DateTime.Now.AddMinutes(-6), 26),
                    new DateTimePoint(DateTime.Now.AddMinutes(-5), 25),
                    new DateTimePoint(DateTime.Now.AddMinutes(-4), 25),
                    new DateTimePoint(DateTime.Now.AddMinutes(-3), 24),
                    new DateTimePoint(DateTime.Now.AddMinutes(-2), 24),
                    new DateTimePoint((DateTime.Now.AddMinutes(-1)), 23),
                    new DateTimePoint(DateTime.Now, 18)
                }
            }
        };

        [ObservableProperty]
        private Axis[] _yAxes =
        {
            new Axis
            {
                Name = "",
                NamePaint = new SolidColorPaint (SKColors.White),
                LabelsPaint = new SolidColorPaint (SKColors.White),
                NameTextSize = 40,
                TextSize = 30,
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
                NameTextSize = 35,
                TextSize = 30,
                LabelsRotation = 45,
                Labeler = (value) => new DateTime ((long)value).ToString("HH:mm")
            }
        };

        [ObservableProperty]
        public IEnumerable<ISeries> _seriesPie
        = new GaugeBuilder()
        .WithLabelsSize(30)
        .WithLabelsPosition(PolarLabelsPosition.Start)
        .WithLabelFormatter(point => $"{point.PrimaryValue} {point.Context.Series.Name}")
        .WithInnerRadius(15)
        .WithOffsetRadius(8)
        .WithBackgroundInnerRadius(20)
        .AddValue(60, "% Humidity", SKColors.LightBlue, SKColors.White)
        .AddValue(18, "°C Temperature", SKColors.OrangeRed, SKColors.White)

        .BuildSeries();

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
            IsBusy = true;

            List<Telemetry> telemetry = await _service.GetReadings(SelectedFromTime, SelectedToTime);

            List<DateTimePoint> temps = new();
            List<DateTimePoint> humit = new();
            foreach (Telemetry tele in telemetry)
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

            SeriesTH[0].Values = temps;

            XAxes[0].MinLimit = XAxes[0].MaxLimit = null;
            YAxes[0].MinLimit = YAxes[0].MaxLimit = null;

            IsBusy = false;
        }
    }
}
