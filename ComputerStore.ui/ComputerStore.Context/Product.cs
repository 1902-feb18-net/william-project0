using System;
using System.Collections.Generic;

namespace ComputerStore.Context
{
    public partial class Product
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
            ProductGroup = new HashSet<ProductGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual ICollection<ProductGroup> ProductGroup { get; set; }
    }
}
