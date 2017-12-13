using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax_Finance_Calculator.Model;
using Windows.UI.Popups;

namespace Tax_Finance_Calculator.ViewModel
{
    class BracketViewModel
    {

        // Deduct the tax from gross income
        double calculatedTax;
        DataModel dm = new DataModel();
        string country;

        public String setCountry(String country)
        {
            this.country = country;
            switch (country)
            {
                case "Ireland":
                    new MessageDialog(country).ShowAsync();
                    break;
            }

            return country;

        }

        public void determineRate(double salary)
        {

        }

        public void deductTax(double salary, double taxRate)
        {
            calculatedTax = (salary / 100) * taxRate;
            calculatedTax = salary - calculatedTax;

            //return calculatedTax;

        }

        // Return income after tax

    }
}
