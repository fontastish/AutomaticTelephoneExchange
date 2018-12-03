namespace Task3AutomaticTelephoneExchange.Company
{
    public class Contract
    {
        public string TelephoneNumber { get; private set; }
        public Subscriber Subscriber { get; private set; }

        public Contract(Subscriber subscriber, string number)
        {
            Subscriber = subscriber;
            TelephoneNumber = number;
        }
    }
}
