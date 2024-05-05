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
    public partial class DriverUpdate : Window
    {
        private Driver updatedDriver;
        private readonly DriverViewModel driverViewModel;
        private readonly int driverId;
        public DriverUpdate(DriverViewModel driverVM, int chosenId)
        {
            InitializeComponent();
            driverViewModel = driverVM;
            updatedDriver = new Driver();
            driverId = chosenId;
        }
        private async void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            updatedDriver.Id = driverId;
            updatedDriver.FirstName = FirstNameTextBox.Text;
            updatedDriver.LastName = LastNameTextBox.Text;
            driverViewModel.UpdateDriver(updatedDriver);
            Close();
        }

        private void LicenseCategory_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            LicenseCategory category = (LicenseCategory)Enum.Parse(typeof(LicenseCategory), checkBox.Tag.ToString());

            if (!updatedDriver.LicenseCategories.Contains(category))
            {
                updatedDriver.LicenseCategories.Add(category);
            }
        }

        private void LicenseCategory_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            LicenseCategory category = (LicenseCategory)Enum.Parse(typeof(LicenseCategory), checkBox.Tag.ToString());
            updatedDriver.LicenseCategories.Remove(category);
        }
    }
}
