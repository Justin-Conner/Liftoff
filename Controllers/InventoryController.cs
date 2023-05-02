using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moonwalkers.Data;
using Moonwalkers.Models;
using Microsoft.AspNetCore.Mvc;
using Moonwalkers.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moonwalkers.Controllers
{
    public class InventoryController : Controller
    {
        private InventoryDbContext context;

        public InventoryController(InventoryDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Inventory> inventory = context.Inventory.Include(e => e.Supplier).ToList();

            return View(inventory);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<InventorySupplier> suppliers = context.Suppliers.ToList();
            AddInventoryViewModel addInventoryViewModel = new AddInventoryViewModel(suppliers);

            return View(addInventoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddInventoryViewModel addInventoryViewModel)
        {
            if (ModelState.IsValid)
            {
                InventorySupplier theSupplier = context.Suppliers.Find(addInventoryViewModel.SupplierId);
                Inventory newInventory = new Inventory
                {
                    Product = addInventoryViewModel.Product,
                    Description = addInventoryViewModel.Description,
                    Supplier = theSupplier
                };

                context.Inventory.Add(newInventory);
                context.SaveChanges();

                return Redirect("/Inventory");
            }

            return View(addInventoryViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.inventory = context.Inventory.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] inventoryIds)
        {
            foreach (int inventoryId in inventoryIds)
            {
                Inventory? theInventory = context.Inventory.Find(inventoryId);
                context.Inventory.Remove(theInventory);
            }

            context.SaveChanges();

            return Redirect("/Inventory");
        }
    }
}

