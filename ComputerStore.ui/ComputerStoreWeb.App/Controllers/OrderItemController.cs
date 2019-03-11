using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerStoreWeb.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lib = ComputerStore.Library;

namespace ComputerStoreWeb.App.Controllers
{
    public class OrderItemController : Controller
    {
        public Lib.IComputerStoreRepository Repo { get; }

        public OrderItemController(Lib.IComputerStoreRepository repo)
        {
            Repo = repo;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderItemModel orderItem)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Repo.AddOrder(new Lib.OrderItem
                    {
                        Id = orderItem.Id,
                        BatchId = (int)TempData["OrderBatchId"],
                        ProductId = orderItem.ProductId,
                        Name = orderItem.Name,
                        Quantity = orderItem.Quantity,
                        Cost = orderItem.Cost
                    });
                    TempData["addToCart"] = orderItem;

                    return RedirectToAction(nameof(Index));
                }
                return View(orderItem);
            }
            catch
            {
                return View();
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