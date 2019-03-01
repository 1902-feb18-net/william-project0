using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


/// <summary>
/// Requirements for p0
/// location, customer, orderTime
/// additional bussiness rule -ex only x items per order-
/// </summary>
namespace ComputerLib.Library
{
    public class Order
    {
        private int _total;
        private DateTime _date;

        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute("Store")]
        public int StoreId { get; set; }

        [XmlAttribute("Customer")]
        public int CustomerId { get; set; }

        [XmlAttribute("Total Price")]
        public int Total
        {
            get => _total;
            set
            {
                _total = value;
            }
        }

        [XmlAttribute("Time")]
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
            }
        }
    }
}
