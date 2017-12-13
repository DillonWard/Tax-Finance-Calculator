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
    public sealed partial class EnterCredentials : Page
    {
        BracketViewModel bvm;
        string subSalary;

        public EnterCredentials()
        {
            this.InitializeComponent();
            bvm = new BracketViewModel();
            init();
        }

        int status;

        private void init()
        {
            salary.HorizontalAlignment = HorizontalAlignment.Center;
            salary.VerticalAlignment = VerticalAlignment.Center;
            salary.PlaceholderText = "Enter salary";

            confirm.HorizontalAlignment = HorizontalAlignment.Center;
            confirm.VerticalAlignment = VerticalAlignment.Center;

            salary.IsReadOnly = true;

            afterTaxReturn.Text = "After Tax:";
            afterTaxReturn.HorizontalAlignment = HorizontalAlignment.Left;

            taxedIncome.Text = "Taxed:";
            taxedIncome.HorizontalAlignment = HorizontalAlignment.Left;

            suggestedSavings.Text = "Suggested Savings (10%):";
            suggestedRent.HorizontalAlignment = HorizontalAlignment.Left;

            suggestedRent.Text = "Suggested Rent (30%):";
            suggestedRent.HorizontalAlignment = HorizontalAlignment.Left;

            returns.HorizontalAlignment = HorizontalAlignment.Center;

            afterTaxResult.HorizontalAlignment = HorizontalAlignment.Right;
            afterTaxResult.Text = "1";

            taxedIncomeResult.HorizontalAlignment = HorizontalAlignment.Right;

            suggestedSavingsResult.HorizontalAlignment = HorizontalAlignment.Right;

            suggestedRentResult.HorizontalAlignment = HorizontalAlignment.Right;

            afterTaxResult.HorizontalAlignment = HorizontalAlignment.Right;


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var pars = (DataModel)e.Parameter;

            bvm.cutOffs = pars.taxRates;
            bvm.rates = pars.percentages;

           // pars.percentages = bvm.cutOffs;
        }

        private void Single_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            status = 1;
            salary.IsReadOnly = false;

        }

        private void SP_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            status = 2;
            salary.IsReadOnly = false;

        }

        private void Married_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            status = 3;
            salary.IsReadOnly = false;
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            bvm.salary = double.Parse(salary.Text);

            bvm.determineRate(status);

        }

        private void salary_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
