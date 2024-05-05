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
using TestUI.Models;
using TestUI.ViewModels;

namespace TestUI
{
    public partial class CarUpdate : Window
    {
        private Car updatedCar;
        private readonly CarViewModel carViewModel;
        private readonly int carId;
        public CarUpdate(CarViewModel carVM, int chosenId)
        {
            InitializeComponent();
            carViewModel = carVM;
            updatedCar = new Car();
            carId = chosenId;
        }
        private async void AddCar_Click(object sender, RoutedEventArgs e)
        {
            updatedCar.Id = carId;
            updatedCar.Brand = BrandTextBox.Text;
            updatedCar.Model = ModelTextBox.Text;
            updatedCar.RegistrationNumber = RegistrationNumberTextBox.Text;
            ComboBoxItem selectedItem = (ComboBoxItem)TypeComboBox.SelectedItem;
            int typeValue = int.Parse(selectedItem.Tag.ToString());
            switch (typeValue)
            {
                case 0:
                    updatedCar.Type = CarType.Motorcycle;
                    break;
                case 1:
                    updatedCar.Type = CarType.Passenger;
                    break;
                case 2:
                    updatedCar.Type = CarType.Heavy;
                    break;
                case 3:
                    updatedCar.Type = CarType.Bus;
                    break;
                default:
                    updatedCar.Type = CarType.Motorcycle;
                    break;
            }
            carViewModel.UpdateCar(updatedCar);
            Close();
            foreach (Window window in Application.Current.Windows)
            {
                if (window != this)
                {
                    window.Close();
                }
            }
            CarWindow carWindow = new CarWindow();
            carWindow.ShowDialog();
        }
    }
}
