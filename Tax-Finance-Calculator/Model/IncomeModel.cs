using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Finance_Calculator.Model
{
    class IncomeModel
    {
        // Income/Earnings after tax
        public double yearlyIncome { get; set; } // How much money is made yearly
        public double monthlyIncome { get; set; } // How much money is made monthly
        public double weeklyIncome { get; set; } // How much money is made weekly
        public double taxedIncome { get; set; } // How much of your income was taxed 

        public double savingsAdvisor { get; set; } // How much you should save (10%)
        public double rentAdvisor { get; set; } // How much of your income should be spent on rent and utilities (35%)


        // Constructor
        public IncomeModel(double yearlyIncome, double monthlyIncome, double weeklyIncome, double taxedIncome, double savingsAdvisor, double rentAdvisor)
        {
            this.yearlyIncome = yearlyIncome;
            this.monthlyIncome = monthlyIncome;
            this.weeklyIncome = weeklyIncome;
            this.taxedIncome = taxedIncome;
            this.savingsAdvisor = savingsAdvisor;
            this.rentAdvisor = rentAdvisor;
        }
    }
}
