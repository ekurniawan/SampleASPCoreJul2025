using System;

namespace HandsOnLab.BL.DTO;

public class CarDTO
{
    public int CarId { get; set; }

    public string Model { get; set; }

    public string Type { get; set; }

    public double? BasePrice { get; set; }

    public string Color { get; set; }

    public int? Stock { get; set; }
}
