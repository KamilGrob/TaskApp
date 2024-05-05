using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestUI.ApiServices;
using TestUI.Models;
using TestUI.ViewModels;


namespace TestUI
{
    public partial class CarWindow : Window
    {
        private readonly CarApiService _apiService;
        private readonly CarViewModel carViewModel;

        public CarWindow()
        {
            InitializeComponent();
            _apiService = new CarApiService();
            carViewModel = new CarViewModel();

            LoadCars();
        }
        private async void LoadCars()
        {
            var allCars = await carViewModel.LoadCarsAsync(_apiService);
            CarsListBox.ItemsSource = allCars;
        }
        private async void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null && button.Tag != null)
            {
                int carId;
                if (int.TryParse(button.Tag.ToString(), out carId))
                {
                    await carViewModel.DeleteCar(carId);
                }
                else
                {
                    MessageBox.Show("Wrong car Id.");
                }
            }
            else
            {
                MessageBox.Show("Can't reach car Id");
            }
        }
        private async void UpdateCar_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null && button.Tag != null)
            {
                int carId;
                if (int.TryParse(button.Tag.ToString(), out carId))
                {
                    var carUpdateWindow = new CarUpdate(carViewModel, carId);
                    carUpdateWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wrong car Id.");
                }
            }
            else
            {
                MessageBox.Show("Can't reach car Id");
            }
        }
        private async void AddCar_Click(object sender, RoutedEventArgs e)
        {

            var carAddWindow = new CarAdd(carViewModel);
            carAddWindow.ShowDialog();
        }
        private async void DriverWindow_Click(object sender, RoutedEventArgs e)
        {
            var driverWindow = new DriverWindow();
            Close();
            driverWindow.ShowDialog();
        }
        private async void TripWindow_Click(object sender, RoutedEventArgs e)
        {
            var tripWindow = new TripWindow();
            Close();
            tripWindow.ShowDialog();
        }
    }
}