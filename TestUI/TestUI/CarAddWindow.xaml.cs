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
    
    public partial class CarAdd : Window
    {
        private Car newCar;
        private readonly CarViewModel carViewModel;
        public CarAdd(CarViewModel carVM)
        {
            InitializeComponent();
            carViewModel = carVM;
            newCar = new Car(); 
        }
        private async void AddCar_Click(object sender, RoutedEventArgs e)
        {
            newCar.Brand = BrandTextBox.Text;
            newCar.Model = ModelTextBox.Text;
            newCar.RegistrationNumber = RegistrationNumberTextBox.Text;
            ComboBoxItem selectedItem = (ComboBoxItem)TypeComboBox.SelectedItem;
            int typeValue = int.Parse(selectedItem.Tag.ToString());
            switch (typeValue)
            {
                case 0:
                    newCar.Type = CarType.Motorcycle;
                    break;
                case 1:
                    newCar.Type = CarType.Passenger;
                    break;
                case 2:
                    newCar.Type = CarType.Heavy;
                    break;
                case 3:
                    newCar.Type = CarType.Bus;
                    break;
                default:
                    newCar.Type = CarType.Motorcycle; 
                    break;
            }
            carViewModel.AddCar(newCar);
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
