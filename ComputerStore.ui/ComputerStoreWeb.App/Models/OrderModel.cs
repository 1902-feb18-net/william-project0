using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lib = ComputerStore.Library;

namespace ComputerStoreWeb.App.Models
{
    public class OrderModel
    {
        public Lib.OrderBatch OrderBatch { get; set; }
        public IEnumerable<OrderItemModel> Items { get; set; }
        public IEnumerable<Lib.ProductGroup> Products { get; set; }
        public IEnumerable<Lib.SubProduct> SubProducts { get; set; }
    }
}
