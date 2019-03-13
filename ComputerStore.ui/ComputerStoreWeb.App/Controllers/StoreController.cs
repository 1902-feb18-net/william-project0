using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerStore.Context;
using ComputerStoreWeb.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Lib = ComputerStore.Library;

namespace ComputerStoreWeb.App.Controllers
{
    public class StoreController : Controller
    {
        public Lib.IComputerStoreRepository Repo { get; }

        private readonly ILogger<StoreController> _logger;

        public StoreController(Lib.IComputerStoreRepository repo, ILogger<StoreController> logger)
        {
            Repo = repo;
            _logger = logger;
        }
        // GET: Store
        public ActionResult Index([FromQuery]string search = "")
        {
            IEnumerable<Lib.Store> libStores = Repo.GetStores(search);
            return View(libStores);
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            Lib.Store libStore = Repo.GetStoreById(id);
            StoreModel webStore = new StoreModel
            {
                Id = libStore.Id,
                Name = libStore.Name,
                Address = libStore.Address,
                inventories = Repo.GetInventoriesByStore(id)
            };
            
            return View(webStore);
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store store)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Repo.AddStore(new Lib.Store
                    {
                        Name = store.Name,
                        Address = store.Address
                    });
                    Repo.Save();
                    return RedirectToAction(nameof(Index));
                }
                return View(store);
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            Lib.Store libStore = Repo.GetStoreById(id);
            return View(libStore);
        }

        // POST: Store/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Store store)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Lib.Store libStore = Repo.GetStoreById(id);
                    libStore.Name = store.Name;
                    libStore.Address = store.Address;
                    Repo.UpdateStore(libStore);
                    Repo.Save();
                    return RedirectToAction(nameof(Index));
                }
                return View(store);
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            Lib.Store libStore = Repo.GetStoreById(id);
            return View(libStore);
        }

        // POST: Store/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [BindNever]IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Repo.DeleteStore(id);
                Repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}