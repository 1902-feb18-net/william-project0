using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Lib = ComputerStore.Library;

namespace ComputerStoreWeb.App.Models
{
    public class OrderItemModel
    {
        
        public int Id { get; set; }
        public int BatchId { get; set; }
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public IEnumerable<Lib.Product> Products { get; set; }

    }
}
