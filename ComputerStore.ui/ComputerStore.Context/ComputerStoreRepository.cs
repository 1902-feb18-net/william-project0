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

        public void AddInventory(Library.Inventory inventory)
        {
            _db.Add(Mapper.Map(inventory));
        }

        public void AddOrderBatch(Library.OrderBatch orderBatch)
        {
            _db.Add(Mapper.Map(orderBatch));
        }

        public void AddProductGroup(Library.ProductGroup productGroup)
        {
            _db.Add(Mapper.Map(productGroup));
        }

        public void AddSubProduct(Library.SubProduct subProduct)
        {
            _db.Add(Mapper.Map(subProduct));
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

        public void DeleteInventory(int inventoryID)
        {
            _db.Remove(_db.Inventory.Find(inventoryID));
        }

        public void DeleteOrderBatch(int orderBatchID)
        {
            _db.Remove(_db.OrderBatch.Find(orderBatchID));
        }

        public void DeleteProductGroup(int productGroupID)
        {
            _db.Remove(_db.ProductGroup.Find(productGroupID));
        }

        public void DeleteSubProduct(int subProductID)
        {
            _db.Remove(_db.SubProduct.Find(subProductID));
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

        public IEnumerable<Library.Inventory> GetInventories()
        {
            return Mapper.Map(_db.Inventory.AsNoTracking());
        }

        public IEnumerable<Library.OrderBatch> GetOrderBatches()
        {
            return Mapper.Map(_db.OrderBatch.AsNoTracking());
        }

        public IEnumerable<Library.ProductGroup> GetProductGroups()
        {
            return Mapper.Map(_db.ProductGroup.AsNoTracking());
        }

        public IEnumerable<Library.SubProduct> GetSubProducts()
        {
            return Mapper.Map(_db.SubProduct.AsNoTracking());
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

        public void UpdateInventory(Library.Inventory inventory)
        {
            _db.Entry(_db.Inventory.Find(inventory.Id)).CurrentValues.SetValues(Mapper.Map(inventory));
        }

        public void UpdateOrderBatch(Library.OrderBatch orderBatch)
        {
            _db.Entry(_db.OrderBatch.Find(orderBatch.Id)).CurrentValues.SetValues(Mapper.Map(orderBatch));
        }

        public void UpdateProductGroup(Library.ProductGroup productGroup)
        {
            _db.Entry(_db.ProductGroup.Find(productGroup.Id)).CurrentValues.SetValues(Mapper.Map(productGroup));
        }

        public void UpdateSubProduct(Library.SubProduct subProduct)
        {
            _db.Entry(_db.SubProduct.Find(subProduct.Id)).CurrentValues.SetValues(Mapper.Map(subProduct));
        }
    }
}
