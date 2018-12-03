namespace Task3AutomaticTelephoneExchange.Extra
{
    public class FullName
    {
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }

        public FullName(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }

        public override string ToString()
        {
            return FirstName+ " " + SecondName;
        }
    }
}
