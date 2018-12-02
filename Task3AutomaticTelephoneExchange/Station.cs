using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AutomaticTelephoneExchange.Company
{
    public class Station
    {
        //public IEnumerable<CallHistory> CallHistory => callHistory;

        private Dictionary<int, Port> usersData;
        private List<Tuple<int, int, Guid>> connections;
        private List<CallHistory> callHistory { get; set; }

        public event EventHandler CallCompleted = (object sender, EventArgs e) => { };

        public Station()
        {
            usersData = new Dictionary<int, Port>();
            connections = new List<Tuple<int, int, Guid>>();
            callHistory = new List<CallHistory>();
        }

        public Terminal GetTerminal(Contract contract)
        {
            Port port = new Port();
            port.CallEvent += Port_CallEvent;
            port.AnswerEvent += Port_AnswerEvent;
            port.RejectEvent += Port_RejectEvent;

            usersData.Add(contract.TelephoneNumber, port);
            Terminal terminal = new Terminal(contract.TelephoneNumber);

            terminal.OutgoingCallEvent += port.OutgoingCall;
            terminal.CallStartedEvent += port.CallStarted;
            terminal.CallStoppedEvent += port.CallStopped;

            terminal.ConnectEvent += port.Connect;
            terminal.DisconnectEvent += port.Disconnect;

            port.IncomingCallEvent += terminal.IncomingCall;

            return terminal;
        }

        private void Port_CallEvent(object sender, CallEventArgs e)
        {
            if (usersData.ContainsKey(e.TargetTelephoneNumber)) // если целевой номер присутсвует
            {
                if (e.TargetTelephoneNumber != e.SenderTelephoneNumber) // если вызывающий номер не равен целевому
                {
                    // извлекаем номера аобнентов
                    int senderNumber = e.SenderTelephoneNumber;
                    int targetNumber = e.TargetTelephoneNumber;

                    // определяем порты
                    Port senderPort = usersData[senderNumber];
                    Port targetPort = usersData[targetNumber];


                    if (targetPort.State == Port.PortState.Connected)
                    {
#if DEBUG
                        Console.WriteLine("Station  -> Port_CallEvent");
#endif
                        connections.Add(Tuple.Create(e.SenderTelephoneNumber, e.TargetTelephoneNumber, e.Id));
                        targetPort.IncomingCall(senderNumber, targetNumber, e.Id);  // вызываем целевой порт
                    }
                }
                else
                {
                    Console.WriteLine("You try to call yourself");
                }
            }
            else
            {
                Console.WriteLine("This number does not exist");
            }
        }

        private void Port_AnswerEvent(object sender, AnswerEventArgs e)
        {
            var currntConnection = connections.SingleOrDefault(x => x.Item3 == e.Id);

            if (currntConnection != null)
            {
#if DEBUG
                Console.WriteLine("Station  -> Port_AnswerEvent");
#endif
                Port targetPort = usersData[e.TargetTelephoneNumber];

                callHistory.Add(new CallHistory(
                    senderTelephoneNumber: currntConnection.Item1,
                    targetTelephoneNumber: currntConnection.Item2,
                    startCall: DateTime.Now,
                    id: e.Id
                    ));
            }
        }

        private void Port_RejectEvent(object sender, RejectEventArgs e)
        {
            var currntConnection = connections.SingleOrDefault(x => x.Item3 == e.Id);
            var inf = CallHistory.SingleOrDefault(x => x.Id == e.Id);

            if (currntConnection != null)
            {
                int senderNumber = currntConnection.Item1;
                int targetNumber = currntConnection.Item2;

                Port senderPort = usersData[senderNumber];
                Port targetPort = usersData[targetNumber];

                if (senderNumber == e.TelephoneNumber)
                {
                    targetPort.Reset();
                }
                else if (targetNumber == e.TelephoneNumber)
                {
                    senderPort.Reset();
                }

#if DEBUG 
                Console.WriteLine("Station  -> Port_RejectEvent");
#endif
                if (inf != null)
                {
                    inf.EndCall = DateTime.Now;
#if DEBUG
                    Console.WriteLine("Sender: {0}\tTarget: {1}\tDuration: {2} sec\n", senderNumber, targetNumber, inf.CallDuration.Seconds);
#endif
                }

                connections.Remove(currntConnection);

            }
        }
    }
}
