using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Library
{
    public class Inventory
    {
        private int _storeId;
        private int _subProductId;
        private int _quantity;

        public int Id { get; set; }

        public int StoreId
        {
            get => _storeId;
            set
            {
                _storeId = value;
            }
        }

        public int SubProductId
        {
            get => _subProductId;
            set
            {
                _subProductId = value;
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

        public bool CheckAvail(int value)
        {
            return _quantity - value >= 0;
        }
    }
}
