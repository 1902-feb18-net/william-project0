using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Requirements for p0
/// location, customer, orderTime
/// additional bussiness rule -ex only x items per order-
/// </summary>
namespace ComputerStore.Library
{
    public class OrderItem
    {
        private int _batchId;
        private int? _productId;
        private int _quantity;
        private string _name;
        private decimal _cost;

        public int Id { get; set; }

        public int BatchId
        {
            get => _batchId;
            set
            {
                _batchId = value;
            }
        }

        public int? ProductId
        {
            get => _productId;
            set
            {
                _productId = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if(value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty", nameof(value));
                }
                _name = value;
            }
        }

        public decimal Cost
        {
            get => _cost;
            set
            {
                _cost = value;
            }
        }
        
    }
}
