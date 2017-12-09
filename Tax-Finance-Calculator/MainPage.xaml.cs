using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using Tax_Finance_Calculator.View;
using Microsoft.WindowsAzure.MobileServices;
using Tax_Finance_Calculator.Data_Services;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tax_Finance_Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IMobileServiceTable<TaxRates> myTable = App.MobileService.GetTable<TaxRates>();

        public MainPage()
        {
            this.InitializeComponent();
            init();
        }



        private void init()
        {

            welcomeBlock.Text = "Welcome to \n Tax Calculator!";
            welcomeBlock.FontSize = 20;
            welcomeBlock.TextAlignment = TextAlignment.Center;
            welcomeBlock.HorizontalAlignment = HorizontalAlignment.Center;

            gettingStarted.Text = "Select a Country to begin.";
            gettingStarted.FontSize = 15;
            gettingStarted.TextAlignment = TextAlignment.Center;
            gettingStarted.HorizontalAlignment = HorizontalAlignment.Center;

            chooseCountry.PlaceholderText = "Select Country";

            confirmButton.Content = "Confirm";
            //confirmButton.IsEnabled = false;

            dropdownAndButton.VerticalAlignment = VerticalAlignment.Center;
            dropdownAndButton.HorizontalAlignment = HorizontalAlignment.Center;

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            confirmButton.IsEnabled = true;

        }


        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EnterCredentials));
        }
    }
}
