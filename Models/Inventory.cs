using System;

namespace Moonwalkers.Models
{
    public class Inventory
    {
        public string? Product { get; set; }
        public string? Supplier { get; set; }
        public int SupplierId { get; set; }
        //public InventorySupplier Supplier { get; set; }
        public int InventoryId { get; set; }

        public int Id { get; set; }
        public int InventoryQuantity { get; set; }

        public string? Description { get; internal set; }

        public Inventory()
        {
        }

        public Inventory(string product, string supplier, int inventoryQuantity)
        {
            Product = product;
            Supplier = supplier;
            InventoryQuantity = inventoryQuantity;

        }

        public override string? ToString()
        {
            return Product;
        }

        public override bool Equals(object? obj)
        {
            return obj is Inventory @inventory && Id == @inventory.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}