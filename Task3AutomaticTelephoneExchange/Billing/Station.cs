using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AutomaticTelephoneExchange.Company
{
    public class Station
    {
        public List<Contract> Contracts { get; set; }
        public List<Port> Ports { get; set; }
        public List<Terminal> Terminals { get; set; }

        public Station()
        {
            Contracts = new List<Contract>();
            Ports = new List<Port>();
            Terminals = new List<Terminal>();
        }


        public Contract NewContract(Subscriber subscriber, Tariff tariff)
        {
            Random random = new Random();
            Contract contract = new Contract(subscriber, tariff, "+37529" + random.Next(1000000, 9999999).ToString());
            Contracts.Add(contract);
            var port = new Port();
            Ports.Add(port);
            port.PortStateEvent += Show_Message;
            port.CallStateEvent += PortCallEvent;
            Terminals.Add(new Terminal());
            return contract;
        }

        public Terminal GetTerminal(Contract contract)
        {
            var index = Contracts.FindIndex(x => x == contract);
            return Terminals[index];
        }

        public Port GetPort(Contract contract)
        {
            var index = Contracts.FindIndex(x => x == contract);
            return Ports[index];
        }

        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }


        //Обрабатываем события порта вызываемого абонента
        private void PortCallEvent(string message, string phoneNumber)
        {
            Console.WriteLine(message);
            var indexSubscriber = Contracts.FindIndex(x => x.TelephoneNumber == phoneNumber);

            if (Ports[indexSubscriber].ConnectionTerminal == true)
            {
                if (Ports[indexSubscriber].TalkState == false)
                {
                    Ports[indexSubscriber].IncomingCall(phoneNumber, Terminals[indexSubscriber]);
                }
                else
                {
                    Console.WriteLine("Line is busy."); //Сообщение: "Линия занята"
                }
            }
            else
            {
                Console.WriteLine("The subscriber terminal is not connected to the port."); //Сообщение: "Терминал абонета не подключен к порту"
            }
        }


        //Обработка событий порта вызывающего абонета

    }
    
}
