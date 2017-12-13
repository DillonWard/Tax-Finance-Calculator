using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax_Finance_Calculator.Model;
using Tax_Finance_Calculator.Notification_Base;
using Windows.UI.Popups;

namespace Tax_Finance_Calculator.ViewModel
{
    class BracketViewModel : NotificationBase<IncomeModel>
    {

        // Deduct the tax from gross income
        DataModel dm = new DataModel();
        double currRate;
        double currPercent;



        public double salary { get; set;}
        public double[] cutOffs { get; set; }
        public double[] rates { get; set; }

        public BracketViewModel(IncomeModel im = null) : base(im){

        }

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
                    currRate = cutOffs[2];
                    currPercent = rates[2];
                    break;

            }
            deductTax(salary, currRate, currPercent);
        }



        public void deductTax(double salary, double currentRate, double taxRate)
        {
            if(salary > currentRate)
            {
                var under = (salary / 100) * taxRate;

                var over = salary - currentRate;
                over = (salary / 100) * rates[3];

                taxedIncome = under + over;
                yearlyIncome = salary - taxedIncome;

                rentAdvisor = (yearlyIncome / 100) * 30;
                savingsAdvisor = (yearlyIncome / 100) * 10;
            }

            else
            {
                taxedIncome = (salary / 100) * taxRate;
                yearlyIncome = salary - taxedIncome;
                rentAdvisor = (yearlyIncome / 100) * 30;
                savingsAdvisor = (yearlyIncome / 100) * 10;

            }
        }

        public void noCredentialsTax()
        {
            if(salary <= cutOffs[0])
            {
                taxedIncome = (salary / 100) * rates[0];
                yearlyIncome = salary - taxedIncome;
                rentAdvisor = (yearlyIncome / 100) * 30;
                savingsAdvisor = (yearlyIncome / 100) * 10;

            }

            else if(salary > cutOffs[0] && salary < cutOffs[1])
            {
                    var under = (salary / 100) * rates[0];

                    var over = salary - cutOffs[0];
                    over = (salary / 100) * rates[1];

                    taxedIncome = under + over;
                    yearlyIncome = salary - taxedIncome;

                    rentAdvisor = (yearlyIncome / 100) * 30;
                    savingsAdvisor = (yearlyIncome / 100) * 10;

            }
        }

        public double taxedIncome
        {
            get { return This.taxedIncome; }
            set { SetProperty(This.taxedIncome, value, () => This.taxedIncome = value); }
        }
        public double yearlyIncome
        {
            get { return This.yearlyIncome; }
            set { SetProperty(This.yearlyIncome, value, () => This.yearlyIncome = value); }


        }
        public double rentAdvisor
        {
            get { return This.rentAdvisor; }
            set { SetProperty(This.rentAdvisor, value, () => This.rentAdvisor = value); }


        }
        public double savingsAdvisor
        {
            get { return This.savingsAdvisor; }
            set { SetProperty(This.savingsAdvisor, value, () => This.savingsAdvisor = value); }

        }

    }
}
