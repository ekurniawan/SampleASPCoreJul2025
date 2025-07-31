using HandsOnLab.BL;
using HandsOnLab.BL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnLab.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarBL _carBL;
        public CarsController(ICarBL carBL)
        {
            _carBL = carBL;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarDTO>> GetCars()
        {
            var cars = _carBL.GetCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public ActionResult<CarDTO> GetCarById(int id)
        {
            var car = _carBL.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
    }
}
