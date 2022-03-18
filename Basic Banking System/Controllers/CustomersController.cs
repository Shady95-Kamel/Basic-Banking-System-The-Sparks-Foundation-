using Basic_Banking_System.Models;
using Basic_Banking_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Banking_System.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            return View(customerService.GetAll());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View(customerService.GetbyId(id));
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerDto model)
        {
            try
            {
                customerService.Add(new Customer { FirstName = model.FirstName, LastName = model.LastName, Balance = model.Balance, Email = model.Email });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(customerService.GetbyId(id));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerDto model)
        {
            try
            {
                customerService.Update(new Customer { Id = id, FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, Balance = model.Balance });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Transfer/5
        public ActionResult Transfer(int id)
        {

            return View(new TransferVM { Sender = customerService.GetbyId(id), Receivers = customerService.FindAll(c => c.Id != id) });
        }

        // POST: CustomerController/Transfer/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Transfer(int Id, TransferVM model)
        {
            try
            {
                customerService.Transfer(Id, model.ReceiverId, model.Amount);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult GetTransfers() 
        {
            return View(customerService.GetTransfers());
        }
    }
}
