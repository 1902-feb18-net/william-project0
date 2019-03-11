using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerStore.Context
{
    public static class Mapper
    {
        //Customer mapping
        public static Library.Customer Map(Customer customer) => new Library.Customer
        {
            ID = customer.Id,
            StoreId = customer.StoreId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Address = customer.Address,
            PhoneNumber = customer.PhoneNumber,
        };

        public static Customer Map(Library.Customer customer) => new Customer
        {
            Id = customer.ID,
            StoreId = customer.StoreId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Address = customer.Address,
            PhoneNumber = customer.PhoneNumber,
        };

        public static IEnumerable<Library.Customer> Map(IEnumerable<Customer> customers) => customers.Select(Map);

        public static IEnumerable<Customer> Map(IEnumerable<Library.Customer> customers) => customers.Select(Map);
        //End Customer mapping

        //Store mapping
        public static Library.Store Map(Store store) => new Library.Store
        {
            Id = store.Id,
            Name = store.Name,
            Address = store.Address
        };

        public static Store Map(Library.Store store) => new Store
        {
            Id = store.Id,
            Name = store.Name,
            Address = store.Address
        };

        public static IEnumerable<Library.Store> Map(IEnumerable<Store> stores) => stores.Select(Map);

        public static IEnumerable<Store> Map(IEnumerable<Library.Store> stores) => stores.Select(Map);
        //End Store mapping

        //Order mapping
        public static Library.OrderItem Map(OrderItem order) => new Library.OrderItem
        {
            Id = order.Id,
            BatchId = order.BatchId,
            ProductId = order.ProductId,
            Quantity = order.Quantity,
            Name = order.Name,
            Cost = order.Cost
        };

        public static OrderItem Map(Library.OrderItem order) => new OrderItem
        {
            Id = order.Id,
            BatchId = order.BatchId,
            ProductId = order.ProductId,
            Quantity = order.Quantity,
            Name = order.Name,
            Cost = order.Cost
        };

        public static IEnumerable<Library.OrderItem> Map(IEnumerable<OrderItem> orders) => orders.Select(Map);

        public static IEnumerable<OrderItem> Map(IEnumerable<Library.OrderItem> orders) => orders.Select(Map);
        //End Order mapping

        //Product mapping
        public static Library.Product Map(Product product) => new Library.Product
        {
            Id = product.Id,
            Name = product.Name,
            Cost = product.Cost
        };

        public static Product Map(Library.Product product) => new Product
        {
            Id = product.Id,
            Name = product.Name,
            Cost = product.Cost
        };

        public static IEnumerable<Library.Product> Map(IEnumerable<Product> products) => products.Select(Map);

        public static IEnumerable<Product> Map(IEnumerable<Library.Product> products) => products.Select(Map);
        //End Product mapping

        //Inventory mapping
        public static Library.Inventory Map(Inventory inventory) => new Library.Inventory
        {
            Id = inventory.Id,
            StoreId = inventory.StoreId,
            SubProductId = inventory.SubProductId,
            Quantity = inventory.Quantity
        };

        public static Inventory Map(Library.Inventory inventory) => new Inventory
        {
            Id = inventory.Id,
            StoreId = inventory.StoreId,
            SubProductId = inventory.SubProductId,
            Quantity = inventory.Quantity
        };

        public static IEnumerable<Library.Inventory> Map(IEnumerable<Inventory> inventories) => inventories.Select(Map);

        public static IEnumerable<Inventory> Map(IEnumerable<Library.Inventory> inventories) => inventories.Select(Map);
        //End Inventory mapping

        //OrderBatch mapping
        public static Library.OrderBatch Map(OrderBatch orderBatch) => new Library.OrderBatch
        {
            Id = orderBatch.Id,
            StoreId = orderBatch.StoreId,
            CustomerId = orderBatch.CustomerId,
            Date = orderBatch.TimePlaced,
            Items = Map(orderBatch.OrderItem).ToList()
        };

        public static OrderBatch Map(Library.OrderBatch orderBatch) => new OrderBatch
        {
            Id = orderBatch.Id,
            StoreId = orderBatch.StoreId,
            CustomerId = orderBatch.CustomerId,
            TimePlaced = orderBatch.Date,
            OrderItem = Map(orderBatch.Items).ToList()
        };

        public static IEnumerable<Library.OrderBatch> Map(IEnumerable<OrderBatch> batches) => batches.Select(Map);

        public static IEnumerable<OrderBatch> Map(IEnumerable<Library.OrderBatch> batches) => batches.Select(Map);
        //End OrderBatch mapping

        //ProductGroup mapping
        public static Library.ProductGroup Map(ProductGroup productGroup) => new Library.ProductGroup
        {
            Id = productGroup.Id,
            ProductId = productGroup.ProductId,
            SubProductId = productGroup.SubProductId
        };

        public static ProductGroup Map(Library.ProductGroup productGroup) => new ProductGroup
        {
            Id = productGroup.Id,
            ProductId = productGroup.ProductId,
            SubProductId = productGroup.SubProductId
        };

        public static IEnumerable<Library.ProductGroup> Map(IEnumerable<ProductGroup> groups) => groups.Select(Map);

        public static IEnumerable<ProductGroup> Map(IEnumerable<Library.ProductGroup> groups) => groups.Select(Map);
        //End ProductGroup mapping

        //SubProduct mapping
        public static Library.SubProduct Map(SubProduct subProduct) => new Library.SubProduct
        {
            Id = subProduct.Id,
            Name = subProduct.Name
        };

        public static SubProduct Map(Library.SubProduct subProduct) => new SubProduct
        {
            Id = subProduct.Id,
            Name = subProduct.Name
        };

        public static IEnumerable<Library.SubProduct> Map(IEnumerable<SubProduct> subProducts) => subProducts.Select(Map);

        public static IEnumerable<SubProduct> Map(IEnumerable<Library.SubProduct> subProducts) => subProducts.Select(Map);
        //End SubProduct mapping



    }
}
