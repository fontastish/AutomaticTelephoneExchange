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
            Contract contractSubscriber1 = company.NewContract(new Person(new FullName("Jack", "Woker")), Tariff.Standart);
            Contract contractSubscriber2 = company.NewContract(new Person(new FullName("Nastya", "Listova")), Tariff.Standart);



            Console.ReadKey();
        }
    }
}
