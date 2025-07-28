using Microsoft.AspNetCore.Mvc;
using SampleASPMVC.Models;
using SampleASPMVC.Services;

namespace SampleASPMVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICar _carService;
        public CarsController(ICar carService)
        {
            _carService = carService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var models = _carService.GetAll();
            return View(models);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Insert")]
        public IActionResult InsertPost(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _carService.Create(car);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(car);
        }

        public IActionResult Update(int id)
        {
            var car = _carService.Read(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

    }
}
