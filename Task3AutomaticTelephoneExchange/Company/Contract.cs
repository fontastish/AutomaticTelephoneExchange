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
        public Person Person { get; private set; }
        public Tariff Tariff { get; private set; }

        public Contract(Person person, Tariff tariff, string number)
        {
            Person = person;
            Tariff = tariff;
            TelephoneNumber = number;
        }
    }
}
