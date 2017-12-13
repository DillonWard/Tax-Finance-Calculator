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
        IncomeModel im = new IncomeModel();
        DataModel dm = new DataModel();
        double currRate;
        double currPercent;

        public double salary { get; set;}
        public double[] cutOffs { get; set; }
        public double[] rates { get; set; }

        public void determineRate(int r)
        {
            switch (r)
            {                    

                case 1:
                    currRate = cutOffs[0];
                    currPercent = rates[0];
                    break;

                case 2:
                    currRate = cutOffs[1];
                    currPercent = rates[1];
                    break;

                case 3:
                    currRate = cutOffs[3];
                    currPercent = rates[3];
                    break;

            }
            deductTax(salary, currPercent);
        }

        public void deductTax(double salary, double taxRate)
        {
            calculatedTax = (salary / 100) * taxRate;
            im.taxedIncome = calculatedTax;
            calculatedTax = salary - calculatedTax;
            im.yearlyIncome = calculatedTax;



            var ra = (im.yearlyIncome / 100) * 30;
            im.rentAdvisor = ra;

            var sa = (calculatedTax / 100) * 10;
            im.savingsAdvisor = sa;

        }
    }
}
