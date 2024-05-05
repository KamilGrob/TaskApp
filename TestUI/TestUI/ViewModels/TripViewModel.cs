using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestUI.Models;

namespace TestUI.ViewModels
{
    public class TripViewModel : ViewModelBase
    {
        private ApiServices.TripApiService _apiService;
        public async Task<IEnumerable<Trip>> LoadTripsAsync(ApiServices.TripApiService _MainService)
        {

            try
            {
                _apiService = _MainService;
                string tripsJson = await _apiService.GetAllTripsAsync();
                List<Trip> trips = JsonConvert.DeserializeObject<List<Trip>>(tripsJson);

                return trips;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error.");
                Environment.Exit(1);
                return null;
            }
        }

        public async Task DeleteTrip(int tripId)
        {
            try
            {
                await _apiService.DeleteTripAsync(tripId);
                MessageBox.Show("Trip has been deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error");
            }
        }

        public async Task AddTrip(Trip tripmodel)
        {
            try
            {
                await _apiService.AddTripAsync(tripmodel);
                MessageBox.Show("Trip has been added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error");
            }
        }

        public async Task UpdateTrip(Trip tripmodel)
        {
            try
            {
                await _apiService.UpdateTripAsync(tripmodel);
                MessageBox.Show("Trip has been updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error");
            }
        }

    }
}
