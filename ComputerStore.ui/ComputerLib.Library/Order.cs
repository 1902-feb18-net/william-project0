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
namespace ComputerLib.Library
{
    class Order
    {
        private int _total;
        private DateTime _date;

        public int Id { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public int Total
        {
            get => _total;
            set
            {
                _total = value;
            }
        }
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
