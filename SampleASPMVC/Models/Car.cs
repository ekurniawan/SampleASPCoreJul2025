using System;

namespace SampleASPMVC.Models;

public class Car
{
    public int CarID { get; set; }
    public string Model { get; set; } = null!;
    public string Type { get; set; } = null!;
    public double? BasePrice { get; set; } = 0.0;
    public string Color { get; set; } = null!;
    public int? Stock { get; set; } = 0;
}
