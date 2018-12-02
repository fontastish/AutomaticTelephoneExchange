using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AutomaticTelephoneExchange
{
    public class Operator
    {
        private Station station;
        private BillingSystem billing;
        private List<Contract> contracts;

        public Operator()
        {
            station = new Station();
            billing = new BillingSystem();
            contracts = new List<Contract>();
        }

        public Contract NewContract(Client subscriber, Tariff type, int number)
        {
            Contract contract = new Contract(subscriber, type, number);
            contracts.Add(contract);

            return contract;
        }

        public Terminal GetTerminal(Contract contract)
        {
            return station.GetTerminal(contract);
        }

        public IEnumerable<Report> GetBillingReport(int number)
        {
            var contract = contracts.SingleOrDefault(x => x.TelephoneNumber == number);
            return contract != null ? billing.GetBillingReport(station.CallHistory, contract) : new List<Report>();
        }
    }
}
