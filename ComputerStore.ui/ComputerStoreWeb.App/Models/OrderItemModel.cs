using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStoreWeb.App.Models
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

    }
}
