using System.ComponentModel.DataAnnotations;

namespace Moonwalkers.ViewModels
{
    public class AddInventorySupplierViewModel
    {
        [Required(ErrorMessage = "Please add a Supplier type")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Supplier type should be between 1-20 characters")]
        public string? Supplier { get; set; }
    }
}
