﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AutomaticTelephoneExchange.Company
{
    public class Person
    {
        public FullName Name { get; private set; }

        public Person(FullName name)
        {
            Name = name;
        }
    }
}
