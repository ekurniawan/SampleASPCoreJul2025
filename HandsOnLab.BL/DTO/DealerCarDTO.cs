using System;

namespace HandsOnLab.BL.DTO;

public class DealerCarDTO
{
    public int DealerCarId { get; set; }

    public int CarId { get; set; }

    public int DealerId { get; set; }

    public double Price { get; set; }

    public int Stock { get; set; }

    public double? DiscountPercent { get; set; }

    public double? FeePercent { get; set; }

    public virtual CarDTO CarDTO { get; set; }

    public virtual DealerDTO DealerDTO { get; set; }
}
