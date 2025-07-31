using System;

namespace HandsOnLab.BL.DTO;

public class CarDTO
{
    public int DealerCarId { get; set; }

    public int CarId { get; set; }

    public string Model { get; set; }

    public int DealerId { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public int Stock { get; set; }

    public double? DiscountPercent { get; set; }

    public double? FeePercent { get; set; }
}
