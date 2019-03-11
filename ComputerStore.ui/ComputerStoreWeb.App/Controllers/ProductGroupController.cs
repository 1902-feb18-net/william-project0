using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStoreWeb.App.Controllers
{
    public class ProductGroupController : Controller
    {
        // GET: ProductGroup
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductGroup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductGroup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductGroup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductGroup/Edit/5
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

        // GET: ProductGroup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductGroup/Delete/5
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