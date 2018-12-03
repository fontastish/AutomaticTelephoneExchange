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


        private static Dictionary<Port, Terminal> allocatedTerminals = new Dictionary<Port, Terminal>();
        private static Dictionary<string, Terminal> allocatedPhoneNumber = new Dictionary<string, Terminal>();

        public Station(List<Contract> contracts, List<Port> ports, List<Terminal> terminals)
        {
            Contracts = new List<Contract>();
            Ports = new List<Port>();
            Terminals = new List<Terminal>();
        }


        public Contract NewContract(Person person, Tariff tariff)
        {
            Random random = new Random();
            Contract contract = new Contract(person, tariff, "+37529" + random.Next(1000000, 9999999).ToString());
            Contracts.Add(contract);
            var port = new Port();
            Ports.Add(port);
            port.PortStateEvent += Show_Message;
            port.CallStateEvent += PortCallEvent;
            Terminals.Add(new Terminal());
            return contract;
        }



        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }













        


        //Обрабатываем события порта вызываемого абонента
        private static void PortCallEvent(string message, string phoneNumber)
        {
            Console.WriteLine(message);

            Terminal terminalInterlocutor = allocatedPhoneNumber.Where(x => x.Key == phoneNumber).Select(z => z.Value).FirstOrDefault();
            Port portInterlocutor = allocatedTerminals.Where(x => x.Value.Id == terminalInterlocutor.Id).Select(z => z.Key).FirstOrDefault();

            if (portInterlocutor.ConnectionTerminal == true)
            {
                if (portInterlocutor.TalkState == false)
                {
                    portInterlocutor.IncomingCall(phoneNumber, terminalInterlocutor);
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
