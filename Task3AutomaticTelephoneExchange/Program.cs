using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3AutomaticTelephoneExchange.Company;

namespace Task3AutomaticTelephoneExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            Station company = new Station();
            Subscriber abonent1 = new Subscriber(new FullName("Jack", "Woker"));
            Contract contractSubscriber1 = company.NewContract(abonent1, Tariff.Standart);
            abonent1.AssignTerminal(company.GetTerminal(contractSubscriber1));
            abonent1.Terminal.AssignPort(company.GetPort(contractSubscriber1));
            abonent1.ConnectTerminalToPort();

            Subscriber abonent2 = new Subscriber(new FullName("Nastya", "Listova"));
            Contract contractSubscriber2 = company.NewContract(abonent2, Tariff.Standart);
            abonent2.AssignTerminal(company.GetTerminal(contractSubscriber2));
            abonent2.Terminal.AssignPort(company.GetPort(contractSubscriber2));
            abonent2.ConnectTerminalToPort();

            abonent1.Outbound—all(contractSubscriber2.TelephoneNumber);
            Console.ReadKey();
        }
    }
}
