using System;
using System.ComponentModel.DataAnnotations;

namespace SampleAspMvcEF.ViewModels;

public class DealerCarInsertViewModel
{
    public int CarId { get; set; }
    public int DealerId { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
    [DataType(DataType.Currency)]
    public double Price { get; set; }

    [Required(ErrorMessage = "Stock is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative integer.")]
    [Display(Name = "Available Stock")]
    [DataType(DataType.Text)]
    public int Stock { get; set; }

    [Required(ErrorMessage = "Discount Percent is required.")]
    [Range(0, 100, ErrorMessage = "Discount Percent must be between 0 and 100.")]
    [Display(Name = "Discount Percent")]
    [DataType(DataType.Text)]
    public double? DiscountPercent { get; set; }

    [Required(ErrorMessage = "Fee Percent is required.")]
    [Range(0, 100, ErrorMessage = "Fee Percent must be between 0 and 100.")]
    [Display(Name = "Fee Percent")]
    [DataType(DataType.Text)]
    public double? FeePercent { get; set; }
}
