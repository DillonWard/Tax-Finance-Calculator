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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Tax_Finance_Calculator.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EnterCredentials : Page
    {
        public EnterCredentials()
        {
            this.InitializeComponent();
            init();
        }


        private void init()
        {
            salary.HorizontalAlignment = HorizontalAlignment.Center;
            salary.VerticalAlignment = VerticalAlignment.Center;
            salary.PlaceholderText = "Enter salary";
            salary.IsReadOnly = true;
        }

        private void Single_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            salary.IsReadOnly = false;

        }

        private void SP_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            salary.IsReadOnly = false;

        }
        private void Married_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            salary.IsReadOnly = false;

        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

        }
    }
}
