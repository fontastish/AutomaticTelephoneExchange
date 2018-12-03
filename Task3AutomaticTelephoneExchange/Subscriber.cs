using System.Collections.Generic;
using Task3AutomaticTelephoneExchange.Billing;
using Task3AutomaticTelephoneExchange.Company;
using Task3AutomaticTelephoneExchange.Extra;

namespace Task3AutomaticTelephoneExchange
{
    public class Subscriber
    {
        public FullName Name { get; private set; }
        public Terminal Terminal { get; set; }
        public List<CallHistory> CallHistory { get; set; }

        public Subscriber(FullName name)
        {
            Name = name;
            CallHistory=new List<CallHistory>();
        }

        public void AssignTerminal(Terminal terminal)
        {
            Terminal = terminal;
        }

        public void ConnectTerminalToPort()
        {
            Terminal.ConnectToPort(Name);
        }

        public void DisconnectTerminalToPort()
        {
            Terminal.DisconnectToPort(Name);
        }

        public void OutboundСall(string phoneNumberInterlocutor,Tariff tariff)
        {
            Terminal.OutboundСallToPort(Name, phoneNumberInterlocutor);
            CallHistory.Add(new CallHistory(phoneNumberInterlocutor,tariff));
        }

        public void EndCall()
        {
            Terminal.EndCallToPort(Name);
        }
    }
}
