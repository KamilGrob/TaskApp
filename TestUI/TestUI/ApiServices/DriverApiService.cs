using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TestUI.Models;

namespace TestUI.ApiServices
{
    public class DriverApiService
    {
        private readonly HttpClient _httpClient;

        public DriverApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5079");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetAllDriversAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("driver");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> DeleteDriverAsync(int driverId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"driver/{driverId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> AddDriverAsync(Driver newDriver)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("driver", newDriver);
            response.EnsureSuccessStatusCode(); 
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> UpdateDriverAsync(Driver updatedDriver)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("driver ", updatedDriver);
            response.EnsureSuccessStatusCode(); 
            return await response.Content.ReadAsStringAsync();
        }
    }
}
