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
    public class TripApiService
    {
        private readonly HttpClient _httpClient;

        public TripApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5079");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetAllTripsAsync()
        {
            
            HttpResponseMessage response = await _httpClient.GetAsync("trip");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> DeleteTripAsync(int tripId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"trip/{tripId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> AddTripAsync(Trip newTrip)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("trip", newTrip);
            response.EnsureSuccessStatusCode(); // Upewnij się, że odpowiedź jest udana
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> UpdateTripAsync(Trip updatedTrip)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("trip", updatedTrip);
            response.EnsureSuccessStatusCode(); // Upewnij się, że odpowiedź jest udana
            return await response.Content.ReadAsStringAsync();
        }
    }
}
