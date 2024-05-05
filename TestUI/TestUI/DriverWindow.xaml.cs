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
    public partial class DriverWindow : Window
    {
        private readonly DriverApiService _apiService;
        private readonly DriverViewModel driverViewModel;
        public DriverWindow()
        {
            InitializeComponent();
            _apiService = new DriverApiService();
            driverViewModel = new DriverViewModel();

            LoadDrivers();
        }
        private async void LoadDrivers()
        {
            var allDriverss = await driverViewModel.LoadDriversAsync(_apiService);
            DriversListBox.ItemsSource = allDriverss;


        }
        private async void DeleteDriver_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null && button.Tag != null)
            {
                int driverId;
                if (int.TryParse(button.Tag.ToString(), out driverId))
                {
                    await driverViewModel.DeleteDriver(driverId);
                }
                else
                {
                    MessageBox.Show("Wrong driver Id.");
                }
            }
            else
            {
                MessageBox.Show("Can't reach driver Id");
            }
        }
        private async void UpdateDriver_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null && button.Tag != null)
            {
                int driverId;
                if (int.TryParse(button.Tag.ToString(), out driverId))
                {
                    var driverUpdateWindow = new DriverUpdate(driverViewModel, driverId);
                    driverUpdateWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wrong driver Id.");
                }
            }
            else
            {
                MessageBox.Show("Can't reach driver Id");
            }
        }
        private async void AddDriver_Click(object sender, RoutedEventArgs e)
        {

            var driverAddWindow = new DriverAdd(driverViewModel);
            driverAddWindow.ShowDialog();
        }
        private async void CarWindow_Click(object sender, RoutedEventArgs e)
        {
            var carWindow = new CarWindow();
            Close();
            carWindow.ShowDialog();
        }
        private async void TripWindow_Click(object sender, RoutedEventArgs e)
        {
            var tripWindow = new TripWindow();
            Close();
            tripWindow.ShowDialog();
        }

    }
}
