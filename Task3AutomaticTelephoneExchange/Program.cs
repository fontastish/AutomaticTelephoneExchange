using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task3AutomaticTelephoneExchange.Company;
using Task3AutomaticTelephoneExchange.Extra;

namespace Task3AutomaticTelephoneExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "========================";

            Operator company = new Operator();                                          // Cоздаём оператора
            Subscriber abonent1 = new Subscriber(new FullName("Jack", "Woker"));            //Создаём Клиент 
            Contract contractSubscriber1 = company.NewContract(abonent1);      //Подписываем с ним контракт
            abonent1.AssignTerminal(company.GetTerminal(contractSubscriber1));                  //Выдаём терминал
            abonent1.Terminal.AssignPort(company.GetPort(contractSubscriber1));                 //Выдаём порт
            abonent1.ConnectTerminalToPort();                                                   //Подключаем терминал к порту

            Thread.Sleep(100);
            Subscriber abonent2 = new Subscriber(new FullName("Nastya", "Listova"));
            Contract contractSubscriber2 = company.NewContract(abonent2);
            abonent2.AssignTerminal(company.GetTerminal(contractSubscriber2));
            abonent2.Terminal.AssignPort(company.GetPort(contractSubscriber2));
            abonent2.ConnectTerminalToPort();

            Thread.Sleep(100);
            Subscriber abonent3 = new Subscriber(new FullName("Le Dun", "Ha"));
            Contract contractSubscriber3 = company.NewContract(abonent3);
            abonent3.AssignTerminal(company.GetTerminal(contractSubscriber3));
            abonent3.Terminal.AssignPort(company.GetPort(contractSubscriber3));
            abonent3.ConnectTerminalToPort();

            Console.WriteLine(line);

            foreach (var x in company.Contracts)
            {
                Console.WriteLine(x.TelephoneNumber);
            }

            Console.WriteLine(line);
            Thread.Sleep(1000);
            abonent1.OutboundСall(contractSubscriber2.TelephoneNumber,Tariff.Standart);

            Console.WriteLine(line);
            Thread.Sleep(1000);
            abonent3.OutboundСall(contractSubscriber2.TelephoneNumber,Tariff.Unlimited);

            Console.WriteLine(line);
            Thread.Sleep(1000);
            abonent1.EndCall();
            abonent1.DisconnectTerminalToPort();
            abonent2.EndCall();

            Console.WriteLine(line);
            abonent3.OutboundСall(contractSubscriber2.TelephoneNumber,Tariff.Unlimited);

            Console.WriteLine(line);
            
            abonent3.EndCall();
            abonent2.EndCall();
            abonent3.DisconnectTerminalToPort();
            abonent3.DisconnectTerminalToPort();
            Console.ReadKey();
        }
    }
}
