using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3AutomaticTelephoneExchange.Company;

namespace Task3AutomaticTelephoneExchange
{
    public class Operator
    {
        //private Station station;
        //private BillingSystem billing;
        private List<Contract> contracts;

        public Operator()
        {
            //station = new Station();
            //billing = new BillingSystem();
            contracts = new List<Contract>();
        }

        public Contract NewContract(Person person, Tariff tariff)
        {
            Random random = new Random();
            Contract contract = new Contract(person, tariff, "+37529"+random.Next(1000000,9999999).ToString() );
            contracts.Add(contract);

            return contract;
        }

        //public Terminal GetTerminal(Contract contract)
        //{
        //    return station.GetTerminal(contract);
        //}

        //public IEnumerable<Report> GetBillingReport(int number)
        //{
        //    var contract = contracts.SingleOrDefault(x => x.TelephoneNumber == number);
        //    return contract != null ? billing.GetBillingReport(station.CallHistory, contract) : new List<Report>();
        //}
    }
}
