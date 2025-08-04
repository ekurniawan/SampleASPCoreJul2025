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
            //check login
            var account = HttpContext.Session.GetString("account");
            if (string.IsNullOrEmpty(account))
            {
                return RedirectToAction("Login", "Accounts");
            }
            //convert to UserViewModel
            var user = System.Text.Json.JsonSerializer.Deserialize<UserViewModel>(account);
            var token = user?.Token.ToString();

            var models = await _dealerService.GetDealersAsync(token);
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
        public async Task<ActionResult> Edit(int id)
        {
            var dealer = await _dealerService.GetDealerByIdAsync(id);
            if (dealer == null)
            {
                return NotFound();
            }
            var dealerUpdate = new DealerUpdate
            {
                DealerId = dealer.DealerId,
                Name = dealer.Name,
                Address = dealer.Address,
                PhoneNumber = dealer.PhoneNumber,
                Email = dealer.Email,
                Status = dealer.Status
            };

            return View(dealerUpdate);
        }

        // POST: DealersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DealerUpdate dealerUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dealerUpdate.DealerId = id;
                    var updatedDealer = await _dealerService.UpdateDealerAsync(dealerUpdate);
                    if (updatedDealer != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(dealerUpdate);
            }
            catch
            {
                return View();
            }
        }

        // GET: DealersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var dealer = await _dealerService.GetDealerByIdAsync(id);
            if (dealer == null)
            {
                return NotFound();
            }

            return View(dealer);
        }

        // POST: DealersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _dealerService.DeleteDealerAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
