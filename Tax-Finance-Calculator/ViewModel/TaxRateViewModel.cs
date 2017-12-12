using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax_Finance_Calculator.Model;

namespace Tax_Finance_Calculator.ViewModel
{
    class BracketViewModel
    {

        // Deduct the tax from gross income
        double calculatedTax;
        DataModel dm = new DataModel();

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
