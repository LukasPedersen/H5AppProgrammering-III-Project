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

        public ObservableCollection<Telemetry> Telemetries { get; set; } = new();

        public ISeries[] Series { get; set; }

        [RelayCommand]
        private async Task GetTelemetry()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var telemetry = await _service.GetReadings();

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
    }
}
