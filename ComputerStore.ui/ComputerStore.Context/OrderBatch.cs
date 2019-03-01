using System;
using System.Collections.Generic;

namespace ComputerStore.Context
{
    public partial class OrderBatch
    {
        public OrderBatch()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime TimePlaced { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
