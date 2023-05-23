using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ChillWathcerApp.Models;

namespace ChillWathcerApp.Services
{
    public class APIService
    {
        readonly HttpClient _httpClient;
        public APIService() 
        {
            this._httpClient = new HttpClient();
        }

        public async Task<List<Telemetry>> GetReadings(TimeSpan _from, TimeSpan _to)
        {
            List<Telemetry> readings = await _httpClient.GetFromJsonAsync<List<Telemetry>>("https://v4vvfrtc-7117.euw.devtunnels.ms/getTelemetry");
            return readings.Where(from => from.Time.TimeOfDay >= _from).Where(to => to.Time.TimeOfDay <= _to).ToList();
        }
    }
}
