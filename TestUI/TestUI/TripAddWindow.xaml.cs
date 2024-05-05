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
    public partial class TripAdd : Window
    {
        private Trip newTrip;
        private readonly TripViewModel tripViewModel;
        private readonly DriverViewModel driverViewModel;
        private readonly CarViewModel carViewModel;
        private readonly CarApiService _carApiService;
        private readonly DriverApiService _driverApiService;
        public TripAdd(TripViewModel tripVM)
        {
            InitializeComponent();
            tripViewModel = tripVM;
            newTrip = new Trip();
            carViewModel = new CarViewModel();
            driverViewModel = new DriverViewModel();
            _driverApiService = new DriverApiService();
            _carApiService = new CarApiService();
            LoadCarsAndDrivers();
        }
        private async void AddTrip_Click(object sender, RoutedEventArgs e)
        {
            newTrip.CarId = (int)CarComboBox.SelectedValue;
            newTrip.DriverId = (int)DriverComboBox.SelectedValue;
            newTrip.StartTime = StartTimeDatePicker.SelectedDate ?? DateTime.MinValue;
            newTrip.EndTime = EndTimeDatePicker.SelectedDate ?? DateTime.MinValue;
            newTrip.Distance = DistanceTextBox.Value ?? 0.0;
            newTrip.AverageFuelConsumption = AverageFuelConsumptionTextBox.Value ?? 0.0;
            tripViewModel.AddTrip(newTrip);

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
