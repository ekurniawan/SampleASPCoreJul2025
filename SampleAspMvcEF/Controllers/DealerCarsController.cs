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
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

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
        public ActionResult Create(DealerCarInsertViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dealerCar = new DealerCar
                    {
                        CarId = model.CarId,
                        DealerId = model.DealerId,
                        Price = model.Price,
                        Stock = model.Stock,
                        DiscountPercent = model.DiscountPercent,
                        FeePercent = model.FeePercent
                    };
                    _dealerCar.Create(dealerCar);
                    TempData["Message"] = $"<span class='alert alert-success'>Dealer Car created successfully.</span>";
                    return RedirectToAction(nameof(Index));
                }
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
            var dealerCar = _dealerCar.GetById(id);
            if (dealerCar == null)
            {
                TempData["Message"] = $"<span class='alert alert-danger'>Dealer Car with ID {id} not found.</span>";
                return RedirectToAction(nameof(Index));
            }

            var model = new DealerCarUpdateViewModel
            {
                DealerCarId = dealerCar.DealerCarId,
                CarId = dealerCar.CarId,
                DealerId = dealerCar.DealerId,
                Price = dealerCar.Price,
                Stock = dealerCar.Stock,
                DiscountPercent = dealerCar.DiscountPercent,
                FeePercent = dealerCar.FeePercent
            };

            ViewBag.Cars = _car.GetAll().Select(c => new SelectListItem
            {
                Value = c.CarId.ToString(),
                Text = c.Model,
                Selected = c.CarId == dealerCar.CarId
            }).ToList();

            ViewBag.Dealers = _dealer.GetAll().Select(d => new SelectListItem
            {
                Value = d.DealerId.ToString(),
                Text = d.Name,
                Selected = d.DealerId == dealerCar.DealerId
            }).ToList();

            return View(model);
        }

        // POST: DealerCarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DealerCarUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updatedDealerCar = _dealerCar.GetById(id);
                    if (updatedDealerCar == null)
                    {
                        TempData["Message"] = $"<span class='alert alert-danger'>Dealer Car with ID {id} not found.</span>";
                        return RedirectToAction(nameof(Index));
                    }

                    updatedDealerCar.CarId = model.CarId;
                    updatedDealerCar.DealerId = model.DealerId;
                    updatedDealerCar.Price = model.Price;
                    updatedDealerCar.Stock = model.Stock;
                    updatedDealerCar.DiscountPercent = model.DiscountPercent;
                    updatedDealerCar.FeePercent = model.FeePercent;
                    _dealerCar.Update(updatedDealerCar);

                    TempData["Message"] = $"<span class='alert alert-success'>Dealer Car updated successfully.</span>";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred while updating the dealer car: {ex.Message}");

                ViewBag.Cars = _car.GetAll().Select(c => new SelectListItem
                {
                    Value = c.CarId.ToString(),
                    Text = c.Model,
                    Selected = c.CarId == model.CarId
                }).ToList();

                ViewBag.Dealers = _dealer.GetAll().Select(d => new SelectListItem
                {
                    Value = d.DealerId.ToString(),
                    Text = d.Name,
                    Selected = d.DealerId == model.DealerId
                }).ToList();
            }
            return View(model);
        }

        // GET: DealerCarsController/Delete/5
        public ActionResult Delete(int id)
        {
            var dealerCar = _dealerCar.GetById(id);
            if (dealerCar == null)
            {
                TempData["Message"] = $"<span class='alert alert-danger'>Dealer Car with ID {id} not found.</span>";
                return RedirectToAction(nameof(Index));
            }
            return View(dealerCar);
        }

        // POST: DealerCarsController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                var dealerCar = _dealerCar.GetById(id);
                if (dealerCar == null)
                {
                    TempData["Message"] = $"<span class='alert alert-danger'>Dealer Car with ID {id} not found.</span>";
                    return RedirectToAction(nameof(Index));
                }

                _dealerCar.Delete(id);
                TempData["Message"] = $"<span class='alert alert-success'>Dealer Car with ID {id} deleted successfully.</span>";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
