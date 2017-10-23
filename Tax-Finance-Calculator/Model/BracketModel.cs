using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Finance_Calculator.Model
{
    class BracketModel
    {
        // Tax Bracket - Determines how much the person is going to be taxed a year 
        public int martialStatus { get; set; } // Single, Windowed, Surviving Civil Partner, Married/Civil Partnership
        public Boolean dependentChildren { get; set; } // Does or does not have children
        public int incomeSource { get; set; } // How many spouses are a source of income (1 or 2)
        public double grossIncome { get; set; } // How much does the person (or both spouses) make in a year

        // Conrstructor
        public BracketModel(int martialStatus, bool dependentChildren, int incomeSource, double grossIncome)
        {
            this.martialStatus = martialStatus;
            this.dependentChildren = dependentChildren;
            this.incomeSource = incomeSource;
            this.grossIncome = grossIncome;
        }
    }
}
