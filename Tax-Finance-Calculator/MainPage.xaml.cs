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
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tax_Finance_Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
             
            init();

        }

        public void init()
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

            dropdownAndButton.VerticalAlignment = VerticalAlignment.Center;
            dropdownAndButton.HorizontalAlignment = HorizontalAlignment.Center;

            //data();

        }

        private static readonly HttpClient client = new HttpClient();

        /*
        async void data()
        {
            //Create an HTTP client object
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            Uri requestUri = new Uri("https://management.core.windows.net:8443/9be76ffa-2149-4d80-a0bd-822e172fe814/services/sqlservers/servers/tfc.database.windows.net/databases/Tax-Finance-Calculator-DB");

            //Send the GET request asynchronously and retrieve the response as a string.
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

        }

    */
        private void welcomeBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void gettingStarter_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void confirmCountry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EnterCredentials));
        }
    }
}
