using System;
using System.Collections.Generic;

namespace ComputerStore.Context
{
    public partial class SubProduct
    {
        public SubProduct()
        {
            Inventory = new HashSet<Inventory>();
            ProductGroup = new HashSet<ProductGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<ProductGroup> ProductGroup { get; set; }
    }
}
