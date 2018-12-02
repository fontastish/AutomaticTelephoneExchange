using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AutomaticTelephoneExchange.Company
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
    }
}
