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
namespace ComputerStore.Library
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _phoneNumber;
        private int _storeId;

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

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
            }
        }
        public int StoreId
        {
            get => _storeId;
            set
            {
                _storeId = value;
            }
            
        }
    }
}
