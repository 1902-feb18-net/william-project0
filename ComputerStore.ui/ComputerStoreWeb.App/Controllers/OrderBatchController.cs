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
    public class OrderBatchController : Controller
    {
        public Lib.IComputerStoreRepository Repo { get; }

        private readonly ILogger<OrderBatchController> _logger;

        public OrderBatchController(Lib.IComputerStoreRepository repo, ILogger<OrderBatchController> logger)
        {
            Repo = repo;
            _logger = logger;
        }

        // GET: OrderBatch
        public ActionResult Index(int customerId)
        {
            IEnumerable<Lib.OrderBatch> libOrder = Repo.GetOrderBatchesByCustomer(customerId);
            IEnumerable<OrderBatchModel> webOrder = libOrder.Select(x => new OrderBatchModel
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                StoreId = x.StoreId,
                Date = x.Date,
                Items = x.Items.Select(y => new OrderItemModel())
            });
            
            return View(webOrder);
        }

        //GET: OrderBatch ....From store page
        public ActionResult StoreIndex(int storeId)
        {
            IEnumerable<Lib.OrderBatch> libOrder = Repo.GetOrderBatchesByStore(storeId);
            IEnumerable<OrderBatchModel> webOrder = libOrder.Select(x => new OrderBatchModel
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                StoreId = x.StoreId,
                Date = x.Date,
                Items = x.Items.Select(y => new OrderItemModel())
            });
            return View(webOrder);
        }

        // GET: OrderBatch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderBatch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderBatch/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderBatchModel orderBatch)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Repo.AddOrderBatch(new Lib.OrderBatch
                    {
                        CustomerId = orderBatch.CustomerId,
                        StoreId = orderBatch.StoreId,
                        Date = DateTime.Now
                        
                    });
                    Repo.Save();
                    return RedirectToAction(nameof(Index),new { customerId = orderBatch.CustomerId });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderBatch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderBatch/Edit/5
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

        // GET: OrderBatch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderBatch/Delete/5
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