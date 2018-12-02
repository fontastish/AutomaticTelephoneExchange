using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3AutomaticTelephoneExchange.Extra;

namespace Task3AutomaticTelephoneExchange
{
    public class Subscriber
    {
        public FullName Name { get; private set; }

        public Subscriber(FullName name)
        {
            Name = name;
        }
    }
}
