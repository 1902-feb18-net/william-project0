using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int ID { get; set; }

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

        public int LocalStoreId
        {
            get => _localStoreId;
            set
            {
                _localStoreId = value;
            }
            
        }
    }
}
