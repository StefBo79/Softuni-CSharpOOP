using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double milliliters = 50;
        private const decimal price = 3.50M;
        public Coffee(string name, double caffeine) 
            : base(name, price, milliliters)
        {
            this.Caffeine = caffeine;
        }
        public double Caffeine { get; set; }       

    }
}
