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
    public class DriverViewModel : ViewModelBase
    {
        private ApiServices.DriverApiService _apiService;
        public async Task<IEnumerable<Driver>> LoadDriversAsync(ApiServices.DriverApiService _MainService)
        {

            try
            {
                _apiService = _MainService;
                string driversJson = await _apiService.GetAllDriversAsync();
                List<Driver> drivers = JsonConvert.DeserializeObject<List<Driver>>(driversJson);

                return drivers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error.");
                Environment.Exit(1);
                return null;
            }
        }

        public async Task DeleteDriver(int driverId)
        {
            try
            {
                await _apiService.DeleteDriverAsync(driverId);
                MessageBox.Show("Driver has been deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error");
            }
        }

        public async Task AddDriver(Driver drivermodel)
        {
            try
            {
                await _apiService.AddDriverAsync(drivermodel);
                MessageBox.Show("Driver has been added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error");
            }
        }

        public async Task UpdateDriver(Driver drivermodel)
        {
            try
            {
                await _apiService.UpdateDriverAsync(drivermodel);
                MessageBox.Show("Driver has been updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error");
            }
        }

    }
}
