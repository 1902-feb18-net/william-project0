using System;
using System.Collections.Generic;

namespace ComputerStore.Context
{
    public partial class ProductGroup
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? SubProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual SubProduct SubProduct { get; set; }
    }
}
