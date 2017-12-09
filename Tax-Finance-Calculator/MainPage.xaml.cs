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
using Windows.UI.Popups;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tax_Finance_Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IMobileServiceTable<TaxRates> myTable = App.MobileService.GetTable<TaxRates>();
        private static MobileServiceCollection<TaxRates, TaxRates> taxRates;
        private IMobileServiceTable<TaxRates> taxRatesTable = App.MobileService.GetTable<TaxRates>();

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
            //chooseCountry.ItemsSource = taxRates.countryName;

            confirmButton.Content = "Confirm";
            //confirmButton.IsEnabled = false;

            dropdownAndButton.VerticalAlignment = VerticalAlignment.Center;
            dropdownAndButton.HorizontalAlignment = HorizontalAlignment.Center;

            push();

        }

        private async void push()
        {

         

            taxRates = await myTable.Take(5).ToCollectionAsync();



            // new MessageDialog(taxRates.LastOrDefault().countryName + "\n" + taxRates.LastOrDefault().first_rate + "\n" + taxRates.LastOrDefault().first_cutoff).ShowAsync();

            /*
            TaxRates item = new TaxRates
            {
                countryName = "The Netherland",

                first_rate = 36.55,
                second_rate = 40.80,
                third_rate = 40.80,
                fourth_rate = 52,

                first_cutoff = 19982,
                second_cutoff = 33791,
                third_cutoff = 67072,
                fourth_cutoff= 0
            };

            await App.MobileService.GetTable<TaxRates>().InsertAsync(item);
            */

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