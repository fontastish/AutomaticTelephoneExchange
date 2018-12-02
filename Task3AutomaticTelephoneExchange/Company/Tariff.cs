using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AutomaticTelephoneExchange
{
    public class Tariff
    {
        public string Name { get; private set; }
        public double CostOfMinute { get; private set; }

        public static readonly Tariff Standart = new Tariff(TariffName.Standart.ToString(), 10);
        public static readonly Tariff Mega = new Tariff(TariffName.Mega.ToString(), 12);
        public static readonly Tariff Unlimited = new Tariff(TariffName.Unlimited.ToString(), 9);

        public Tariff(string name, double cost)
        {
            Name = name;
            CostOfMinute = cost;
        }

        //public double GetCostOfMinute(CallType type)
        //{
        //    switch (type)
        //    {
        //        case CallType.Incoming: return CostOfMinuteOutgoingCall;
        //        case CallType.Outgoing: return CostOfMinuteIncomingCall;
        //        default: return 0;
        //    }
        //}
    }
}