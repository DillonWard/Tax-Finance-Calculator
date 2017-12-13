using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tax_Finance_Calculator.Model;
using Tax_Finance_Calculator.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Tax_Finance_Calculator.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NoCredentialsNeeded : Page
    {
        BracketViewModel bvm;

        public NoCredentialsNeeded()
        {
            this.InitializeComponent();
            bvm = new BracketViewModel();
            init();
        }

        private void init()
        {
            salary.HorizontalAlignment = HorizontalAlignment.Center;
            salary.VerticalAlignment = VerticalAlignment.Center;
            salary.PlaceholderText = "Enter salary";

            confirm.HorizontalAlignment = HorizontalAlignment.Center;
            confirm.VerticalAlignment = VerticalAlignment.Center;

            afterTaxReturnNC.Text = "After Tax:";
            afterTaxReturnNC.HorizontalAlignment = HorizontalAlignment.Left;

            taxedIncomeNC.Text = "Taxed:";
            taxedIncomeNC.HorizontalAlignment = HorizontalAlignment.Left;

            suggestedSavingsNC.Text = "Suggested Savings (10%):";
            suggestedRentNC.HorizontalAlignment = HorizontalAlignment.Left;

            suggestedRentNC.Text = "Suggested Rent (30%):";
            suggestedRentNC.HorizontalAlignment = HorizontalAlignment.Left;

            returnsNC.HorizontalAlignment = HorizontalAlignment.Center;

            afterTaxResult.HorizontalAlignment = HorizontalAlignment.Right;

            taxedIncomeResult.HorizontalAlignment = HorizontalAlignment.Right;

            suggestedSavingsResult.HorizontalAlignment = HorizontalAlignment.Right;

            suggestedRentResult.HorizontalAlignment = HorizontalAlignment.Right;




        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var pars = (DataModel)e.Parameter;


            bvm.cutOffs = pars.taxRates;
            bvm.rates = pars.percentages;

        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            bvm.salary = double.Parse(salary.Text);
            bvm.noCredentialsTax();
        }

        private void salary_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
