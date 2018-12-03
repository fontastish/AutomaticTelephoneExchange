using System;

namespace Task3AutomaticTelephoneExchange.Company
{
    public class CallHistory
    {
        public int Duration { get; private set; }
        public string TargetTelephoneNumber { get; }
        public Guid Id { get; }
        public double Cost { get; set; }

        public CallHistory(string targetTelephoneNumber,Tariff tariff)
        {
            Random random = new Random();
            Duration = random.Next(10);
            TargetTelephoneNumber = targetTelephoneNumber;
            Id = Guid.NewGuid();
            Cost = tariff.CostOfMinute * Duration;

        }
    }
}
