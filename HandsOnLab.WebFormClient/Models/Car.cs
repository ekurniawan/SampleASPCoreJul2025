using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandsOnLab.WebFormClient.Models
{
    public class Car
    {
        public int CarId { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public double? BasePrice { get; set; }

        public string Color { get; set; }

        public int? Stock { get; set; }
    }
}
