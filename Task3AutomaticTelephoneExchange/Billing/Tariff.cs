using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AutomaticTelephoneExchange
{
    public class Tariff
    {
        public double CostPerMinute { get; private set; }

        public Tariff(double costPerMinute = 10)
        {
            CostPerMinute = costPerMinute;
        }
    }
}
