using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAspMvcEF.DAL;
using SampleAspMvcEF.ViewModels;

namespace SampleAspMvcEF.Controllers
{
    public class DealerCarsController : Controller
    {
        private readonly IDealerCar _dealerCar;
        public DealerCarsController(IDealerCar dealerCar)
        {
            _dealerCar = dealerCar;
        }


        // GET: DealerCarsController
        public ActionResult Index()
        {
            var dealerCars = _dealerCar.GetAll().ToList();
            var dealerCarViewModel = dealerCars.Select(dc => new DealerCarViewModel
            {
                DealerCarId = dc.DealerCarId,
                CarId = dc.CarId,
                Model = dc.Car.Model,
                DealerId = dc.DealerId,
                Name = dc.Dealer.Name,
                Price = dc.Price,
                Stock = dc.Stock,
                DiscountPercent = dc.DiscountPercent,
                FeePercent = dc.FeePercent
            }).ToList();

            return View(dealerCarViewModel);
        }

        // GET: DealerCarsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DealerCarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DealerCarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DealerCarsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DealerCarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DealerCarsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DealerCarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
