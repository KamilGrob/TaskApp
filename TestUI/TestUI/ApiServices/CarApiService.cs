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
    public class CarApiService
    {
        private readonly HttpClient _httpClient;

        public CarApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5079");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetAllCarsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("car");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> DeleteCarAsync(int carId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"car/{carId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> AddCarAsync(Car newCar)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("car", newCar);
            response.EnsureSuccessStatusCode(); // Upewnij się, że odpowiedź jest udana
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> UpdateCarAsync(Car updatedCar)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("car", updatedCar);
            response.EnsureSuccessStatusCode(); // Upewnij się, że odpowiedź jest udana
            return await response.Content.ReadAsStringAsync();
        }
    }
}
