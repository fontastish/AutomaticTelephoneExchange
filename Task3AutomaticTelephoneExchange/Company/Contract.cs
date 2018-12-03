using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3AutomaticTelephoneExchange.Company;

namespace Task3AutomaticTelephoneExchange
{
    public class Contract
    {
        public string TelephoneNumber { get; private set; }
        public Subscriber Subscriber { get; private set; }
        public Tariff Tariff { get; private set; }

        public Contract(Subscriber subscriber, Tariff tariff, string number)
        {
            Subscriber = subscriber;
            Tariff = tariff;
            TelephoneNumber = number;
        }
    }
}
