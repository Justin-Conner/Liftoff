using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moonwalkers.Data;
using Moonwalkers.Models;
using Moonwalkers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Moonwalkers.Controllers
{
    public class InventorySupplierController : Controller
    {
        private readonly InventoryDbContext context;

        public InventorySupplierController(InventoryDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<InventorySupplier> suppliers = context.Suppliers.ToList();

            return View(suppliers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessCreateInventorySupplierForm(AddInventorySupplierViewModel addInventorySupplierViewModel)
        {
            if (ModelState.IsValid)
            {
                InventorySupplier theSupplier = new InventorySupplier
                {
                    Supplier = addInventorySupplierViewModel.Supplier
                };

                context.Suppliers.Add(theSupplier);
                context.SaveChanges();

                return Redirect("/InventorySupplier");
            }
            return View("Create", addInventorySupplierViewModel);
        }

    }
}
