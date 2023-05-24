using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillWathcerApp.ViewModels
{
    public partial class ControlViewModel : ViewModel
    {
        [ObservableProperty]
        private int sliderVal = 0;

        [ObservableProperty]
        public IEnumerable<ISeries> _series
        = new GaugeBuilder()
        .WithLabelsSize(50)
        .WithInnerRadius(75)
        .WithBackgroundInnerRadius(75)
        .WithBackground(new SolidColorPaint(new SKColor(218, 78, 37, 90)))
        .WithLabelsPosition(PolarLabelsPosition.ChartCenter)
        .AddValue(0, "gauge value", SKColors.YellowGreen, SKColors.Red) // defines the value and the color 
        .BuildSeries();
    }
}
