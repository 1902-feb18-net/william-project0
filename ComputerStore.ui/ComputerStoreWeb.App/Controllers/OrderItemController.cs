using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerStoreWeb.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lib = ComputerStore.Library;

namespace ComputerStoreWeb.App.Controllers
{
    public class OrderItemController : Controller
    {
        public Lib.IComputerStoreRepository Repo { get; }

        private readonly ILogger<OrderItemController> _logger;

        public OrderItemController(Lib.IComputerStoreRepository repo, ILogger<OrderItemController> logger)
        {
            Repo = repo;
            _logger = logger;
        }

        // GET: OrderItem
        public ActionResult Index(int batchId)
        {
            IEnumerable<Lib.OrderItem> orders = Repo.GetOrdersByBatch(batchId);
            IEnumerable<OrderItemModel> webOrders = orders.Select(x => new OrderItemModel
            {
                Id = x.Id,
                BatchId = x.BatchId,
                ProductId = x.ProductId,
                Name = x.Name,
                Quantity = x.Quantity,
                Cost = x.Cost
            });
            return View(webOrders);
        }

        // GET: OrderItem......for stores
        public ActionResult StoreIndex(int batchId)
        {
            IEnumerable<Lib.OrderItem> orders = Repo.GetOrdersByBatch(batchId);
            IEnumerable<OrderItemModel> webOrders = orders.Select(x => new OrderItemModel
            {
                Id = x.Id,
                BatchId = x.BatchId,
                ProductId = x.ProductId,
                Name = x.Name,
                Quantity = x.Quantity,
                Cost = x.Cost
            });
            return View(webOrders);
        }

        // GET: OrderItem/Details/5
        public ActionResult Details(int id)
        {
            Lib.OrderItem libOrder = Repo.GetOrderById(id);
            var webOrder = new OrderItemModel
            {
                Id = libOrder.Id,
                BatchId = libOrder.BatchId,
                ProductId = libOrder.ProductId,
                Name = libOrder.Name,
                Quantity = libOrder.Quantity,
                Cost = libOrder.Cost
            };
            return View(webOrder);
        }
        
        // GET: OrderItem/Details/5.......Store
        public ActionResult StoreDetails(int id)
        {
            Lib.OrderItem libOrder = Repo.GetOrderById(id);
            var webOrder = new OrderItemModel
            {
                Id = libOrder.Id,
                BatchId = libOrder.BatchId,
                ProductId = libOrder.ProductId,
                Name = libOrder.Name,
                Quantity = libOrder.Quantity,
                Cost = libOrder.Cost
            };
            return View(webOrder);
        }

        // GET: OrderItem/Create
        public ActionResult Create(OrderBatchModel order)
        {
            var viewModel = new OrderItemModel
            {
                Products = Repo.GetProducts(),
                BatchId = order.Id,
            };
            return View(viewModel);
        }

        // POST: OrderItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderItemModel orderItem, int? garbage)
        {
            orderItem.Products = Repo.GetProducts();
            
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //Lib.OrderItem temp = new Lib.OrderItem
                    //{
                    //    BatchId = orderItem.BatchId,
                    //    ProductId = orderItem.ProductId,
                    //    Name = orderItem.Products.Where(p => p.Id == orderItem.ProductId).First().Name,
                    //    Quantity = orderItem.Quantity,
                    //    Cost = orderItem.Products.Where(p => p.Id == orderItem.ProductId).First().Cost * orderItem.Quantity
                    //};
                    TempData["ItemBatch"] = orderItem.BatchId;
                    TempData["ItemProduct"] = orderItem.ProductId;
                    TempData["ItemName"] = orderItem.Products.Where(p => p.Id == orderItem.ProductId).First().Name;
                    TempData["ItemQuantity"] = orderItem.Quantity;
                    TempData["ItemCost"] = orderItem.Products.Where(p => p.Id == orderItem.ProductId).First().Cost * orderItem.Quantity;
                    TempData.Keep();
                    //Repo.AddOrder(temp);

                    return RedirectToAction("WorkingIndex","Order",TempData);
                }

                return View(orderItem);
            }
            catch
            {
                return View(orderItem);
            }
        }

        // GET: OrderItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderItem/Edit/5
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

        // GET: OrderItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderItem/Delete/5
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