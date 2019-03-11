using ComputerStore.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStoreWeb.App.Models
{
    public class StoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public IEnumerable<Inventory> inventories { get; set; } = new List<Inventory>();
    }
}
