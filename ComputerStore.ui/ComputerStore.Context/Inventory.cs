using System;
using System.Collections.Generic;

namespace ComputerStore.Context
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int SubProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Store Store { get; set; }
        public virtual SubProduct SubProduct { get; set; }
    }
}
