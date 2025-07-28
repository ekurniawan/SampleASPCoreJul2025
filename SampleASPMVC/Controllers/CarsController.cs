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
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

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

                    TempData["Message"] = "<span class='alert-success'>Car added successfully!</span>";
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

        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdatePost(int CarID, Car car)
        {
            if (CarID != car.CarID)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _carService.Update(car);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(car);
        }
    }
}
