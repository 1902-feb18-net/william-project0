using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerStoreWeb.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Lib = ComputerStore.Library;

namespace ComputerStoreWeb.App.Controllers
{
    public class OrderController : Controller
    {
        public Lib.IComputerStoreRepository Repo { get; }
        private readonly ILogger<OrderController> _logger;

        public OrderController(Lib.IComputerStoreRepository repo, ILogger<OrderController> logger)
        {
            Repo = repo;
            _logger = logger;
        }

        // GET: Order
        public ActionResult Index(CustomerModel customer)
        {
            OrderModel order = new OrderModel();
            order.OrderBatch = new Lib.OrderBatch();
            order.Items = new List<OrderItemModel>();
            order.OrderBatch.Id = Repo.GetOrderBatches().Max(o => o.Id) + 1;
            order.OrderBatch.StoreId = customer.StoreId;
            order.OrderBatch.Date = DateTime.Now;
            order.OrderBatch.CustomerId = customer.Id;

            TempData["BatchID"] = order.OrderBatch.Id;
            TempData["StoreID"] = order.OrderBatch.StoreId;
            TempData["CustomerID"] = order.OrderBatch.CustomerId;
            TempData["Date"] = order.OrderBatch.Date;

            TempData["Cart"] = JsonConvert.SerializeObject(order);
            return View(order);
        }

        public ActionResult WorkingIndex(OrderModel model)
        {
            //OrderModel order = new OrderModel();
            var order = JsonConvert.DeserializeObject<OrderModel>(TempData["Cart"].ToString());

            //order.OrderBatch = new Lib.OrderBatch();
            //order.Items = new List<OrderItemModel>();
            //order.OrderBatch.Id = (int)TempData["BatchID"];
            //order.OrderBatch.StoreId = (int)TempData["StoreID"];
            //order.OrderBatch.CustomerId = (int)TempData["CustomerID"];
            //order.OrderBatch.Date = (DateTime)TempData["Date"];
            // IEnumerable<Lib.OrderItem> libItems = Repo.GetLocalOrdersByBatch(order.OrderBatch.Id);
            //order.Items = libItems.Select(x => new OrderItemModel
            //{
            //    Id = x.Id,
            //    BatchId = x.BatchId,
            //    ProductId = x.ProductId,
            //    Name = x.Name,
            //    Quantity = x.Quantity,
            //    Cost = x.Cost
            //});
            order.Items.Add(new OrderItemModel
            {
                BatchId = (int)TempData["ItemBatch"],
                ProductId = (int)TempData["ItemProduct"],
                Name = (string)TempData["ItemName"],
                Quantity = (int)TempData["ItemQuantity"],
                Cost = Convert.ToDecimal(TempData["ItemCost"])
            });
            TempData["Cart"] = JsonConvert.SerializeObject(order);

            TempData.Keep();
            return View(order);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var order = JsonConvert.DeserializeObject<OrderModel>(TempData["Cart"].ToString());
            try
            {
                Repo.AddOrderBatch(new Lib.OrderBatch
                {
                    Id = order.OrderBatch.Id,
                    CustomerId = order.OrderBatch.CustomerId,
                    StoreId = order.OrderBatch.StoreId,
                   Date = order.OrderBatch.Date
                });
                var test = Repo.GetLocal();
                Repo.Save();

            }
            catch
            {
                return View();
            }
            foreach (var item in order.Items)
            {
                try
                {
                    // TODO: Add insert logic here
                    var tId = Repo.GetOrders().Last().Id + 1;
                    Repo.AddOrder(new Lib.OrderItem
                    {
                        Id = tId,
                        BatchId = order.OrderBatch.Id,
                        ProductId = item.ProductId,
                        Name = item.Name,
                        Quantity = item.Quantity,
                        Cost = item.Cost
                    });
                    Repo.Save();
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Customer", null);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var order = JsonConvert.DeserializeObject<OrderModel>(TempData["Cart"].ToString());
            try
            {
                Repo.AddOrderBatch(new Lib.OrderBatch
                {
                    CustomerId = order.OrderBatch.CustomerId,
                    StoreId = order.OrderBatch.StoreId,
                    Date = order.OrderBatch.Date
                });
                Repo.Save();
            }
            catch
            {
                return View();
            }
            foreach (var item in order.Items)
            {
                try
                {
                    // TODO: Add insert logic here
                    Repo.AddOrder(new Lib.OrderItem
                    {
                        BatchId = order.OrderBatch.Id,
                        ProductId = item.ProductId,
                        Name = item.Name,
                        Quantity = item.Quantity,
                        Cost = item.Cost
                    });
                    Repo.Save();
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Customer", null);

        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}