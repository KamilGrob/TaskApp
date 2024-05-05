using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestUI.ApiServices;
using TestUI.Models;
using TestUI.ViewModels;

namespace TestUI
{
    public partial class TripUpdate : Window
    {
        private Trip updatedTrip;
        private readonly TripViewModel tripViewModel;
        private readonly int tripId;
        private readonly DriverViewModel driverViewModel;
        private readonly CarViewModel carViewModel;
        private readonly CarApiService _carApiService;
        private readonly DriverApiService _driverApiService;
        public TripUpdate(TripViewModel tripVM, int chosenId)
        {
            InitializeComponent();
            tripViewModel = tripVM;
            updatedTrip = new Trip();
            tripId = chosenId;
            carViewModel = new CarViewModel();
            driverViewModel = new DriverViewModel();
            _driverApiService = new DriverApiService();
            _carApiService = new CarApiService();
            LoadCarsAndDrivers(); 
        }
        private async void AddTrip_Click(object sender, RoutedEventArgs e)
        {
            updatedTrip.Id = tripId;
            updatedTrip.CarId = (int)CarComboBox.SelectedValue;
            updatedTrip.DriverId = (int)DriverComboBox.SelectedValue;
            updatedTrip.StartTime = StartTimeDatePicker.SelectedDate ?? DateTime.MinValue;
            updatedTrip.EndTime = EndTimeDatePicker.SelectedDate ?? DateTime.MinValue;
            updatedTrip.Distance = DistanceTextBox.Value ?? 0.0;
            updatedTrip.AverageFuelConsumption = AverageFuelConsumptionTextBox.Value ?? 0.0;
            tripViewModel.UpdateTrip(updatedTrip);
            Close();
        }
        private async void LoadCarsAndDrivers()
        {

            var allCars = await carViewModel.LoadCarsAsync(_carApiService);
            CarComboBox.ItemsSource = allCars;
            var allDrivers = await driverViewModel.LoadDriversAsync(_driverApiService);
            DriverComboBox.ItemsSource = allDrivers;
        }
    }
}
