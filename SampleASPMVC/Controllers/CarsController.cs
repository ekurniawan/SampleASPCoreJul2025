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


        public IActionResult Index(string? search = "")
        {
            List<Car> models = new List<Car>();
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            if (!string.IsNullOrEmpty(search))
            {
                models = _carService.GetByModel(search).ToList();
            }
            else
            {
                models = _carService.GetAll().ToList();
            }

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

                    TempData["Message"] = "<span class='alert alert-success'>Car added successfully!</span><br/><br/>";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(car);
        }

        [HttpGet]
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
        public IActionResult UpdatePost(int id, Car car)
        {
            var result = _carService.Read(id);
            if (result == null)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _carService.Update(car);
                    TempData["Message"] = "<span class='alert alert-success'>Car updated successfully!</span><br/><br/>";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(car);
        }

        public IActionResult Delete(int id)
        {
            var car = _carService.Read(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var car = _carService.Read(id);
            if (car == null)
            {
                return NotFound();
            }

            try
            {
                _carService.Delete(id);
                TempData["Message"] = $"<span class='alert alert-success'>Car model {car.Model} deleted successfully!</span><br/><br/>";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(car);
        }
    }
}
