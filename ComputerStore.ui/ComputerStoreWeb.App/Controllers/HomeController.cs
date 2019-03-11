using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComputerStoreWeb.App.Models;
using Lib = ComputerStore.Library;
using ComputerStore.Context;

namespace ComputerStoreWeb.App.Controllers
{
    public class HomeController : Controller
    {
        public Lib.IComputerStoreRepository Repo { get; }

        public HomeController(Lib.IComputerStoreRepository repo)
        {
            Repo = repo;
        }


        public IActionResult Index()
        {

            //var spend = (from oB in _db.OrderBatch
            //             join oI in _db.OrderItem on oB.Id equals oI.BatchId
            //             join c in _db.Customer on oB.CustomerId equals c.Id
            //             group oI by c.FirstName into g
            //             select new
            //             {
            //                 Name = g.Key,
            //                 Sum = g.Sum(s => s.Cost)
            //             }).ToList().Last();
            //var store = (from oB in _db.OrderBatch
            //             join oI in _db.OrderItem on oB.Id equals oI.BatchId
            //             join s in _db.Store on oB.StoreId equals s.Id
            //             group oI by s.Name into g
            //             select new
            //             {
            //                 Name = g.Key,
            //                 Sum = g.Sum(s => s.Cost)
            //             }).ToList().Last();
            var n1product = Repo.GetOrders().OrderByDescending(o => o.Quantity).GroupBy(o => o.Name).First();
            var total = n1product.Where(o => o.Name == n1product.First().Name).Sum(o => o.Quantity);
           // ViewBag.N1proId = n1product.Name;
            
            ViewBag.Name = n1product.First().Name;
            ViewBag.Total = total;
            ViewBag.Hello = "Hello";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
