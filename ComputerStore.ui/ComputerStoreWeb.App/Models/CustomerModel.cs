using ComputerStore.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStoreWeb.App.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Store Store { get; set; }
        public IEnumerable<OrderBatch> OrderBatches { get; set; }
    }
}
