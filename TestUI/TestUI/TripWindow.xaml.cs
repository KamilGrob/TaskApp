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
using TestUI.ViewModels;

namespace TestUI
{
    public partial class TripWindow : Window
    {
        private readonly TripApiService _apiService;
        private readonly TripViewModel tripViewModel;

        public TripWindow()
        {
            InitializeComponent();
            _apiService = new TripApiService();
            tripViewModel = new TripViewModel();

            LoadTrips();
        }
        private async void LoadTrips()
        {
            var allTrips = await tripViewModel.LoadTripsAsync(_apiService);
            TripsListBox.ItemsSource = allTrips;
        }
        private async void DeleteTrip_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null && button.Tag != null)
            {
                int tripId;
                if (int.TryParse(button.Tag.ToString(), out tripId))
                {
                    await tripViewModel.DeleteTrip(tripId);
                }
                else
                {
                    MessageBox.Show("Wrong trip Id.");
                }
            }
            else
            {
                MessageBox.Show("Can't reach trip Id");
            }
        }
        private async void UpdateTrip_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null && button.Tag != null)
            {
                int tripId;
                if (int.TryParse(button.Tag.ToString(), out tripId))
                {
                    var tripUpdateWindow = new TripUpdate(tripViewModel, tripId);
                    tripUpdateWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wrong trip Id.");
                }
            }
            else
            {
                MessageBox.Show("Can't reach trip Id");
            }
        }
        private async void AddTrip_Click(object sender, RoutedEventArgs e)
        {

            var tripAddWindow = new TripAdd(tripViewModel);
            tripAddWindow.ShowDialog();
        }
        private async void DriverWindow_Click(object sender, RoutedEventArgs e)
        {
            var driverWindow = new DriverWindow();
            Close();
            driverWindow.ShowDialog();
        }
        private async void CarWindow_Click(object sender, RoutedEventArgs e)
        {
            var carWindow = new CarWindow();
            Close();
            carWindow.ShowDialog();
        }
    }
}
