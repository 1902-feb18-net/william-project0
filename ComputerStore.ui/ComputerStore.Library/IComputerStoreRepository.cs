using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Library
{
    public interface IComputerStoreRepository
    {
        IEnumerable<Store> GetStores();
        void AddStore(Store store);
        void DeleteStore(int storeID);
        void UpdateStore(Store store);

        IEnumerable<Customer> GetCustomers();
        void AddCustomer(Customer customer);
        void DeleteCustomer(int customerID);
        void UpdateCustomer(Customer customer);

        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void DeleteProduct(int productID);
        void UpdateProduct(Product product);

        IEnumerable<OrderItem> GetOrders();
        void AddOrder(OrderItem order);
        void DeleteOrder(int orderID);
        void UpdateOrder(OrderItem order);

        void Save();
    }
}
