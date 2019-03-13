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
        public ICollection<OrderItemModel> Items { get; set; }
    }
}
