using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AutomaticTelephoneExchange
{
    public class Operator
    {
        public List<Contract> Contracts { get; set; }
        public List<Port> Ports { get; set; }
        public List<Terminal> Terminals { get; set; }

        private static Dictionary<Port, Terminal> allocatedTerminals = new Dictionary<Port, Terminal>();
        private static Dictionary<string, Terminal> allocatedPhoneNumber = new Dictionary<string, Terminal>();

        public Operator()
        {
            Contracts = new List<Contract>();
            Ports = new List<Port>();
            Terminals = new List<Terminal>();
        }

        public void NewContract(Contract contract)
        {
            Contracts.Add(contract);
            Ports.Add(new Port());
            Ports[Ports.Count-1].PortStateEvent += Show_Message;
            Ports[Ports.Count-1].CallStateEvent += PortCallEvent;
            Terminals.Add(new Terminal());
        }


        //Обрабатываем события порта вызываемого абонента
        private static void PortCallEvent(string message, string phoneNumber)
        {
            Console.WriteLine(message);

            Terminal terminalInterlocutor = allocatedPhoneNumber.Where(x => x.Key == phoneNumber).Select(z => z.Value)
                .FirstOrDefault();
            Port portInterlocutor = allocatedTerminals.Where(x => x.Value.Id == terminalInterlocutor.Id)
                .Select(z => z.Key).FirstOrDefault();

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
                Console.WriteLine(
                    "The subscriber terminal is not connected to the port."); //Сообщение: "Терминал абонета не подключен к порту"
            }
        }

        //Обработка событий порта вызывающего абонета
        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
