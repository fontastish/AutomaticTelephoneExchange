using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3AutomaticTelephoneExchange.Extra;

namespace Task3AutomaticTelephoneExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            Operator company = new Operator();

            company.NewContract(new Contract(new Subscriber(new FullName("Vanya", "Petrov"))));
            company.NewContract(new Contract(new Subscriber(new FullName("Nastya", "Listov"))));

            Console.ReadKey();
        }
    }
}
