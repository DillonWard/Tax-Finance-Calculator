using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Finance_Calculator.Model
{
    class RateModel
    {
        public double taxRate { get; set; } // Tax rate that will be returned from the database - depending on bracket

        // Constructor
        public RateModel(double taxRate)
        {
            this.taxRate = taxRate;
        }
    }
}
