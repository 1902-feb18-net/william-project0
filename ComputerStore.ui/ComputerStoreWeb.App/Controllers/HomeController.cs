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
            // I just wanted to get the Customer Id and Total spent by them...
            //var spend = Repo.GetOrders().Join(Repo.GetOrderBatches(),
            //                                    o => o.BatchId,
            //                                    b => b.Id,
            //                                    (o,b) => new { Cost = o.Cost, Id = b.CustomerId })
            //                             .OrderBy(g => g.Cost )
            //                             .GroupBy(g => g.Id)
            //                             .Last();
            //var spender = Repo.GetCustomerById();
            //var spend = (from oB in Repo.GetOrderBatches()
            //             join oI in Repo.GetOrders() on oB.Id equals oI.BatchId
            //             join c in Repo.GetCustomers("") on oB.CustomerId equals c.ID
            //             group oI by c.FirstName into g
            //             select new
            //             {
            //                 Name = g.Key,
            //                 Sum = g.Sum(s => s.Cost)
            //             }).ToList().Last();
            //var store = (from oB in Repo.GetOrderBatches()
            //             join oI in Repo.GetOrders() on oB.Id equals oI.BatchId
            //             join s in Repo.GetStores("") on oB.StoreId equals s.Id
            //             group oI by s.Name into g
            //             select new
            //             {
            //                 Name = g.Key,
            //                 Sum = g.Sum(s => s.Cost)
            //             }).ToList().Last();
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
