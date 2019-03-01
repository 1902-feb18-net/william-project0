using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

/// <summary>
/// Requirements for p0
/// name, etc
/// default store
/// cannot place orders from same location per 2hrs
/// </summary>
namespace ComputerLib.Library
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;
        private int _localStoreId;

        [XmlAttribute]
        public int ID { get; set; }

        [XmlAttribute("First Name")]
        public string FirstName
        {
            get => _firstName;
            set
            {
                if(value.Length == 0)
                {
                    throw new ArgumentException("First name must not be empty!", nameof(value));
                }
                _firstName = value;
            }
        }

        [XmlAttribute("Last Name")]
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Last name must not be empty!", nameof(value));
                }
                _lastName = value;
            }
        }
        [XmlAttribute("Local Store")]
        public int LocalStoreId
        {
            get => _localStoreId;
            set
            {
                _localStoreId = value;
            }
            
        }

        public List<Order> orderHistory = new List<Order>();
    }
}
