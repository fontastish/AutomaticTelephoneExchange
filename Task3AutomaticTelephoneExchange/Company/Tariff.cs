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

        public Tariff(double cost, string name)
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