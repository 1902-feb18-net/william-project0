using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Requirements for p0
/// has inventory and it decreses with orders
/// rejects orders that cannot be fulfilled
/// at least 1 product needs complexity to its order -ex computer = cpu, mb, case, gpu etc-
/// order history
/// </summary>
namespace ComputerStore.Library
{
    public class Store
    {
        private string _address;
        private string _name;

        public int Id { get; set; }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty!", nameof(value));
                }
                _name = value;
            }
        }
    }
}
