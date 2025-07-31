using HandsOnLab.BL;
using HandsOnLab.BL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnLab.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealersController : ControllerBase
    {
        private readonly IDealerBL _dealerBL;
        public DealersController(IDealerBL dealerBL)
        {
            _dealerBL = dealerBL;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DealerDTO>> GetDealers()
        {
            var dealers = _dealerBL.GetDealers();
            return Ok(dealers);
        }
    }
}
