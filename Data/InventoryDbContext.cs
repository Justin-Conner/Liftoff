using System;
using Moonwalkers.Models;
using Moonwalkers.Controllers;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Moonwalkers.Data
{
    public class InventoryDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventorySupplier> Suppliers { get; set; }


        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }

}

