using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

/// <summary>
/// Requirements for p0
/// has inventory and it decreses with orders
/// rejects orders that cannot be fulfilled
/// at least 1 product needs complexity to its order -ex computer = cpu, mb, case, gpu etc-
/// order history
/// </summary>
namespace ComputerLib.Library
{
    public class Store
    {
        private string _location;

        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute("Store Name")]
        public string Location
        {
            get => _location;
            set
            {
                if(value.Length == 0)
                {
                    throw new ArgumentException("Location name must not be empty", nameof(value));
                }
                _location = value;
            }
        }

        public List<Order> orderHistory = new List<Order>();
    }
}
