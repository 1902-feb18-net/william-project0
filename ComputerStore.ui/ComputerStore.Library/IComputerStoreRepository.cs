using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Library
{
    public interface IComputerStoreRepository
    {
         IEnumerable<OrderBatch> GetLocal();


        IEnumerable<Store> GetStores(string search);
        Store GetStoreById(int id);
        void AddStore(Store store);
        void DeleteStore(int storeID);
        void UpdateStore(Store store);

        IEnumerable<Customer> GetCustomers(string search);
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void DeleteCustomer(int customerID);
        void UpdateCustomer(Customer customer);

        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void DeleteProduct(int productID);
        void UpdateProduct(Product product);

        IEnumerable<OrderItem> GetOrders();
        IEnumerable<OrderItem> GetOrdersByBatch(int batchId);
        OrderItem GetOrderById(int Id);
        void AddOrder(OrderItem order);
        void DeleteOrder(int orderID);
        void UpdateOrder(OrderItem order);

        IEnumerable<OrderBatch> GetOrderBatches();
        IEnumerable<OrderBatch> GetOrderBatchesByCustomer(int customerId);
        IEnumerable<OrderBatch> GetOrderBatchesByStore(int storeId);
        OrderBatch GetOrderBatchById(int Id);
        void AddOrderBatch(OrderBatch orderBatch);
        void DeleteOrderBatch(int orderBatchID);
        void UpdateOrderBatch(OrderBatch orderBatch);

        IEnumerable<Inventory> GetInventories();
        IEnumerable<Inventory> GetInventoriesByStore(int Id);
        void AddInventory(Inventory inventory);
        void DeleteInventory(int inventoryID);
        void UpdateInventory(Inventory inventory);

        IEnumerable<ProductGroup> GetProductGroups();
        void AddProductGroup(ProductGroup productGroup);
        void DeleteProductGroup(int productGroupID);
        void UpdateProductGroup(ProductGroup productGroup);

        IEnumerable<SubProduct> GetSubProducts();
        void AddSubProduct(SubProduct subProduct);
        void DeleteSubProduct(int subProductID);
        void UpdateSubProduct(SubProduct subProduct);

        void Save();
    }
}
