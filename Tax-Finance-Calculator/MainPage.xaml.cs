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
using Tax_Finance_Calculator.ViewModel;
using Tax_Finance_Calculator.Model;
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

        public List<string> cNames = new List<string>();
        public List<double> cutOffs = new List<double>();
        public List<double> percents = new List<double>();

        DataModel dm = new DataModel();

        public MainPage()
        {
            this.InitializeComponent();
            init();
        }

        private void init()
        {
            pull();

            welcomeBlock.Text = "Welcome to \n Tax Calculator!";
            welcomeBlock.FontSize = 20;
            welcomeBlock.TextAlignment = TextAlignment.Center;
            welcomeBlock.HorizontalAlignment = HorizontalAlignment.Center;

            gettingStarted.Text = "Select a Country to begin.";
            gettingStarted.FontSize = 15;
            gettingStarted.TextAlignment = TextAlignment.Center;
            gettingStarted.HorizontalAlignment = HorizontalAlignment.Center;


            confirmButton.Content = "Confirm";
            confirmButton.IsEnabled = false;

            dropdownAndButton.VerticalAlignment = VerticalAlignment.Center;
            dropdownAndButton.HorizontalAlignment = HorizontalAlignment.Center;

        }

        public async void pull()
        {
            taxRates = await myTable.Take(5).ToCollectionAsync();
            assign();
        }

        public void assign()
        {
            cNames.Add(taxRates.FirstOrDefault().countryName);
            cNames.Add(taxRates.LastOrDefault().countryName);
            
            cutOffs.Add(taxRates.First().first_cutoff);
            cutOffs.Add(taxRates.First().second_cutoff);
            cutOffs.Add(taxRates.First().third_cutoff);
            cutOffs.Add(taxRates.First().fourth_cutoff);

            cutOffs.Add(taxRates.Last().first_cutoff);
            cutOffs.Add(taxRates.Last().second_cutoff);
            cutOffs.Add(taxRates.Last().third_cutoff);
            cutOffs.Add(taxRates.Last().fourth_cutoff);

            percents.Add(taxRates.First().first_rate);
            percents.Add(taxRates.First().second_cutoff);
            percents.Add(taxRates.First().third_cutoff);
            percents.Add(taxRates.First().fourth_cutoff);

            percents.Add(taxRates.Last().first_rate);
            percents.Add(taxRates.Last().second_cutoff);
            percents.Add(taxRates.Last().third_cutoff);
            percents.Add(taxRates.Last().fourth_cutoff);
            chooseCountry.PlaceholderText = "Select Country";

            chooseCountry.ItemsSource = cNames;


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