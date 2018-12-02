using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AutomaticTelephoneExchange
{
    public class Contract
    {
        public Guid ID { get; private set; }  //id контракта
        public Subscriber Subscriber { get; private set; }
        public string PhoneNumber { get; private set; } //Мобильный телефон
        public DateTime DateOfSigning { get; private set; }
        public int Balance { get; private set; }

        public Contract(Subscriber subscriber)
        {
            Random random = new Random();
            ID =Guid.NewGuid();
            PhoneNumber = "+37529" + random.Next(1000000, 99999999).ToString();
            DateOfSigning = DateTime.Now;
            Balance = 10000;
            this.Subscriber = subscriber;
        }
    }
}
