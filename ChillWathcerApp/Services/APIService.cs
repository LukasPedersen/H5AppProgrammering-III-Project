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

        public async Task<List<Telemetry>> GetReadings()
        {
            return await _httpClient.GetFromJsonAsync<List<Telemetry>>("https://8z2xzcd8-7117.euw.devtunnels.ms/getTelemetry");
        }
    }
}
