using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerStore.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lib = ComputerStore.Library;
using Con = ComputerStore.Context;
using ComputerStoreWeb.App.Models;
using Microsoft.Extensions.Logging;

namespace ComputerStoreWeb.App.Controllers
{
    public class CustomerController : Controller
    {
        public Lib.IComputerStoreRepository Repo { get; }

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(Lib.IComputerStoreRepository repo, ILogger<CustomerController> logger)
        {
            Repo = repo;
            _logger = logger;
        }



        // GET: Customer
        public ActionResult Index([FromQuery]string search = "")
        {
            IEnumerable<Lib.Customer> libCustomers = Repo.GetCustomers(search);
            IEnumerable<CustomerModel> webCustomers = libCustomers.Select(x => new CustomerModel
            {
                Id = x.ID,
                StoreId = x.StoreId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber
            });
            
            return View(webCustomers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Lib.Customer libCustomer = Repo.GetCustomerById(id);
            CustomerModel webCustomer = new CustomerModel
            {
                Id = libCustomer.ID,
                StoreId = libCustomer.StoreId,
                FirstName = libCustomer.FirstName,
                LastName = libCustomer.LastName,
                Address = libCustomer.Address,
                PhoneNumber = libCustomer.PhoneNumber,
                Store = Repo.GetStoreById(libCustomer.StoreId),
                OrderBatches = Repo.GetOrderBatchesByCustomer(libCustomer.ID).OrderByDescending(o => o.Date)
            };
            return View(webCustomer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Repo.AddCustomer(new Lib.Customer
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Address = customer.Address,
                        PhoneNumber = customer.PhoneNumber,
                        StoreId = customer.StoreId
                    });
                    Repo.Save();
                    return RedirectToAction(nameof(Index));
                }
                return View(customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Lib.Customer libCustomer = Repo.GetCustomerById(id);
            CustomerModel webCustomer = new CustomerModel
            {
                Id = libCustomer.ID,
                FirstName = libCustomer.FirstName,
                LastName = libCustomer.LastName,
                Address = libCustomer.Address,
                PhoneNumber = libCustomer.PhoneNumber,
                StoreId = libCustomer.StoreId
            };
            return View(webCustomer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerModel customer)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Lib.Customer libCustomer = Repo.GetCustomerById(id);
                    libCustomer.FirstName = customer.FirstName;
                    libCustomer.LastName = customer.LastName;
                    libCustomer.Address = customer.Address;
                    libCustomer.PhoneNumber = customer.PhoneNumber;
                    libCustomer.StoreId = customer.StoreId;
                    Repo.UpdateCustomer(libCustomer);
                    Repo.Save();
                    return RedirectToAction(nameof(Index));
                }
                return View(customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Lib.Customer libCustomer = Repo.GetCustomerById(id);
            return View(libCustomer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Repo.DeleteCustomer(id);
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