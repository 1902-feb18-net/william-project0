using System;
using System.Collections.Generic;

namespace ComputerStore.Context
{
    public partial class Customer
    {
        public Customer()
        {
            OrderBatch = new HashSet<OrderBatch>();
        }

        public int Id { get; set; }
        public int StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<OrderBatch> OrderBatch { get; set; }
    }
}
