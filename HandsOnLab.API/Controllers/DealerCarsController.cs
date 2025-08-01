using HandsOnLab.BL;
using HandsOnLab.BL.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HandsOnLab.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerCarsController : ControllerBase
    {
        private readonly IDealerCarBL _dealerCarBL;

        public DealerCarsController(IDealerCarBL dealerCarBL)
        {
            _dealerCarBL = dealerCarBL;
        }

        // GET: api/<DealerCarsController>
        [HttpGet]
        public IEnumerable<DealerCarDTO> Get()
        {
            var dealerCars = _dealerCarBL.GetAllDealerCars();
            return dealerCars;
        }

        // GET api/<DealerCarsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DealerCarsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DealerCarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DealerCarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
