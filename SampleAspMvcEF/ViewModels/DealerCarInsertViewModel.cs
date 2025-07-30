using System;
using System.ComponentModel.DataAnnotations;

namespace SampleAspMvcEF.ViewModels;

public class DealerCarInsertViewModel
{
    public int CarId { get; set; }
    public int DealerId { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Stock is required.")]
    public int Stock { get; set; }

    [Required(ErrorMessage = "Discount Percent is required.")]
    public double? DiscountPercent { get; set; }

    [Required(ErrorMessage = "Fee Percent is required.")]
    public double? FeePercent { get; set; }
}
