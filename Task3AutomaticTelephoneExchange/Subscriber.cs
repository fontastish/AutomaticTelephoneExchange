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
    }
}
