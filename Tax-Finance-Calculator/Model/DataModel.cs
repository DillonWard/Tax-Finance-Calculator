using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Finance_Calculator.Model
{
    class DataModel
    {
        public DataModel(string countryName, double[] taxRates, double[] percentages)
        {
            this.countryName = countryName;
            this.taxRates = taxRates;
            this.percentages = percentages;
        }

        public DataModel()
        {
            countryName = countryName;
            taxRates = taxRates;
            percentages = percentages;


        }
        public string countryName { get; set; }
        public double[] taxRates { get; set; }
        public double[] percentages { get; set; }


    }
}
