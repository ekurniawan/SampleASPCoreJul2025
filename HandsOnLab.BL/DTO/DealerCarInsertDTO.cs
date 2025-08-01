using System;

namespace HandsOnLab.BL.DTO;

public class DealerCarInsertDTO
{
    public int CarId { get; set; }

    public int DealerId { get; set; }

    public double Price { get; set; }

    public int Stock { get; set; }

    public double? DiscountPercent { get; set; }

    public double? FeePercent { get; set; }
}
