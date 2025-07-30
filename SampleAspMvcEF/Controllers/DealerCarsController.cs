using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleAspMvcEF.DAL;
using SampleAspMvcEF.Models;
using SampleAspMvcEF.ViewModels;

namespace SampleAspMvcEF.Controllers
{
    public class DealerCarsController : Controller
    {
        private readonly IDealerCar _dealerCar;
        private readonly ICar _car;
        private readonly IDealer _dealer;

        public DealerCarsController(IDealerCar dealerCar, ICar car, IDealer dealer)
        {
            _dealerCar = dealerCar;
            _car = car;
            _dealer = dealer;
        }


        // GET: DealerCarsController
        public ActionResult Index()
        {
            var dealerCars = _dealerCar.GetAll().ToList();
            /*var dealerCarViewModels = dealerCars.Select(dc => new DealerCarViewModel
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
             }).ToList();*/
            var dealerCarViewModels = new List<DealerCarViewModel>();
            foreach (var dc in dealerCars)
            {
                dealerCarViewModels.Add(new DealerCarViewModel
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
                });
            }

            return View(dealerCarViewModels);
        }

        // GET: DealerCarsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DealerCarsController/Create
        public ActionResult Create()
        {
            ViewBag.Cars = _car.GetAll().Select(c => new SelectListItem
            {
                Value = c.CarId.ToString(),
                Text = c.Model
            }).ToList();

            ViewBag.Dealers = _dealer.GetAll().Select(d => new SelectListItem
            {
                Value = d.DealerId.ToString(),
                Text = d.Name
            }).ToList();

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
