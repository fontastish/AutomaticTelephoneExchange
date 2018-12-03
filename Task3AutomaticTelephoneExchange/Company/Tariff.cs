namespace Task3AutomaticTelephoneExchange.Company
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

    }
}