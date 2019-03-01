using System;
using System.Collections.Generic;

namespace ComputerStore.Context
{
    public partial class Store
    {
        public Store()
        {
            Customer = new HashSet<Customer>();
            Inventory = new HashSet<Inventory>();
            OrderBatch = new HashSet<OrderBatch>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderBatch> OrderBatch { get; set; }
    }
}
