using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Library;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Context
{
    public class ComputerStoreRepository : IComputerStoreRepository
    {
        private readonly Project0Context _db;

        public ComputerStoreRepository(Project0Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        //Adds
        public void AddCustomer(Library.Customer customer)
        {
            _db.Add(Mapper.Map(customer));
        }

        public void AddOrder(Library.OrderItem order)
        {
            _db.Add(Mapper.Map(order));
        }

        public void AddProduct(Library.Product product)
        {
            _db.Add(Mapper.Map(product));
        }

        public void AddStore(Library.Store store)
        {
            _db.Add(Mapper.Map(store));
        }

        //Deletes
        public void DeleteCustomer(int customerID)
        {
            _db.Remove(_db.Customer.Find(customerID));
        }

        public void DeleteOrder(int orderID)
        {
            _db.Remove(_db.OrderItem.Find(orderID));
        }

        public void DeleteProduct(int productID)
        {
            _db.Remove(_db.Product.Find(productID));
        }

        public void DeleteStore(int storeID)
        {
            _db.Remove(_db.Store.Find(storeID));
        }

        //Gets
        public IEnumerable<Library.Customer> GetCustomers()
        {
            return Mapper.Map(_db.Customer.AsNoTracking());
        }

        public IEnumerable<Library.OrderItem> GetOrders()
        {
            return Mapper.Map(_db.OrderItem.AsNoTracking());
        }

        public IEnumerable<Library.Product> GetProducts()
        {
            return Mapper.Map(_db.Product.AsNoTracking());
        }

        public IEnumerable<Library.Store> GetStores()
        {
            return Mapper.Map(_db.Store.AsNoTracking());
        }

        //Save
        public void Save()
        {
            _db.SaveChanges();
        }

        //Updates
        public void UpdateCustomer(Library.Customer customer)
        {
            _db.Entry(_db.Customer.Find(customer.ID)).CurrentValues.SetValues(Mapper.Map(customer));
        }

        public void UpdateOrder(Library.OrderItem order)
        {
            _db.Entry(_db.OrderItem.Find(order.Id)).CurrentValues.SetValues(Mapper.Map(order));
        }

        public void UpdateProduct(Library.Product product)
        {
            _db.Entry(_db.Product.Find(product.Id)).CurrentValues.SetValues(Mapper.Map(product));
        }

        public void UpdateStore(Library.Store store)
        {
            _db.Entry(_db.Store.Find(store.Id)).CurrentValues.SetValues(Mapper.Map(store));
        }
    }
}
