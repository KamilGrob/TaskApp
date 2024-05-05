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
    public partial class DriverAdd : Window
    {
        private Driver newDriver;
        private readonly DriverViewModel driverViewModel;
        public DriverAdd(DriverViewModel driverVM)
        {
            InitializeComponent();
            driverViewModel = driverVM;
            newDriver = new Driver();
        }
        private async void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            newDriver.FirstName = FirstNameTextBox.Text;
            newDriver.LastName = LastNameTextBox.Text;
            driverViewModel.AddDriver(newDriver);
            Close();
        }

        private void LicenseCategory_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            LicenseCategory category = (LicenseCategory)Enum.Parse(typeof(LicenseCategory), checkBox.Tag.ToString());

            if (!newDriver.LicenseCategories.Contains(category))
            {
                newDriver.LicenseCategories.Add(category);
            }
        }

        private void LicenseCategory_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            LicenseCategory category = (LicenseCategory)Enum.Parse(typeof(LicenseCategory), checkBox.Tag.ToString());
            newDriver.LicenseCategories.Remove(category);
        }
    }
}
