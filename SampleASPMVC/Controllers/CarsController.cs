using Microsoft.AspNetCore.Mvc;
using SampleASPMVC.Models;

namespace SampleASPMVC.Controllers
{
    public class CarsController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            List<string> cars = new List<string>
            {
                "Toyota",
                "Honda",
                "Ford",
                "Chevrolet",
                "Mitsubishi"
            };
            ViewData["username"] = "JohnDoe";
            ViewData["address"] = "123 Main St, Springfield";
            ViewBag.City = "Springfield";
            ViewBag.Country = "USA";
            ViewBag.Cars = cars;

            List<Car> carList = new List<Car>
            {
                new Car { CarID = 1, Model = "Toyota Camry", Type = "Sedan", BasePrice = 300000000, Color = "Red", Stock = 5 },
                new Car { CarID = 2, Model = "Honda Accord", Type = "Sedan", BasePrice = 320000000, Color = "Black", Stock = 3 },
                new Car { CarID = 3, Model = "Ford Explorer", Type = "SUV", BasePrice = 450000000, Color = "White", Stock = 2 },
                new Car { CarID = 4, Model = "Chevrolet Tahoe", Type = "SUV", BasePrice = 500000000, Color = "Silver", Stock = 4 },
                new Car { CarID = 5, Model = "Mitsubishi Outlander", Type = "SUV", BasePrice = 250000000, Color = "Blue", Stock = 10 }
            };

            return View(carList);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertPost(string CarID)
        {
            return Content($"CarID: {CarID}");
        }

    }
}
