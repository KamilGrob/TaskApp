using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestUI.Models;


namespace TestUI.ViewModels
{
    public class CarViewModel : ViewModelBase 
    {
        private ApiServices.CarApiService _apiService;
        public async Task<IEnumerable<Car>> LoadCarsAsync(ApiServices.CarApiService _MainService)
        {
            try
            {
                _apiService = _MainService;
                string carsJson = await _apiService.GetAllCarsAsync();
                List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(carsJson);

                return cars;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error.");
                Environment.Exit(1);
                return null;
            }
        }

        public async Task DeleteCar(int carId)
        {
            try
            {
                await _apiService.DeleteCarAsync(carId);
                MessageBox.Show("Car has been deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error");
            }
        }

        public async Task AddCar(Car carmodel)
        {
            try
            {
                await _apiService.AddCarAsync(carmodel);
                MessageBox.Show("Car has been added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error");
            }
        }

        public async Task UpdateCar(Car carmodel)
        {
            try
            {
                await _apiService.UpdateCarAsync(carmodel);
                MessageBox.Show("Car has been updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error");
            }
        }

    }
}
