using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tax_Finance_Calculator
{
    public class TaxRates
    {

        public string Id { get; set; }

        public string countryName { get; set; }

        public double first_rate { get; set; }
        public double second_rate { get; set; }
        public double third_rate { get; set; }
        public double fourth_rate { get; set; }

        public double first_cutoff { get; set; }
        public double second_cutoff { get; set; }
        public double third_cutoff { get; set; }
        public double fourth_cutoff { get; set; }

    }
}