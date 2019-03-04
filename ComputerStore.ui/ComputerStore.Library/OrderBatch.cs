using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Library
{
    public class OrderBatch
    {
        private int _storeId;
        private int _customerId;
        private DateTime _date;

        public int Id { get; set; }

        public int StoreId
        {
            get => _storeId;
            set
            {
                _storeId = value;
            }
        }

        public int CustomerId
        {
            get => _customerId;
            set
            {
                _customerId = value;
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
