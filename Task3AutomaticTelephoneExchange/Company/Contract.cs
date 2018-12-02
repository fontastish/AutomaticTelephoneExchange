using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AutomaticTelephoneExchange
{
    public class Contract
    {
        public int TelephoneNumber { get; private set; }
        public Client Subscriber { get; private set; }
        public Tariff Tariff { get; private set; }

        public Contract(Client subscriber, Tariff tariff, int number)
        {
            Subscriber = subscriber;
            Tariff = tariff;
            TelephoneNumber = number;
        }
    }
}
