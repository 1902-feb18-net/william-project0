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
    public class ProductController : Controller
    {
        public Lib.IComputerStoreRepository Repo { get; }

        public ProductController(Lib.IComputerStoreRepository repo)
        {
            Repo = repo;
        }

        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<Lib.Product> libProducts = Repo.GetProducts();
            IEnumerable<ProductModel> webProducts = libProducts.Select(x => new ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Cost = x.Cost
            });

            return View(webProducts);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel product)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Repo.AddProduct(new Lib.Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Cost = product.Cost
                    });
                    Repo.Save();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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