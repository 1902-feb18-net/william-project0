using System;
using System.Collections.Generic;

namespace ComputerStoreWeb.App.Models
{
    public class OrderBatchModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderItemModel> Items { get; set; }
    }
}
