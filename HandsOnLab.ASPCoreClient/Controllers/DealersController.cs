using HandsOnLab.ASPCoreClient.Models;
using HandsOnLab.ASPCoreClient.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnLab.ASPCoreClient.Controllers
{
    public class DealersController : Controller
    {
        private readonly IDealerService _dealerService;

        public DealersController(IDealerService dealerService)
        {
            _dealerService = dealerService;
        }
        // GET: DealersController
        public async Task<ActionResult> Index()
        {
            var models = await _dealerService.GetDealersAsync();
            return View(models);
        }

        // GET: DealersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DealersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DealersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DealerInsert dealerInsert)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dealer = await _dealerService.CreateDealerAsync(dealerInsert);
                    if (dealer != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(dealerInsert);
            }
            catch
            {
                return View();
            }
        }

        // GET: DealersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DealersController/Edit/5
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

        // GET: DealersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DealersController/Delete/5
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
