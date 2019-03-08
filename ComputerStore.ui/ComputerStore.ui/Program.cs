using ComputerStore.Context;
using ComputerStore.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using CSC = ComputerStore.Context;

namespace ComputerStore.ui
{
    class Program
    {
       public static readonly LoggerFactory AppLoggerFactory =
#pragma warning disable CS0618 // Type or member is obsolete
           new LoggerFactory(new[] {new ConsoleLoggerProvider((_,__) => true,true) });
#pragma warning restore CS0618 // Type or member is obsolete
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CSC.Project0Context>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
      //      optionsBuilder.UseLoggerFactory(AppLoggerFactory);
            var options = optionsBuilder.Options;

            var dbContext = new CSC.Project0Context(options);
            IComputerStoreRepository computerStoreRepository = new CSC.ComputerStoreRepository(dbContext);

            //Start of UI Loop
            while (true)
            {
            //label for Main Menu
            MainMenu:
                Console.Clear();
                Console.WriteLine("Computer Store Main Page\n" +
                    "\t 1. Store Options\n" +
                    "\t 2. Customer Options\n" +
                    "\t 3. Order Options\n" +
                    "\t 4. Statistics\n" +
                    "Select an option above or 'q' to quit: ");
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                    //Store Menu
                    StoreMenu:
                        Console.Clear();
                        Console.WriteLine("Store Menu\n" +
                            "\t 1. Add Store\n" +
                            "\t 2. List or Modify Stores\n" +
                            "\t 3. Add Product\n" +
                            "\t 4. List or Modify Products\n" +
                            "\t 5. Add Product Parts\n" +
                            "\t 6. List or Modify Product Parts\n" +
                            "Select an option above or 'b' to go back");
                        switch(Console.ReadLine().ToLower())
                        {
                            case "1":
                                //Add Store
                                var storeAdd = new Library.Store();
                                while(storeAdd.Name == null)
                                {
                                    Console.WriteLine("\n Enter the new store's name: ");
                                    var input = Console.ReadLine();
                                    try
                                    {
                                        storeAdd.Name = input;
                                    }
                                    catch (ArgumentException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    computerStoreRepository.AddStore(storeAdd);
                                    computerStoreRepository.Save();
                                }
                                break;
                            case "2":
                                //List Stores
                                var stores = computerStoreRepository.GetStores().ToList();
                                Console.WriteLine();
                                if (stores.Count == 0)
                                {
                                    Console.WriteLine("No available stores");
                                }
                                while (stores.Count > 0)
                                {
                                    Console.Clear();
                                    for (int ii = 1; ii <= stores.Count; ii++)
                                    {
                                        var store = stores[ii - 1];
                                        Console.WriteLine($"\t{ii}. {store.Name}\n");
                                    }
                                    Console.WriteLine("Select an option above or 'b' to go back");
                                    var input = Console.ReadLine();
                                    if(int.TryParse(input,out var storeNum) && storeNum > 0 && storeNum <= stores.Count)
                                    {
                                        var store = stores[storeNum - 1];
                                        //Label for store options menu
                                        StoreOptions:
                                        Console.Clear();
                                        Console.WriteLine($"{store.Name}\n" +
                                            "\t 1. Edit\n" +
                                            "\t 2. Delete\n" +
                                            "\t 3. Manage Inventory\n" +
                                            "Select an option abover or 'b' to go back");
                                        switch (Console.ReadLine().ToLower())
                                        {
                                            case "1":
                                                //Edit
                                                Console.Clear();
                                                Console.WriteLine($"{store.Name}\n" +
                                                    $"\t 1. Edit Name\n" +
                                                    $"\t 2. Edit Address");
                                                input = Console.ReadLine();
                                                if (input == "1")
                                                {
                                                    Console.WriteLine("\n Enter New Name: ");
                                                    input = Console.ReadLine();
                                                    try
                                                    {
                                                        store.Name = input;
                                                    }
                                                    catch (ArgumentException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                    computerStoreRepository.UpdateStore(store);
                                                    computerStoreRepository.Save();
                                                }
                                                else if (input == "2")
                                                {
                                                    Console.WriteLine("\n Enter New Address: ");
                                                    input = Console.ReadLine();
                                                    try
                                                    {
                                                        store.Address = input;
                                                    }
                                                    catch (ArgumentException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                    computerStoreRepository.UpdateStore(store);
                                                    computerStoreRepository.Save();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case "2":
                                                //Delete
                                                computerStoreRepository.DeleteStore(stores[storeNum - 1].Id);
                                                computerStoreRepository.Save();
                                                stores.RemoveAt(storeNum - 1);
                                                break;
                                            case "3":
                                            //Manage Inventory
                                            InventoryMenu:
                                                Console.Clear();
                                                Console.WriteLine("Inventory Management\n" +
                                                    "\t 1. Add new Item\n" +
                                                    "\t 2. List-Edit existing items\n" +
                                                    "Select an option above or 'b' to go back");
                                                switch (Console.ReadLine().ToLower())
                                                {
                                                    case "1":
                                                        //Add new Item
                                                        var inventoryAdd = new Library.Inventory();
                                                        inventoryAdd.StoreId = store.Id;
                                                        var subProducts = computerStoreRepository.GetSubProducts().ToList();
                                                        if (subProducts.Count == 0)
                                                        {
                                                            Console.WriteLine("No available parts");
                                                        }
                                                        while(subProducts.Count > 0)
                                                        {
                                                            Console.Clear();
                                                            for (int ii = 1; ii <= subProducts.Count; ii++)
                                                            {
                                                                var subProduct = subProducts[ii - 1];
                                                                Console.WriteLine($"\t{ii}. {subProduct.Name}");
                                                                
                                                            }
                                                            Console.WriteLine("Select and option above or 'b' to go back: ");
                                                            input = Console.ReadLine();
                                                            if (int.TryParse(input, out var partNum) && partNum > 0 && partNum <= subProducts.Count)
                                                            {
                                                                var part = subProducts[partNum - 1];
                                                                inventoryAdd.SubProductId = part.Id;
                                                                Console.WriteLine("Enter the desired quantity:");
                                                                input = Console.ReadLine();
                                                                try
                                                                {
                                                                    inventoryAdd.Quantity = int.Parse(input);
                                                                }
                                                                catch (ArgumentException ex)
                                                                {
                                                                    Console.WriteLine(ex.Message);
                                                                }
                                                                computerStoreRepository.AddInventory(inventoryAdd);
                                                                computerStoreRepository.Save();
                                                            }
                                                            else if(input == "b")
                                                            {
                                                                goto InventoryMenu;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                                Console.ReadLine();
                                                            }

                                                        }

                                                        break;
                                                    case "2":
                                                        //List\Edit Items
                                                        var inventories = (from inv in dbContext.Inventory
                                                                       join sto in dbContext.Store on inv.StoreId equals sto.Id
                                                                       join pro in dbContext.SubProduct on inv.SubProductId equals pro.Id
                                                                       where sto.Id == store.Id
                                                                       select new
                                                                       {
                                                                           Id = inv.Id,
                                                                           Name = pro.Name,
                                                                           Quantity = inv.Quantity,
                                                                           StoreId = sto.Id,
                                                                           SubProductId = pro.Id
                                                                       }).ToList();
                                                        if (inventories.Count == 0)
                                                        {
                                                            Console.WriteLine("No available parts");
                                                        }
                                                        while(inventories.Count > 0)
                                                        {
                                                            Console.Clear();
                                                            for (int ii = 1; ii <= inventories.Count; ii++)
                                                            {
                                                                var inventory = inventories[ii - 1];
                                                                Console.WriteLine($"\t{ii}. {inventory.Name}, {inventory.Quantity}");
                                                            }
                                                            Console.WriteLine("Select an option above or press 'b' to go back");
                                                            input = Console.ReadLine();
                                                            if (int.TryParse(input, out var invNum) && invNum > 0 && invNum <= inventories.Count)
                                                            {
                                                                var inventory = inventories[invNum - 1];
                                                                Console.Clear();
                                                                Console.WriteLine($"{inventory.Name}, {inventory.Quantity} ");
                                                                Console.WriteLine("\t 1. Change Quantity\n" +
                                                                    "\t 2. Delete\n" +
                                                                    "Select an option above or 'b' to go back");
                                                                switch (Console.ReadLine().ToLower())
                                                                {
                                                                    case "1":
                                                                        //change quantity
                                                                        Console.WriteLine("Enter new Quantity");
                                                                        input = Console.ReadLine();
                                                                        var inv = new Library.Inventory { Id = inventory.Id, StoreId = inventory.StoreId, SubProductId = inventory.SubProductId };
                                                                        try
                                                                        {
                                                                            inv.Quantity = int.Parse(input);
                                                                        }
                                                                        catch (ArgumentException ex)
                                                                        {
                                                                            Console.WriteLine(ex.Message);
                                                                        }
                                                                        computerStoreRepository.UpdateInventory(inv);
                                                                        computerStoreRepository.Save();

                                                                        break;
                                                                    case "2":
                                                                        //Delete
                                                                        computerStoreRepository.DeleteInventory(inventories[invNum - 1].Id);
                                                                        computerStoreRepository.Save();
                                                                        inventories.RemoveAt(invNum - 1);
                                                                        break;
                                                                    case "b":
                                                                        //go back
                                                                        goto InventoryMenu;
                                                                    default:
                                                                        Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                                        Console.ReadLine();
                                                                        break;
                                                                }
                                                            }
                                                            else if (input == "b")
                                                            {
                                                                goto InventoryMenu;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                                Console.ReadLine();
                                                            }

                                                        }
                                                        break;
                                                    case "b":
                                                        goto StoreOptions;
                                                    default:
                                                        Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                        Console.ReadLine();
                                                        goto InventoryMenu;
                                                }
                                                break;
                                            case "b":
                                                goto StoreMenu;
                                            default:
                                                Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                Console.ReadLine();
                                                goto StoreOptions;

                                        }
                                    }
                                    else if(input == "b")
                                    {
                                        goto StoreMenu;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice. Please press enter and try again");
                                        Console.ReadLine();
                                    }
                                }
                                    break;
                            case "3":
                                //Add Product 
                                var productGroupAdd = new Library.ProductGroup();
                                var productAdd = new Library.Product();
                                var subParts = computerStoreRepository.GetSubProducts().ToList();
                                while (productAdd.Name == null)
                                {
                                    Console.WriteLine("Enter the new product's name: ");
                                    var input = Console.ReadLine();
                                    try
                                    {
                                        productAdd.Name = input;
                                    }
                                    catch (ArgumentException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                while (productAdd.Cost == 0)
                                {
                                    Console.WriteLine("Enter the new product's cost: ");
                                    var input = Console.ReadLine();
                                    try
                                    {
                                        productAdd.Cost = decimal.Parse(input);
                                    }
                                    catch(ArgumentException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                computerStoreRepository.AddProduct(productAdd);
                                computerStoreRepository.Save();
                                Console.Clear();
                                if(subParts.Count == 0)
                                {
                                    Console.WriteLine("No available parts");
                                }
                                while(subParts.Count > 0)
                                {
                                    for(int ii = 1; ii <= subParts.Count; ii++)
                                    {
                                        var subPart = subParts[ii - 1];
                                        Console.WriteLine($"{ii}. {subPart.Name}");
                                    }
                                    Console.WriteLine("Select part for this product or 'b' to go back");
                                    var input = Console.ReadLine();
                                    if (int.TryParse(input, out var partNum) && partNum > 0 && partNum <= subParts.Count)
                                    {
                                        var subPart = subParts[partNum - 1];
                                        productGroupAdd.ProductId = computerStoreRepository.GetProducts().ToList().Last().Id;
                                        productGroupAdd.SubProductId = subPart.Id;
                                        computerStoreRepository.AddProductGroup(productGroupAdd);
                                        computerStoreRepository.Save();
                                    }
                                    else if (input == "b")
                                    {
                                        goto StoreMenu;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice. Please press enter and try again");
                                        Console.ReadLine();
                                    }
                                }

                                break;
                            case "4":
                                //insert List Products
                                var products = computerStoreRepository.GetProducts().ToList();
                                Console.WriteLine();
                                if(products.Count == 0)
                                {
                                    Console.WriteLine("No available products");
                                }
                                while (products.Count > 0)
                                {
                                    Console.Clear();
                                    for(int ii = 1; ii <= products.Count; ii++)
                                    {
                                        var product = products[ii - 1];
                                        Console.WriteLine($"{ii}. {product.Name}, {product.Cost}");
                                    }
                                    Console.WriteLine("Select an option above or press 'b' to go back");
                                    var input = Console.ReadLine();
                                    if (int.TryParse(input, out var productNum) && productNum > 0 && productNum <= products.Count)
                                    {
                                        var product = products[productNum - 1];
                                    //Label for part options menu
                                    ProductsOptions:
                                        Console.Clear();
                                        Console.WriteLine($"{product.Name}, {product.Cost}\n" +
                                            "\t 1. Edit\n" +
                                            "\t 2. Delete\n" +
                                            "Select an option abover or 'b' to go back");
                                        switch (Console.ReadLine().ToLower())
                                        {
                                            case "1":
                                                //Edit
                                                var newProduct = new Library.Product { Id = product.Id };
                                                while (newProduct.Name == null)
                                                {
                                                    Console.WriteLine("Enter new name: ");
                                                    input = Console.ReadLine();
                                                    try
                                                    {
                                                        newProduct.Name = input;
                                                    }
                                                    catch (ArgumentException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }
                                                while (newProduct.Cost == 0)
                                                {
                                                    Console.WriteLine("Enter new cost: ");
                                                    input = Console.ReadLine();
                                                    try
                                                    {
                                                        newProduct.Cost = decimal.Parse(input);
                                                    }
                                                    catch (ArgumentException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }
                                                computerStoreRepository.UpdateProduct(newProduct);
                                                computerStoreRepository.Save();
                                                

                                                break;
                                            case "2":
                                                //Delete
                                                computerStoreRepository.DeleteProduct(products[productNum - 1].Id);
                                                computerStoreRepository.Save();
                                                products.RemoveAt(productNum - 1);
                                                break;
                                            case "b":
                                                goto StoreMenu;
                                            default:
                                                Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                Console.ReadLine();
                                                goto ProductsOptions;

                                        }
                                    }
                                    else if (input == "b")
                                    {
                                        goto StoreMenu;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice. Please press enter and try again");
                                        Console.ReadLine();
                                    }
                                }
                                break;
                            case "5":
                                //Add Product Part
                                var subProductAdd = new Library.SubProduct();
                                while (subProductAdd.Name == null)
                                {
                                    Console.WriteLine("Enter new product part's name: ");
                                    var input = Console.ReadLine();
                                    try
                                    {
                                        subProductAdd.Name = input;
                                    }
                                    catch (ArgumentException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                computerStoreRepository.AddSubProduct(subProductAdd);
                                computerStoreRepository.Save();
                                break;
                            case "6":
                                //List Product Parts
                                var parts = computerStoreRepository.GetSubProducts().ToList();
                                Console.WriteLine();
                                if (parts.Count == 0)
                                {
                                    Console.WriteLine("No available parts");
                                }
                                while(parts.Count > 0)
                                {
                                    Console.Clear();
                                    for (int ii = 1; ii <= parts.Count; ii++)
                                    {
                                        var part = parts[ii - 1];
                                        Console.WriteLine($"\t{ii}. {part.Name}\n");
                                    }
                                    Console.WriteLine("Select an option above or 'b' to go back");
                                    var input = Console.ReadLine();
                                    if (int.TryParse(input, out var partNum) && partNum > 0 && partNum <= parts.Count)
                                    {
                                        var part = parts[partNum - 1];
                                    //Label for part options menu
                                    PartOptions:
                                        Console.Clear();
                                        Console.WriteLine($"{part.Name}\n" +
                                            "\t 1. Edit\n" +
                                            "\t 2. Delete\n" +
                                            "Select an option abover or 'b' to go back");
                                        switch (Console.ReadLine().ToLower())
                                        {
                                            case "1":
                                                //Edit
                                                var newPart = new Library.SubProduct { Id = part.Id };
                                                while (newPart.Name == null)
                                                {
                                                    Console.WriteLine("Enter new name: ");
                                                    input = Console.ReadLine();
                                                    try
                                                    {
                                                        part.Name = input;
                                                    }
                                                    catch (ArgumentException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                    computerStoreRepository.UpdateSubProduct(newPart);
                                                    computerStoreRepository.Save();
                                                }
                                                
                                                break;
                                            case "2":
                                                //Delete
                                                computerStoreRepository.DeleteSubProduct(parts[partNum - 1].Id);
                                                computerStoreRepository.Save();
                                                parts.RemoveAt(partNum - 1);
                                                break;
                                            case "b":
                                                goto StoreMenu;
                                            default:
                                                Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                Console.ReadLine();
                                                goto PartOptions;

                                        }
                                    }
                                    else if (input == "b")
                                    {
                                        goto StoreMenu;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice. Please press enter and try again");
                                        Console.ReadLine();
                                    }
                                }
                                break;
                            case "b":
                                goto MainMenu;
                            default:
                                Console.WriteLine("Invalid Choice. Please press enter and try again");
                                Console.ReadLine();
                                goto StoreMenu;
                        }
                        break;
                    case "2":
                    //Customer Menu
                    CustomerMenu:
                        Console.Clear();
                        Console.WriteLine("Customer Menu\n" +
                            "\t 1. Add new customer\n" +
                            "\t 2. Search Customer\n" +
                            "Select an option above or 'b' to go back");
                        switch (Console.ReadLine().ToLower())
                        {
                            case "1":
                                //Add new customer
                                var stores = computerStoreRepository.GetStores().ToList();
                                var customerAdd = new Library.Customer();
                                Console.Clear();
                                while (customerAdd.FirstName == null)
                                {
                                    Console.WriteLine("Enter First Name: ");
                                    try
                                    {
                                        customerAdd.FirstName = Console.ReadLine();
                                    }
                                    catch (ArgumentException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                Console.Clear();
                                while (customerAdd.LastName == null)
                                {
                                    Console.WriteLine("Enter Last Name: ");
                                    try
                                    {
                                        customerAdd.LastName = Console.ReadLine();
                                    }
                                    catch (ArgumentException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                Console.Clear();
                                while (customerAdd.StoreId == 0)
                                {
                                    Console.WriteLine("Please choose a default store");
                                    if(stores.Count == 0)
                                    {
                                        Console.WriteLine("No available stores. Press enter to return to main menu");
                                        Console.ReadLine();
                                        goto MainMenu;
                                    }
                                    while(stores.Count > 0)
                                    {
                                        for(int ii = 1; ii <= stores.Count; ii++)
                                        {
                                            var store = stores[ii - 1];
                                            Console.WriteLine($"\t {ii}. {store.Name}");
                                        }
                                        var line = Console.ReadLine();
                                        if (int.TryParse(line, out var storeNum) && storeNum > 0 && storeNum <= stores.Count)
                                        {
                                            var store = stores[storeNum - 1];
                                            customerAdd.StoreId = store.Id;
                                            computerStoreRepository.AddCustomer(customerAdd);
                                            computerStoreRepository.Save();
                                            goto CustomerMenu;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Choice. Please press enter and try again");
                                            Console.ReadLine();
                                        }
                                    }
                                }
                                break;
                            case "2":
                                //insert search customer
                                var locations = computerStoreRepository.GetStores().ToList();
                                Console.Clear();
                                Console.WriteLine("Enter Customer's FirstName, LastName");
                                var input = Console.ReadLine();
                                if (!input.Contains(","))
                                {
                                    Console.WriteLine("Incorrect Formatting. Press enter to continue");
                                    Console.ReadLine();
                                    goto CustomerMenu;
                                }
                                input = input.Replace(" ", string.Empty);
                                string[] name = input.Split(',');
                                var customerSearch = (from cus in dbContext.Customer
                                                      join sto in dbContext.Store on cus.StoreId equals sto.Id
                                                    where cus.FirstName == name[0] && cus.LastName == name[1]
                                                    select new
                                                    {
                                                        ID = cus.Id,
                                                        FirstName = cus.FirstName,
                                                        LastName = cus.LastName,
                                                        Address = cus.Address,
                                                        PhoneNumber = cus.PhoneNumber,
                                                        StoreName = sto.Name,
                                                        StoreId = sto.Id
                                                    }).ToList();
                                if(customerSearch.Count == 0)
                                {
                                    Console.WriteLine("Could not find a customer by that name. Press enter to continue");
                                    Console.ReadLine();
                                    goto CustomerMenu;
                                }
                                while(customerSearch.Count > 0)
                                {
                                    Console.Clear();
                                    for(int ii = 1; ii <= customerSearch.Count; ii++)
                                    {
                                        var customer = customerSearch[ii - 1];
                                        Console.WriteLine($" {ii}. {customer.FirstName}, {customer.LastName}, {customer.Address}, {customer.PhoneNumber}, " +
                                            $"Default: {customer.StoreName}");
                                    }
                                    Console.WriteLine("Select an option above to edit or press 'b' to go back");
                                    input = Console.ReadLine();
                                    if (int.TryParse(input, out var cusNum) && cusNum > 0 && cusNum <= customerSearch.Count)
                                    {
                                    CustomerOptions:
                                        var customerNew = new Library.Customer { ID = customerSearch[cusNum - 1].ID};
                                        Console.Clear();
                                        Console.WriteLine("Customer Options\n" +
                                            "\t 1. Change Name\n" +
                                            "\t 2. Change Address\n" +
                                            "\t 3. Change Phone Number\n" +
                                            "\t 4. Change Default Store\n" +
                                            "\t 5. Delete\n" +
                                            "Select an option above or press 'b' to go back");
                                        switch (Console.ReadLine().ToLower())
                                        {
                                            case "1":
                                                //change name
                                                customerNew.Address = customerSearch[cusNum - 1].Address;
                                                customerNew.PhoneNumber = customerSearch[cusNum - 1].PhoneNumber;
                                                customerNew.StoreId = customerSearch[cusNum - 1].StoreId;
                                                while (customerNew.FirstName == null)
                                                {
                                                    Console.WriteLine("Enter new FirstName");
                                                    try
                                                    {
                                                        customerNew.FirstName = Console.ReadLine();
                                                    }
                                                    catch (ArgumentException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }
                                                while (customerNew.LastName == null)
                                                {
                                                    Console.WriteLine("Enter new LastName");
                                                    try
                                                    {
                                                        customerNew.LastName = Console.ReadLine();
                                                    }
                                                    catch (ArgumentException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }
                                                computerStoreRepository.UpdateCustomer(customerNew);
                                                computerStoreRepository.Save();
                                                break;
                                            case "2":
                                                //change address
                                                customerNew.FirstName = customerSearch[cusNum - 1].FirstName;
                                                customerNew.LastName = customerSearch[cusNum - 1].LastName;
                                                customerNew.PhoneNumber = customerSearch[cusNum - 1].PhoneNumber;
                                                customerNew.StoreId = customerSearch[cusNum - 1].StoreId;
                                                while(customerNew.Address == null)
                                                {
                                                    Console.WriteLine("Enter new address");
                                                    try
                                                    {
                                                        customerNew.Address = Console.ReadLine();
                                                    }
                                                    catch (ArgumentException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }
                                                computerStoreRepository.UpdateCustomer(customerNew);
                                                computerStoreRepository.Save();
                                                break;
                                            case "3":
                                                //change phone number
                                                customerNew.FirstName = customerSearch[cusNum - 1].FirstName;
                                                customerNew.LastName = customerSearch[cusNum - 1].LastName;
                                                customerNew.Address = customerSearch[cusNum - 1].Address;
                                                customerNew.StoreId = customerSearch[cusNum - 1].StoreId;
                                                while(customerNew.PhoneNumber == null)
                                                {
                                                    Console.WriteLine("Enter new phone number");
                                                    try
                                                    {
                                                        customerNew.PhoneNumber = Console.ReadLine();
                                                    }
                                                    catch (ArgumentException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }
                                                computerStoreRepository.UpdateCustomer(customerNew);
                                                computerStoreRepository.Save();
                                                break;
                                            case "4":
                                                //change default store
                                                customerNew.FirstName = customerSearch[cusNum - 1].FirstName;
                                                customerNew.LastName = customerSearch[cusNum - 1].LastName;
                                                customerNew.Address = customerSearch[cusNum - 1].Address;
                                                customerNew.PhoneNumber = customerSearch[cusNum - 1].PhoneNumber;
                                                while(customerNew.StoreId == 0)
                                                {
                                                    if(locations.Count == 0)
                                                    {
                                                        Console.WriteLine("No available Stores");
                                                    }
                                                    while(locations.Count > 0)
                                                    {
                                                        for (int ii = 1; ii <= locations.Count; ii++)
                                                        {
                                                            var store = locations[ii - 1];
                                                            Console.WriteLine($" {ii}. {store.Name}");
                                                        }
                                                        Console.WriteLine("Select an option above");
                                                        input = Console.ReadLine();
                                                        if (int.TryParse(input, out var stoNum) && stoNum > 0 && stoNum <= locations.Count)
                                                        {
                                                            var store = locations[stoNum - 1];
                                                            customerNew.StoreId = store.Id;
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                }
                                                computerStoreRepository.UpdateCustomer(customerNew);
                                                computerStoreRepository.Save();
                                                break;
                                            case "b":
                                                goto CustomerMenu;
                                            default:
                                                Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                Console.ReadLine();
                                                goto CustomerOptions;
                                        }
                                    }
                                    else if(input == "b")
                                    {
                                        goto CustomerMenu;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice. Please press enter and try again");
                                        Console.ReadLine();
                                    }
                                }

                                break;
                            case "b":
                                goto MainMenu;
                            default:
                                Console.WriteLine("Invalid Choice. Please press enter and try again");
                                Console.ReadLine();
                                goto CustomerMenu;
                        }
                        break;
                    case "3":
                    //Order Menu
                    OrderMenu:
                        Console.Clear();
                        Console.WriteLine("Order Menu\n" +
                            "\t 1. Place Order\n" +
                            "\t 2. List Orders by Customer\n" +
                            "\t 3. List Orders by Store\n" +
                            "Select an option above or press 'b' to go back");
                        switch(Console.ReadLine().ToLower())
                        {
                            case "1":
                                //insert Place order
                                var cart = new List<Library.OrderItem>();
                                var products = computerStoreRepository.GetProducts().ToList();
                                var locations = computerStoreRepository.GetStores().ToList();
                                Console.Clear();
                                Console.WriteLine("Enter Customer's FirstName, LastName");
                                var input = Console.ReadLine();
                                if (!input.Contains(","))
                                {
                                    Console.WriteLine("Incorrect Formatting. Press enter to continue");
                                    Console.ReadLine();
                                    goto OrderMenu;
                                }
                                input = input.Replace(" ", string.Empty);
                                string[] name = input.Split(',');
                                var customerSearch = (from cus in dbContext.Customer
                                                      join sto in dbContext.Store on cus.StoreId equals sto.Id
                                                      where cus.FirstName == name[0] && cus.LastName == name[1]
                                                      select new
                                                      {
                                                          ID = cus.Id,
                                                          FirstName = cus.FirstName,
                                                          LastName = cus.LastName,
                                                          Address = cus.Address,
                                                          PhoneNumber = cus.PhoneNumber,
                                                          StoreName = sto.Name,
                                                          StoreId = sto.Id
                                                      }).ToList();
                                   
                                if (customerSearch.Count == 0)
                                {
                                    Console.WriteLine("Could not find a customer by that name. Press enter to continue");
                                    Console.ReadLine();
                                    goto CustomerMenu;
                                }
                                while (customerSearch.Count > 0)
                                {
                                    Console.Clear();
                                    for (int ii = 1; ii <= customerSearch.Count; ii++)
                                    {
                                        var customer = customerSearch[ii - 1];
                                        Console.WriteLine($" {ii}. {customer.FirstName}, {customer.LastName}");
                                    }
                                    Console.WriteLine("Select an option above to edit or press 'b' to go back");
                                    input = Console.ReadLine();
                                    if (int.TryParse(input, out var cusNum) && cusNum > 0 && cusNum <= customerSearch.Count)
                                    {
                                    OrderOptions:
                                        Console.Clear();
                                        var pros = computerStoreRepository.GetProducts().ToList();
                                        var curBatchId = computerStoreRepository.GetOrderBatches().ToList().Last().Id + 1;
                                        var curItemId = computerStoreRepository.GetOrders().ToList().Last().Id + 1;
                                        decimal totalCost = 0;
                                        if( pros.Count == 0)
                                        {
                                            Console.WriteLine("No available products");
                                            goto OrderMenu;
                                        }
                                        while ( pros.Count > 0)
                                        {
                                            var orderBatchAdd = new Library.OrderBatch();
                                            var orderItemAdd = new Library.OrderItem();
                                            var inventoryUp = new Library.Inventory();
                                            Console.Clear();
                                            for(int ii = 1; ii <= pros.Count; ii++)
                                            {
                                                var pro = pros[ii - 1];
                                                Console.WriteLine($" {ii}. {pro.Name}, {pro.Cost}");
                                            }
                                            Console.WriteLine($"\nCurrent Cart: Total ${totalCost}");
                                            for(int ii = 0; ii < cart.Count; ii++)
                                            {
                                                Console.WriteLine($" {cart[ii].Name}, {cart[ii].Quantity}, {cart[ii].Cost}");
                                            }
                                            Console.WriteLine("Select an option above to add to cart or press 'b' to go back or 'c' to checkout");
                                            input = Console.ReadLine();
                                            if (int.TryParse(input, out var proNum) && proNum > 0 && proNum <= pros.Count)
                                            {
                                                var invSearch = (from inv in dbContext.Inventory
                                                                 join sto in dbContext.Store on inv.StoreId equals sto.Id
                                                                 join pro in dbContext.ProductGroup on inv.SubProductId equals pro.SubProductId
                                                                 where sto.Id == customerSearch[cusNum - 1].StoreId && pro.Id == pros[proNum -1].Id
                                                                 select new
                                                                 {
                                                                     ID = inv.Id,
                                                                     Quantity = inv.Quantity,
                                                                     StoreID = inv.StoreId,
                                                                     SubProductID = inv.SubProductId
                                                                 }).ToList();
                                                inventoryUp.Quantity = invSearch[0].Quantity;
                                                orderItemAdd.ProductId = pros[proNum - 1].Id;
                                                orderItemAdd.Name = pros[proNum - 1].Name;
                                                Console.WriteLine("Enter amount: ");
                                                input = Console.ReadLine().ToLower();
                                                int temp;
                                                var num = int.TryParse(input, out temp) ? int.Parse(input) : (int?)null;
                                                if (num == null)
                                                {
                                                    Console.WriteLine("Invalid input. Press enter to continue");
                                                    Console.ReadLine();
                                                }
                                                else if (!inventoryUp.CheckAvail((int)num))
                                                {
                                                    Console.WriteLine("Not enough iventory available. Press enter to continue");
                                                    Console.ReadLine();
                                                    goto OrderOptions;
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        orderItemAdd.Quantity = (int)num;
                                                    }
                                                    catch (ArgumentException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                    //inventory update
                                                    inventoryUp.Id = invSearch[0].Quantity - (int)num;
                                                    inventoryUp.Quantity -= (int)num;
                                                    inventoryUp.StoreId = invSearch[0].StoreID;
                                                    inventoryUp.SubProductId = invSearch[0].SubProductID;
                                                    computerStoreRepository.UpdateInventory(inventoryUp);
                                                    //order batch add
                                                    orderBatchAdd.CustomerId = customerSearch[0].ID;
                                                    orderBatchAdd.StoreId = customerSearch[0].StoreId;
                                                    orderBatchAdd.Id = curBatchId;
                                                    curBatchId++;
                                                    //order item add
                                                    orderItemAdd.Cost = orderItemAdd.Quantity * pros[proNum - 1].Cost;
                                                    orderItemAdd.BatchId = orderBatchAdd.Id;
                                                    orderItemAdd.Id = curItemId;
                                                    curItemId++;
                                                    totalCost += orderItemAdd.Cost;
                                                    cart.Add(orderItemAdd);
                                                    computerStoreRepository.AddOrderBatch(orderBatchAdd);
                                                    computerStoreRepository.AddOrder(orderItemAdd);
                                                }
                                            }
                                            else if (input == "b")
                                            {
                                                goto OrderMenu;
                                            }
                                            else if(input == "c")
                                            {
                                                //checkout
                                                computerStoreRepository.Save();
                                                goto OrderMenu;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                Console.ReadLine();
                                                goto OrderOptions;
                                            }


                                        }

                                    }
                                    else if (input == "b")
                                    {
                                        goto OrderMenu;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice. Please press enter and try again");
                                        Console.ReadLine();
                                    }
                                }
                                break;
                            case "2":
                            //List by Customer
                            OrderCustomer:
                                var customers = computerStoreRepository.GetCustomers().ToList();
                                var orders = computerStoreRepository.GetOrders().ToList();
                                if(customers.Count == 0)
                                {
                                    Console.WriteLine("No available customers");
                                    goto OrderMenu;
                                }
                                while(customers.Count > 0)
                                {
                                    Console.Clear();
                                    for(int ii = 1; ii <= customers.Count; ii++)
                                    {
                                        var customer = customers[ii - 1];
                                        Console.WriteLine($"{ii}. {customer.FirstName}, {customer.LastName}");
                                    }
                                    Console.WriteLine("Select an option above or press 'b' to go back");
                                    input = Console.ReadLine();
                                    if (int.TryParse(input, out var cusNum) && cusNum > 0 && cusNum <= customers.Count)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Choose Sort Type\n" +
                                            "\t 1. Price Ascending\n" +
                                            "\t 2. Price Descending\n" +
                                            "\t 3. Most Recent\n" +
                                            "\t 4. Oldest\n" +
                                            "Select an option above or press 'b' to go back");
                                        switch (Console.ReadLine().ToLower())
                                        {
                                            case "1":
                                                //insert p asc
                                                var cAsc = (from sto in dbContext.Store
                                                            join oBat in dbContext.OrderBatch on sto.Id equals oBat.StoreId
                                                            join oItem in dbContext.OrderItem on oBat.Id equals oItem.BatchId
                                                            where oBat.CustomerId == customers[cusNum - 1].ID
                                                            orderby oItem.Cost
                                                            select new
                                                            {
                                                                Name = oItem.Name,
                                                                Cost = oItem.Cost,
                                                                Time = oBat.TimePlaced,
                                                                Sto = sto.Name
                                                            }).ToList();
                                                for(int ii = 1; ii <= cAsc.Count; ii++)
                                                {
                                                    var line = cAsc[ii - 1];
                                                    Console.WriteLine($"{ii}. {line.Name}, {line.Cost}, {line.Sto}, {line.Time} ");
                                                }
                                                Console.WriteLine("Press Enter to continue");
                                                Console.ReadLine();
                                                break;
                                            case "2":
                                                //insert p desc
                                                var cDesc = (from sto in dbContext.Store
                                                            join oBat in dbContext.OrderBatch on sto.Id equals oBat.StoreId
                                                            join oItem in dbContext.OrderItem on oBat.Id equals oItem.BatchId
                                                             where oBat.CustomerId == customers[cusNum - 1].ID
                                                             orderby oItem.Cost descending
                                                            select new
                                                            {
                                                                Name = oItem.Name,
                                                                Cost = oItem.Cost,
                                                                Time = oBat.TimePlaced,
                                                                Sto = sto.Name
                                                            }).ToList();
                                                for (int ii = 1; ii <= cDesc.Count; ii++)
                                                {
                                                    var line = cDesc[ii - 1];
                                                    Console.WriteLine($"{ii}. {line.Name}, {line.Cost}, {line.Sto}, {line.Time} ");
                                                }
                                                Console.WriteLine("Press Enter to continue");
                                                Console.ReadLine();
                                                break;
                                            case "3":
                                                //insert date desc
                                                var dDesc = (from sto in dbContext.Store
                                                            join oBat in dbContext.OrderBatch on sto.Id equals oBat.StoreId
                                                            join oItem in dbContext.OrderItem on oBat.Id equals oItem.BatchId
                                                             where oBat.CustomerId == customers[cusNum - 1].ID
                                                             orderby oBat.TimePlaced descending
                                                            select new
                                                            {
                                                                Name = oItem.Name,
                                                                Cost = oItem.Cost,
                                                                Time = oBat.TimePlaced,
                                                                Sto = sto.Name
                                                            }).ToList();
                                                for (int ii = 1; ii <= dDesc.Count; ii++)
                                                {
                                                    var line = dDesc[ii - 1];
                                                    Console.WriteLine($"{ii}. {line.Name}, {line.Cost}, {line.Sto}, {line.Time} ");
                                                }
                                                Console.WriteLine("Press Enter to continue");
                                                Console.ReadLine();
                                                break;
                                            case "4":
                                                //insert date asc
                                                var dAsc = (from sto in dbContext.Store
                                                            join oBat in dbContext.OrderBatch on sto.Id equals oBat.StoreId
                                                            join oItem in dbContext.OrderItem on oBat.Id equals oItem.BatchId
                                                            where oBat.CustomerId == customers[cusNum - 1].ID
                                                            orderby oBat.TimePlaced
                                                            select new
                                                            {
                                                                Name = oItem.Name,
                                                                Cost = oItem.Cost,
                                                                Time = oBat.TimePlaced,
                                                                Sto = sto.Name
                                                            }).ToList();
                                                for (int ii = 1; ii <= dAsc.Count; ii++)
                                                {
                                                    var line = dAsc[ii - 1];
                                                    Console.WriteLine($"{ii}. {line.Name}, {line.Cost}, {line.Sto}, {line.Time} ");
                                                }
                                                Console.WriteLine("Press Enter to continue");
                                                Console.ReadLine();
                                                break;
                                            case "b":
                                                goto OrderMenu;
                                            default:
                                                Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                Console.ReadLine();
                                                goto OrderCustomer;
                                        }
                                    }
                                    else if(input == "b")
                                    {
                                        goto OrderMenu;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice. Please press enter and try again");
                                        Console.ReadLine();
                                    }
                                }
                                break;
                            case "3":
                                //List by Store
                                var stores = computerStoreRepository.GetStores().ToList();
                                if(stores.Count == 0)
                                {
                                    Console.WriteLine("No available stores");
                                    goto OrderMenu;
                                }
                                while(stores.Count > 0)
                                {
                                    Console.Clear();
                                    for (int ii = 1; ii <= stores.Count; ii++)
                                    {
                                        var store = stores[ii - 1];
                                        Console.WriteLine($"{ii}. {store.Name}");
                                    }
                                    Console.WriteLine("Select an option above or press 'b' to go back");
                                    input = Console.ReadLine();
                                    if (int.TryParse(input, out var stoNum) && stoNum > 0 && stoNum <= stores.Count)
                                    {
                                        OrderStore:
                                        Console.Clear();
                                        Console.WriteLine("Choose Sort Type\n" +
                                            "\t 1. Price Ascending\n" +
                                            "\t 2. Price Descending\n" +
                                            "\t 3. Most Recent\n" +
                                            "\t 4. Oldest\n" +
                                            "Select an option above or press 'b' to go back");
                                        switch (Console.ReadLine().ToLower())
                                        {
                                            case "1":
                                                //insert p asc
                                                var cAsc = (from cus in dbContext.Customer
                                                            join oBat in dbContext.OrderBatch on cus.Id equals oBat.CustomerId
                                                            join oItem in dbContext.OrderItem on oBat.Id equals oItem.BatchId
                                                            where oBat.StoreId == stores[stoNum - 1].Id
                                                            orderby oItem.Cost
                                                            select new
                                                            {
                                                                Name = oItem.Name,
                                                                Cost = oItem.Cost,
                                                                Time = oBat.TimePlaced,
                                                                FirstName = cus.FirstName
                                                            }).ToList();
                                                for (int ii = 1; ii <= cAsc.Count; ii++)
                                                {
                                                    var line = cAsc[ii - 1];
                                                    Console.WriteLine($"{ii}. {line.FirstName}, {line.Name}, {line.Cost}, {line.Time} ");
                                                }
                                                Console.WriteLine("Press Enter to continue");
                                                Console.ReadLine();
                                                break;
                                            case "2":
                                                //insert p desc
                                                var cDesc = (from cus in dbContext.Customer
                                                            join oBat in dbContext.OrderBatch on cus.Id equals oBat.CustomerId
                                                            join oItem in dbContext.OrderItem on oBat.Id equals oItem.BatchId
                                                            where oBat.StoreId == stores[stoNum - 1].Id
                                                            orderby oItem.Cost descending
                                                            select new
                                                            {
                                                                Name = oItem.Name,
                                                                Cost = oItem.Cost,
                                                                Time = oBat.TimePlaced,
                                                                FirstName = cus.FirstName
                                                            }).ToList();
                                                for (int ii = 1; ii <= cDesc.Count; ii++)
                                                {
                                                    var line = cDesc[ii - 1];
                                                    Console.WriteLine($"{ii}. {line.FirstName}, {line.Name}, {line.Cost}, {line.Time} ");
                                                }
                                                Console.WriteLine("Press Enter to continue");
                                                Console.ReadLine();
                                                break;
                                            case "3":
                                                //insert date desc
                                                var dDesc = (from cus in dbContext.Customer
                                                            join oBat in dbContext.OrderBatch on cus.Id equals oBat.CustomerId
                                                            join oItem in dbContext.OrderItem on oBat.Id equals oItem.BatchId
                                                            where oBat.StoreId == stores[stoNum - 1].Id
                                                            orderby oBat.TimePlaced descending
                                                            select new
                                                            {
                                                                Name = oItem.Name,
                                                                Cost = oItem.Cost,
                                                                Time = oBat.TimePlaced,
                                                                FirstName = cus.FirstName
                                                            }).ToList();
                                                for (int ii = 1; ii <= dDesc.Count; ii++)
                                                {
                                                    var line = dDesc[ii - 1];
                                                    Console.WriteLine($"{ii}. {line.FirstName}, {line.Name}, {line.Cost}, {line.Time} ");
                                                }
                                                Console.WriteLine("Press Enter to continue");
                                                Console.ReadLine();
                                                break;
                                            case "4":
                                                //insert date asc
                                                var dAsc = (from cus in dbContext.Customer
                                                            join oBat in dbContext.OrderBatch on cus.Id equals oBat.CustomerId
                                                            join oItem in dbContext.OrderItem on oBat.Id equals oItem.BatchId
                                                            where oBat.StoreId == stores[stoNum - 1].Id
                                                            orderby oBat.TimePlaced
                                                            select new
                                                            {
                                                                Name = oItem.Name,
                                                                Cost = oItem.Cost,
                                                                Time = oBat.TimePlaced,
                                                                FirstName = cus.FirstName
                                                            }).ToList();
                                                for (int ii = 1; ii <= dAsc.Count; ii++)
                                                {
                                                    var line = dAsc[ii - 1];
                                                    Console.WriteLine($"{ii}. {line.FirstName}, {line.Name}, {line.Cost}, {line.Time} ");
                                                }
                                                Console.WriteLine("Press Enter to continue");
                                                Console.ReadLine();
                                                break;
                                            case "b":
                                                goto OrderMenu;
                                            default:
                                                Console.WriteLine("Invalid Choice. Please press enter and try again");
                                                Console.ReadLine();
                                                goto OrderStore;
                                        }
                                    }
                                    else if (input == "b")
                                    {
                                        goto OrderMenu;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice. Please press enter and try again");
                                        Console.ReadLine();
                                    }
                                }
                                break;
                            case "b":
                                goto MainMenu;
                            default:
                                Console.WriteLine("Invalid Choice. Please press enter and try again");
                                Console.ReadLine();
                                goto OrderMenu;
                        }
                        break;
                    case "4":
                        //insert Statistics
                        Console.Clear();
                        Console.WriteLine("Biggest Spender:");
                        var priceSearch = (from order in dbContext.OrderItem
                                           join batch in dbContext.OrderBatch on order.BatchId equals batch.Id
                                           join custom in dbContext.Customer on batch.CustomerId equals custom.Id
                                           group order by custom.FirstName into g
                                           select new
                                           {
                                               Name = g.Key,
                                               Sum = g.Sum(order => order.Cost)
                                           }).ToList().Last();
                        Console.WriteLine($"{priceSearch.Name}, ${priceSearch.Sum}");
                        Console.WriteLine("\nBest performing store: ");
                        var storeSearch = (from order in dbContext.OrderItem
                                           join batch in dbContext.OrderBatch on order.BatchId equals batch.Id
                                           join store in dbContext.Store on batch.StoreId equals store.Id
                                           group order by store.Name into g
                                           select new
                                           {
                                               Name = g.Key,
                                               Sum = g.Sum(order => order.Cost)
                                           }).ToList().Last();
                        Console.WriteLine($"{storeSearch.Name}, ${storeSearch.Sum}");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case "q":
                        goto exit;
                    default:
                        Console.WriteLine("Invalid Choice. Please press enter and try again");
                        Console.ReadLine();
                        goto MainMenu;
                }
            }
        //Label for exiting program
        exit:
            Console.WriteLine("Exiting Program");
        }
    }
}
