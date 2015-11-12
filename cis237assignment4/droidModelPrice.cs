using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    /// <summary>
    /// A class for holding droid base prices
    /// </summary>
    class droidModelPrice
    {
        public droidModelPrice(string Model, decimal Price)
        {
            price = Price;
            model = Model;
        }
        public decimal price;
        public string model;
    }
}
