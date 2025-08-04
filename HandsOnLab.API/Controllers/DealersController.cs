using HandsOnLab.BL;
using HandsOnLab.BL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnLab.API.Controllers
{
    [Authorize]
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

        [HttpGet("{id}")]
        public ActionResult<DealerDTO> GetDealer(int id)
        {
            var dealer = _dealerBL.GetById(id);
            if (dealer == null)
            {
                return NotFound();
            }
            return Ok(dealer);
        }

        [HttpPost]
        public ActionResult<DealerDTO> CreateDealer(DealerInsertDTO dealerInsertDTO)
        {
            if (dealerInsertDTO == null)
            {
                return BadRequest("Dealer data is null.");
            }

            var createdDealer = _dealerBL.AddDealer(dealerInsertDTO);
            return CreatedAtAction(nameof(GetDealer), new { id = createdDealer.DealerId },
                 createdDealer);
        }

        [HttpPut("{id}")]
        public ActionResult<DealerDTO> UpdateDealer(int id, DealerUpdateDTO dealerUpdateDTO)
        {
            if (dealerUpdateDTO == null || dealerUpdateDTO.DealerId != id)
            {
                return BadRequest("Dealer data is null.");
            }

            var updatedDealer = _dealerBL.UpdateDealer(dealerUpdateDTO);
            if (updatedDealer == null)
            {
                return NotFound();
            }
            return Ok(updatedDealer);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDealer(int id)
        {
            var dealer = _dealerBL.GetById(id);
            if (dealer == null)
            {
                return NotFound();
            }

            _dealerBL.DeleteDealer(id);
            return NoContent();
        }
    }
}
