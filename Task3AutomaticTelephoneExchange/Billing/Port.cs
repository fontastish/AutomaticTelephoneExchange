using Task3AutomaticTelephoneExchange.Company;
using Task3AutomaticTelephoneExchange.Extra;

namespace Task3AutomaticTelephoneExchange.Billing
{
    public class Port
    {
        public bool ConnectionTerminal { get; private set; } = false;
        public bool TalkState { get; private set; } = false; //Состояние разговара

        public delegate void PortStatus(string message);
        public delegate void CallStatus(string message, string phoneNumberInterlocutor);
        public event PortStatus PortStateEvent;
        public event CallStatus CallStateEvent;

        public void Connect(FullName name)
        {
            ConnectionTerminal = true;

            if (PortStateEvent != null)
            {
                PortStateEvent($"Abonent " + name + " connected the terminal to the port."); //Сообщение: "Абонент ФИО подключил терминал к порту"
            }
        }

        public void Disconnect(FullName name)
        {
            ConnectionTerminal = false;

            if (PortStateEvent != null)
            {
                PortStateEvent($"Abonent " + name + " disconnected the terminal from the port.");  //Сообщение: "Абонент ФИО отключил терминал от порта"
            }
        }

        //Исходящий вызов
        public void OutboundСall(FullName name, string phoneNumberInterlocutor)
        {
            if (CallStateEvent != null)
            {
                TalkState = true;
                CallStateEvent($"Abonent " + name + " calls the caller by phone number " + phoneNumberInterlocutor, phoneNumberInterlocutor); // Сообщение: "Абонент ФИО вызывает абонета по номеру телефона"
            }
        }

        //Входящий вызов
        public void IncomingCall(string phoneNumberInterlocutor, Terminal terminalInterlocutor)
        {
            TalkState = true;
            terminalInterlocutor.IncomingСall();
        }

        //Закончить звонок
        public void EndCall(FullName name)
        {
            TalkState = false;
            PortStateEvent($"Abonent " + name + " the call ended.");
        }
    }
}
