using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStoreWeb.App.Controllers
{
    public class SubProductController : Controller
    {
        // GET: SubProduct
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubProduct/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubProduct/Create
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

        // GET: SubProduct/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubProduct/Edit/5
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

        // GET: SubProduct/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubProduct/Delete/5
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