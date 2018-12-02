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
            Operator company = new Operator();
            Tariff standartTariff = new Tariff(10,"Standart");
            Contract contractSubscriber1 = company.NewContract(new Person(new FullName("Jack", "Woker")), standartTariff);
            Contract contractSubscriber2 = company.NewContract(new Person(new FullName("Nastya", "Listova")), standartTariff);

            //company.NewContract(new Contract(new Subscriber(new FullName("Vanya", "Petrov"))));
            //company.NewContract(new Contract(new Subscriber(new FullName("Nastya", "Listov"))));

            Console.ReadKey();
        }
    }
}
