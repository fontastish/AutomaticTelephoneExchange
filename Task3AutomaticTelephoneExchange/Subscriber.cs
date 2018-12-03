using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AutomaticTelephoneExchange.Company
{
    public class Subscriber
    {
        public FullName Name { get; private set; }
        public Terminal Terminal { get; set; }

        public Subscriber(FullName name)
        {
            Name = name;
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

        public void OutboundСall(string phoneNumberInterlocutor)
        {
            Terminal.OutboundСallToPort(Name, phoneNumberInterlocutor);
        }

        public void EndCall()
        {
            Terminal.EndCallToPort(Name);
        }
    }
}
