﻿using System;
using Task3AutomaticTelephoneExchange.Company;
using Task3AutomaticTelephoneExchange.Extra;

namespace Task3AutomaticTelephoneExchange.Billing
{
    public class Terminal
    {
        public delegate void Call(string message);
        public event Call IncomingСallEvent;

        public Port Port { get; set; }

        public Terminal()
        {
            IncomingСallEvent += IncomingСallMessage;
        }

        public void AssignPort(Port port)
        {
            Port = port;
        }

        public void ConnectToPort(FullName name)
        {
            if (Port.ConnectionTerminal == false)
            {
                Port.Connect(name);
            }
            else
            {
                Console.WriteLine("Warning!!! The terminal is already connected to the port."); // Сообщение: "Предупреждение!!! Терминал уже подключен к порту"
            }
        }

        public void DisconnectToPort(FullName name)
        {
            if (Port.ConnectionTerminal == true)
            {
                Port.Disconnect(name);
            }
            else
            {
                Console.WriteLine("Warning!!! The terminal is already disconnected from the port."); //Сообщение: "Предупреждение!!! Терминал уже отсоединен от порта"
            }
        }

        public void OutboundСallToPort(FullName name, string phoneNumberInterlocutor)  //Исходящий вызов
        {
            if (Port.ConnectionTerminal == true)
            {
                if (phoneNumberInterlocutor != "")
                {
                    Port.OutboundСall(name, phoneNumberInterlocutor);
                }
                else
                {
                    Console.WriteLine("A call can not be made. You did not enter a phone number."); //Сообщение: "Вызов невозможен. Вы не указали номер телефона"
                }
            }
            else
            {
                Console.WriteLine("You can not make calls. the terminal is not connected to the port"); //Сообщение: "Вы не можете делать звонки. терминал не подключен к порту"  
            }
        }

        public void EndCallToPort(FullName name) //Закончить звонок
        {
            Port.EndCall(name);
        }

        public void IncomingСall() //Входящий вызов 
        {
            IncomingСallEvent($"Abonent received an incoming call"); // Сообщение: "Абонент ФИО принял входящий вызов"
        }


        private static void IncomingСallMessage(string message) // обрабатываем событие входящего вызова
        {
            Console.WriteLine(message);
        }
    }
}
