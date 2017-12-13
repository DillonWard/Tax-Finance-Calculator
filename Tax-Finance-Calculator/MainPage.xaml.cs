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

        List<DataModel> dms;
        BracketViewModel bvm;
        public MainPage()
        {
            this.InitializeComponent();
            dms = new List<DataModel>();
            bvm  = new BracketViewModel();
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

            chooseCountry.PlaceholderText = "Select Country";
            chooseCountry.ItemsSource = dms;
            chooseCountry.DisplayMemberPath = "countryName";


            //MessageBox.Show();

        }

        public async void pull()
        {
            taxRates = await myTable.Take(5).ToCollectionAsync();
            assign();
        }

        public void assign()
        {

            List<Double> tempR= new List<Double>();
            List<Double> tempP = new List<Double>();

            tempR.Add(taxRates.First().first_cutoff);
            tempR.Add(taxRates.First().second_cutoff);
            tempR.Add(taxRates.First().third_cutoff);
            tempR.Add(taxRates.First().fourth_cutoff);

            tempP.Add(taxRates.First().first_rate);
            tempP.Add(taxRates.First().second_rate);
            tempP.Add(taxRates.First().third_rate);
            tempP.Add(taxRates.First().fourth_rate);

            var first = new DataModel(taxRates.First().countryName.ToString(), tempR.ToArray(), tempP.ToArray());
            dms.Add(first);

            tempR.Add(taxRates.Last().first_cutoff);
            tempR.Add(taxRates.Last().second_cutoff);
            tempR.Add(taxRates.Last().third_cutoff);
            tempR.Add(taxRates.Last().fourth_cutoff);

            tempP.Add(taxRates.Last().first_rate);
            tempP.Add(taxRates.Last().second_rate);
            tempP.Add(taxRates.Last().third_rate);
            tempP.Add(taxRates.Last().fourth_rate);

            var last = new DataModel(taxRates.Last().countryName.ToString(), tempR.ToArray(), tempP.ToArray());
            dms.Add(last);

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            confirmButton.IsEnabled = true;
        }


        public void confirmButton_Click(object sender, RoutedEventArgs e)
        {

            var selected = (DataModel)chooseCountry.SelectedItem;

            if (selected.countryName.ToString() == "Ireland")
            {

                var newRate = new DataModel();

                newRate.countryName = selected.countryName;
                newRate.taxRates = selected.taxRates;
                newRate.percentages = selected.percentages;
                this.Frame.Navigate(typeof(EnterCredentials), newRate);
            }

            else if (selected.countryName.ToString() == "The Netherland")
            {
                var newRate = new DataModel();

                newRate.countryName = selected.countryName;
                newRate.taxRates = selected.taxRates;
                newRate.percentages = selected.percentages;
                this.Frame.Navigate(typeof(NoCredentialsNeeded), newRate);

            }

        }
    }



}